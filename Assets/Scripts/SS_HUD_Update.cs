using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class SS_HUD_Update : MonoBehaviour
{
    public Text ThisText;
    public float targetTime = 5.0f; //  timer


    void Start() {

        // A correct website page.
        StartCoroutine(GetRequest("https://www.example.com"));

     

    }


    void Update() {

        targetTime -= Time.deltaTime; //Delta Time is time between last frame update? 

        if (targetTime <= 0.0f) {
            UpdateText();
        }

    }


    void UpdateText() {
        ThisText.text = "Helloooooo";
        targetTime = 5.0f; // reset the timer
    }



    IEnumerator GetRequest(string uri) {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri)) {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError) {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }
        }
    }




}