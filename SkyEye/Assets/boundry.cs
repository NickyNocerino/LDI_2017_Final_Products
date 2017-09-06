using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boundry : MonoBehaviour {
    public Text message;
    // Use this for initialization
    void Start () {
       // message = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerExit(Collider other)
    {
        // other.transform.rotation.SetEulerRotation(-1 * other.transform.rotation.eulerAngles);
        print("triggerout");
        message.text = "OUT OF BOUNDS!";
    }
    void OnTriggerEnter(Collider other)
    {
        print("triggerin");
        message.text = "";
    }
}
