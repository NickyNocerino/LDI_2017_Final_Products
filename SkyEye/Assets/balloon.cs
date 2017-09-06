using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloon : MonoBehaviour {
    private bool pass;
    private bool check;
    private AudioSource aud;
    private MeshRenderer renderer;
	// Use this for initialization
	void Start () {
        pass = false;
        check = true;
        aud = GetComponent<AudioSource>();
        renderer = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseOver()
    {
        if(check)
        {
            StartCoroutine(TimeCheck());
        }
        if(pass)
        {
            aud.Play();
            renderer.enabled = false;
            print(gameObject.name);
            Object.Destroy(gameObject,2f);
        }
        
    }
    IEnumerator TimeCheck()
    {
        check = false;
        yield return new WaitForSeconds(.4f);
        pass = true;
        yield return new WaitForSeconds(.01f);
        pass = false;
        check = true;
    }
}
