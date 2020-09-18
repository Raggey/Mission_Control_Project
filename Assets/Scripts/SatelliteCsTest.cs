using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

using Satellite_cs;

public class SatelliteCsTest : MonoBehaviour
{
    // Start is called before the first frame update



    private IEnumerator getRequest;

    public string line1;
    public string line2;

    public double longitude;
    public double latitude;

    public tleFormat tle = new tleFormat();

    float targetTime = 1;

    void Start()
    {

        // Load TLE Dynamically 
      
        string target = "https://celestrak.com/NORAD/elements/stations.txt";

        getRequest = GetRequest(target);

        StartCoroutine(getRequest);

        // Pass into functions 

        // Display debug for now 
        
    }

    private void Update() {

       targetTime -= Time.deltaTime; //Delta Time is time between last frame update? 

      if (targetTime <= 0.0f) {
        // Update the ISS coords
        generateTle(line1,line2);
      }
      
    }


    void generateTle(string line1, string line2){

        Satellite_cs.Satellite_cs iss = new Satellite_cs.Satellite_cs(line1,line2);
      
        Debug.Log("Long: " + iss.longitudeStr);
        Debug.Log("Lat: " + iss.latitudeStr);

        longitude =  iss.longitudeStr;
        latitude =  iss.latitudeStr;

    }


      public IEnumerator GetRequest(string uri) {
      using (UnityWebRequest webRequest = UnityWebRequest.Get(uri)) {
        // Request and wait for the desired page.
        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError) {
          Debug.Log("Error: " + webRequest.error);
        }
        else {

          byte[] bytes =  webRequest.downloadHandler.data;
          Tuple <string, string> issTleText = tle.getIssTle(bytes);

          line1 = issTleText.Item1;
          line2 = issTleText.Item2;

          // once the TLE has been returned, set it for the game object

          generateTle(line1,line2);


        }
      }

    }





}
