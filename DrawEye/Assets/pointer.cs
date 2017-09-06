using UnityEngine;
using System.Collections;

public class pointer : MonoBehaviour {
    private Vector3 mouse;
    public Transform start;
    public lineDrawer spawner;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(pos);
        transform.position = (Vector2)mouse;
        if ((Vector3.Distance(start.position, mouse)) < 10.05f&& !spawner.go&& !spawner.done)
        {
            transform.Rotate(Vector3.forward);
        }
    }
}
