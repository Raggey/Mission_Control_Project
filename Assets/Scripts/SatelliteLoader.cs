using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SatelliteLoader : MonoBehaviour
{

    private IEnumerator getRequest;

    public TleFormater tle = new TleFormater();

    public Dictionary <string, Satellite_cs.Satellite_cs> satelliteList; // Use catalog number and object 

    string celestTrack = "https://celestrak.com/NORAD/elements/stations.txt";

    float targetTime = 1;

    void Start()
    {
        // Load TLE Dynamically 
        getRequest = GetRequest(celestTrack);
        StartCoroutine(getRequest);

    }

    // Update is called once per frame
    void Update()
    {

      targetTime -= Time.deltaTime; //Delta Time is time between last frame update? 

      if (targetTime <= 0.0f) {
        // Update the ISS coords

        // calculateCurrentSatellitePosition(line1,line2);
        targetTime = 1;
      }
        
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
        
        // Create a dict of satellite objects
        satelliteList = tle.getSatelliteList(bytes);

      }
    }

  }
}
