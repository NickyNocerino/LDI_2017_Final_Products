using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIballoon : MonoBehaviour {
    public int balloonNum;
    public GameObject[] balloons;
    public Text text;
    private bool done;
	// Use this for initialization
	void Start () {
        done = false;
	}
	
	// Update is called once per frame
	void Update () {
        int count = 0;
        for(int i=0;i<balloons.Length;i++)
        {
            if(balloons[i] != null)
            {
                count++;
            }
        }
		if(balloonNum> count)
        {
            Object.Destroy(gameObject);
        }
        if(count ==0&&!done)
        {
            text.text = "YOU WIN\nTime:\n" + (int)Time.time / 60 + ":" + (int)Time.time % 60;
            done = true;
        }
	}
}
