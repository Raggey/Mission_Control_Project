using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit_Behaviour : MonoBehaviour
{
    public float xSpread; //Distance we move on X axis
    public float zSpread;
    public float yOffset; //Camera offset
    public Transform centerPoint;

    public float numOfYears; //Rotation speed
    public float SliderMultiplier = 1; //HUD Slider
    public bool rotateClockwise;

    float timer = 0;


    // Update is called once per frame
    void Update(){
        timer += ((Time.deltaTime) * (1/numOfYears)) * SliderMultiplier;
        Rotate();
        transform.LookAt(centerPoint);
    }


    void Rotate() {
        if (rotateClockwise){
            float x = -Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + centerPoint.position;
        }
        else {
            float x = Mathf.Cos(timer) * xSpread; 
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + centerPoint.position;
        }
    }

}





