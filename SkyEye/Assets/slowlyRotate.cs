﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowlyRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.down * 1f * Time.deltaTime);
    }
}
