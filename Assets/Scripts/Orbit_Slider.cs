using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Orbit_Slider : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider orbitSlider;
    public Text orbitSliderText;

    // Need a reference to all other objects
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      orbitSliderText.text = "Orbit Speed (Multiplier: " +  orbitSlider.value.ToString() + ')';
      var OrbitObjects = FindObjectsOfType<Orbit_Behaviour>();
      for(int i = 0; i < OrbitObjects.Length; i++){
        OrbitObjects[i].SliderMultiplier = orbitSlider.value;
      }
        
    }
}
