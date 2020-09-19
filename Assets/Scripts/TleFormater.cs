using System;
using UnityEngine;
using System.Collections.Generic;
using sc = Satellite_cs;

public class TleFormater {


    public Tuple <string, string> getIssTle(byte[] bytes){
         // Just return the first 3 lines
        string buff = System.Text.Encoding.UTF8.GetString(bytes);
        string[] arr = buff.Split('\n');
       
        int zarya = 0;
        int zaryaTLE1 = 1;
        int zaryaTLE2 = 2;
        string retVal = arr[zarya] + "\n " + arr[zaryaTLE1] + "\n " + arr[zaryaTLE2];

        // var tleStrings = Tuple <string, string>;
        return Tuple.Create(arr[zaryaTLE1],  arr[zaryaTLE2]);
        
    }

     public Dictionary <string, sc.Satellite_cs> getSatelliteList(byte[] bytes){
         // Just return the first 3 lines
        string buff = System.Text.Encoding.UTF8.GetString(bytes);
        string[] arr = buff.Split('\n');

        Dictionary <string, sc.Satellite_cs> satelliteList = new Dictionary<string, sc.Satellite_cs>();

        for(int i = 0; i+3 < arr.Length; i=i+3){

          

          string satName = arr[i];

          if (satelliteList.ContainsKey(satName)) {
            continue; // fix for multiple ISS DEB.. TODO: check why
          }


          string satLine1 = arr[i+1];
          string satLine2 = arr[i+2];

          sc.Satellite_cs nextTle = new sc.Satellite_cs(satLine1,satLine2);
          
          satelliteList.Add(satName, nextTle);
        }

        return satelliteList;
        
    }

}


