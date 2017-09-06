using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingFP : MonoBehaviour {
    private Camera maincam;
    private AudioSource aud;
    public float steerSpeed;
    public float speed;
    public float speedcap;
    public float speedmin;
    public float acc;
	// Use this for initialization
	void Start () {
        maincam = Camera.main;
        aud = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        maincam.transform.position = transform.position;
        maincam.transform.rotation = transform.rotation;
        if(Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.left * steerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.right * steerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * steerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * steerSpeed * Time.deltaTime);
        }
        transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow)&& speed<speedcap)
        {
            speed += acc;
        }
        if (Input.GetKey(KeyCode.DownArrow) && speed > speedmin)
        {
            speed -= acc;
        }
        if (transform.rotation.z!=0 && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0), 10f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel(0);

        }
    }
}
