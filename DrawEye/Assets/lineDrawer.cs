using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class lineDrawer : MonoBehaviour {
    public Transform start;
    public bool done;
    public GameObject node;
    public GameObject win;
    public GameObject lose;
    public int numTargets;
    public bool go;
    private bool stop;
    public GameObject[] good;
    public GameObject[] bad;
    private Vector3 mouse;
    List<GameObject> nodes = new List<GameObject>();
    private GameObject temp;
    private PolygonCollider2D poly;
    private Vector3 mospos;
    // Use this for initialization
    void Start () {
        go = false;
        stop = false;
        poly = GetComponent<PolygonCollider2D>();
        done = false;
        mospos = Input.mousePosition;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 pos = Input.mousePosition;
       // print(Camera.main.ScreenToWorldPoint(pos));
        mouse = Camera.main.ScreenToWorldPoint(pos);
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKeyDown("space"))
        {
            Application.LoadLevel(0);
        }
        if ((Vector3.Distance(start.position, mouse))<10.05f&&!stop)
        {
            //print(Vector3.Distance(start.position, mouse));
            stop = true;
            StartCoroutine(StartCheck());
        }
        if(go&& mospos!=Input.mousePosition)
        {
            print("created");
            temp = (GameObject)(Instantiate(node));
            temp.transform.position =(Vector2) mouse;
            nodes.Add(temp);
            //temp.transform.position = mouse;


        }
        else if(!go)
        {
            if(nodes.Count>3&&!done)
            {
                Vector2[] path = new Vector2[nodes.Count];
                for (int i = 0; i < nodes.Count; i++)
                {
                    path[i] = nodes[i].transform.position;
                }
                poly.pathCount = 1;
                poly.SetPath(0, path);
                poly.isTrigger = true;
                if (poly.OverlapPoint(good[0].transform.position)&&!poly.OverlapPoint(bad[0].transform.position)&& poly.OverlapPoint(good[1].transform.position) && !poly.OverlapPoint(bad[1].transform.position)&& poly.OverlapPoint(good[2].transform.position) && !poly.OverlapPoint(bad[2].transform.position)&& poly.OverlapPoint(good[3].transform.position) && !poly.OverlapPoint(bad[3].transform.position))
                {
                    print("win");
                    temp= (GameObject) Instantiate(win);
                    temp.transform.position = Vector3.zero;
                    done = true;
                }
                else
                {
                    print("lose");
                    temp = (GameObject)Instantiate(lose);
                    temp.transform.position = Vector3.zero;
                    done = true;
                }
            }
        }
        mospos = Input.mousePosition;
	}
    IEnumerator StartCheck()
    {
        print(Time.time);
        yield return new WaitForSeconds(2.2f);
        if (Vector3.Distance(start.position, mouse) < 10.05f)
        {
            go = !go;
            print(go);
        }
        print(Time.time);
        stop = false;
    }
}
