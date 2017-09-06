using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class SimpleSmoothMouseLook : MonoBehaviour
{
    Vector2 _mouseAbsolute;
    Vector2 _smoothMouse;

    public Vector2 clampInDegrees = new Vector2(360, 180);
    public bool lockCursor;
    public Vector2 sensitivity = new Vector2(2, 2);
    private Camera maincam;
    public float speed;
    public float speedcap;
    public float speedmin;
    public float acc;
    // Assign this if there's a parent object controlling motion, such as a Character Controller.
    // Yaw rotation will affect this object instead of the camera if set.
    public GameObject characterBody;

    void Start()
    {
        maincam = Camera.main;
    }

    void Update()
    {
        maincam.transform.position = transform.position;
        maincam.transform.rotation = transform.rotation;
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        print(mousePos);
        int screenx = Screen.width;
        int screeny = Screen.height;
        //print("x:" + screenx + "y:" + screeny);
       
        
        transform.Rotate(Vector3.up * sensitivity.x *(mousePos.x -(screenx / 2 ))/100* Time.deltaTime);
        transform.Rotate(Vector3.left * sensitivity.y * (mousePos.y - (screeny / 2)) / 100 * Time.deltaTime);
        if (Input.GetKey(KeyCode.UpArrow) && speed < speedcap)
        {
            speed += acc;
        }
        if (Input.GetKey(KeyCode.DownArrow) && speed > speedmin)
        {
            speed -= acc;
        }
        // Ensure the cursor is always locked when set
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0), 10f * Time.deltaTime);
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel(0);
            
        }
    }
}