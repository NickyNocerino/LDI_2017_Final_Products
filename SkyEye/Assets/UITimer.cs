using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour {
    private Text time;
	// Use this for initialization
	void Start () {
        time = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        time.text = (int)Time.time / 60 + ":" + (int)Time.time % 60;
	}
}
