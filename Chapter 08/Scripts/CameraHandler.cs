/// <summary>
/// Allows the camera to be dragged and zoomed
/// </summary>
using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CameraHandler : MonoBehaviour {
	private Camera theCamera;
	[Header("----- Pan Properties ----")]
	public bool cameraBeingDragged = false; //turned on when the drag area is dragging
	public bool canPan = true; // turned off when the game is paused
	public float panSpeed = 20f;
	float defaultPanSpeed = 20f;
	[Tooltip("the how far left and right the camera can pan")]
	[SerializeField] float[] panBoundsX = new float[2]; 
	[Tooltip("the how far up and down the camera can pan")]
	[SerializeField] float[] panBoundsY = new float[2];
	private Vector3 lastPanPosition;
	private int panFingerId; // used for touch controls
	
	[Header("----- Zoom Properties ----")]
	public bool canZoom = true; // turned off when the game is paused
	public float zoomSpeedMouse = 1f;
	public float zoomSpeedTouch = 0.1f;
	private float initialCameraZoom = 5f;
	public float minZoom = 5f; // minimum zoom bound 
	[SerializeField] float[] zoomBounds = new float[2];
	
	private bool wasZoomingLastFrame; // Touch mode only
	private Vector2[] lastZoomPositions; // Touch mode only
	void Awake() {
		theCamera = GetComponent<Camera>();
	}
	

	//called from the Drag Event on the Background canvas and the tiles
	public void DragCamera(){
		cameraBeingDragged = true;
	}

	//called from the EndDrag Event on the Background canvas and the tiles
	public void StopCameraDrag(){
		cameraBeingDragged = false;
	}


	void Update() {
#if UNITY_EDITOR
		//pinch-to-zoom moved here b/c it requires the UNITY_EDITOR
		if (!EditorApplication.isRemoteConnected) {
			HandleMouse();
			
		} else {
			HandleTouch();
			
		}
#endif

#if !UNITY_EDITOR
		HandleTouch();
#endif	
	}

	//determines what to do if touch controls are being used
	void HandleTouch() {
		switch(Input.touchCount) {

		case 1: // Panning
			Debug.Log("Panning");
			wasZoomingLastFrame = false;
			
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began) {
				lastPanPosition = touch.position;
				panFingerId = touch.fingerId;
			} else if (touch.fingerId == panFingerId && touch.phase == TouchPhase.Moved) {
				PanCamera(touch.position);
			}
			break;

		case 2: // Zooming
			Debug.Log("Zooming");
			Vector2[] newPositions = new Vector2[]{Input.GetTouch(0).position, Input.GetTouch(1).position};
			if (!wasZoomingLastFrame) {
				lastZoomPositions = newPositions;
				wasZoomingLastFrame = true;
			} else {
				// Zoom based on the distance between the new positions compared to the 
				// distance between the previous positions.
				float newDistance = Vector2.Distance(newPositions[0], newPositions[1]);
				float oldDistance = Vector2.Distance(lastZoomPositions[0], lastZoomPositions[1]);
				float offset = newDistance - oldDistance;

				ZoomCamera(offset, zoomSpeedTouch);

				lastZoomPositions = newPositions;
			}
			break;

		default: 
			wasZoomingLastFrame = false;
			break;
		}
	}

	//determines what to do if mouse controls are being used
	void HandleMouse() {
		// true as long as left mouse button is held down
		if (Input.GetMouseButtonDown(0)) {
			lastPanPosition = Input.mousePosition;
		
		// true only the moment the left mouse button is pressed	
		} else if (Input.GetMouseButton(0)) {
			PanCamera(Input.mousePosition);
		}

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		ZoomCamera(scroll, zoomSpeedMouse);
	}
	
	void PanCamera(Vector3 newPanPosition) {
		if (canPan) {
			if (cameraBeingDragged) {
				// determine the position
				Vector3 offset = theCamera.ScreenToViewportPoint(lastPanPosition - newPanPosition);
				Vector3 move = new Vector3(offset.x * panSpeed, offset.y * panSpeed, -10f);
			
				// move the camera
				transform.Translate(move, Space.World);
				Vector3 pos = transform.position;
				pos.x = Mathf.Clamp(transform.position.x, panBoundsX[0], panBoundsX[1]);
				pos.y = Mathf.Clamp(transform.position.y, panBoundsY[0], panBoundsY[1]);
				pos.z = -10f;
				transform.position = pos;
			
				// update the tracker variable
				lastPanPosition = newPanPosition;
			}
		}

		
	}
		
	//zoom the camera in and out
	void ZoomCamera(float offset, float speed) {
		if (offset == 0) {
			return;
		}
		if (canZoom) {
			// zoom the camera
			theCamera.orthographicSize = Mathf.Clamp(theCamera.orthographicSize - (offset * speed), zoomBounds[0], zoomBounds[1]);

			//adjust pan speed based on zoom
			float speedPercent = theCamera.orthographicSize / initialCameraZoom;
			panSpeed = defaultPanSpeed * speedPercent;
		}
	}

	
	
	public void TurnOffPanAndZoom() {
		canPan = false;
		canZoom = false;
	}

	// called from close buttons on pause menu
	public void TurnOnPanAndZoom() {
		canPan = true;
		canZoom = true;
	}
}