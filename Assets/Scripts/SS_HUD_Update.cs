using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class SS_HUD_Update : MonoBehaviour
{
    public Text ThisText;
    // public tleFormat tle = new tleFormat();

    public float targetTime = 5.0f; //  timer

    void Start() {


      // StartCoroutine(GetRequest("https://celestrak.com/NORAD/elements/stations.txt"));
    }


    void Update() {

      targetTime -= Time.deltaTime; //Delta Time is time between last frame update? 

      if (targetTime <= 0.0f) {
        UpdateText();
      }
    }


    void UpdateText() {
        // ThisText.text = "Helloooooo";
        // targetTime = 5.0f; // reset the timer
    }

    IEnumerator GetRequest(string uri) {
      using (UnityWebRequest webRequest = UnityWebRequest.Get(uri)) {
        // Request and wait for the desired page.
        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError) {
          Debug.Log("Error: " + webRequest.error);
        }
        else {

          byte[] bytes =  webRequest.downloadHandler.data;
          // string issTleText = tle.getIssTle(bytes);

          // ThisText.text += issTleText;
        }
      }


    }


    

}