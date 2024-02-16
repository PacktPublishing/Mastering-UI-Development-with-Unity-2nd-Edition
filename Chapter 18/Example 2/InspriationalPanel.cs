using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;

public class InspriationalPanel : MonoBehaviour {
    private UIDocument uiDocument;
    
    private Button charmButton;
    private IStyle catPicStyle;
    
    private Button inspireButton;
    private Label inspirationalQuote;

    void Start() {
        uiDocument = GetComponent<UIDocument>();
        var root = uiDocument.rootVisualElement;
        
        charmButton = root.Q<Button>("CharmButton");
        charmButton.clicked += OnCharmClicked;
        
        VisualElement catPic = root.Q<VisualElement>("CatPic");
        catPicStyle = catPic.style;
        
        inspireButton = root.Q<Button>("InspireButton");
        inspireButton.clicked += OnInspireClicked;
        
        inspirationalQuote = root.Q<Label>("InspirationalQuote");
    }
    
    private void OnCharmClicked() {
        StartCoroutine(GetCatPic());
    }
    
    IEnumerator GetCatPic() {
        catPicStyle.backgroundImage = null;
        int randomWidth = Random.Range(150, 300);
        int randomHeight = Random.Range(150, 300);

        catPicStyle.width = randomWidth;
        catPicStyle.height = randomHeight;
    
        string uri = "https://placekitten.com/" + randomWidth + "/" + randomHeight;
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(uri);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success) {
            Debug.Log(request.error);
        } else {
            Texture2D myTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Debug.Log("Texture Acquired");
            catPicStyle.backgroundImage = new StyleBackground(myTexture);
        }
    } 

    private void OnInspireClicked() {
        StartCoroutine(GetInspiringQuote());
    }
    
    IEnumerator GetInspiringQuote() {
        UnityWebRequest request = UnityWebRequest.Get("https://zenquotes.io/api/random");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success) {
            Debug.Log(request.error);
            
        } else {
            Debug.Log("Quote Acquired");
            string response = request.downloadHandler.text;
            Debug.Log(response.ToString());
            
            JArray jArray = JArray.Parse(response);
            JObject jObject = JObject.Parse(jArray[0].ToString());
            string quote = (string)jObject["q"];
            string author = (string)jObject["a"];

            inspirationalQuote.text = "\"" + quote + "\" \n~" + author;
        }
    } 
    
    private void OnDisable() {
        charmButton.clicked -= OnCharmClicked;
    }
}
