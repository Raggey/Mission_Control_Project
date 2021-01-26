using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start_Sim : MonoBehaviour {

    public Button startSimButton;

    // Start is called before the first frame update
    void Start() {
        Button btn = startSimButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick() {
        Debug.Log("BUtton Clicked");
        StartCoroutine(SolarSystemAsync());
    }

    IEnumerator SolarSystemAsync() {
     
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Solar_System");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }


}
