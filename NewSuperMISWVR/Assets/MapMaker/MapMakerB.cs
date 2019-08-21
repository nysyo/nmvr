using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMakerB : MonoBehaviour
{
    private GameObject[] typeA;
    private GameObject[] typeB;
    private int TypeSize = 2;
    private int n;
    // Start is called before the first frame update
    void Start()
    {
        typeA = new GameObject[2];
        typeB = new GameObject[2];
        typeA[0] = (GameObject)Resources.Load("TypeA");
        typeB[0] = (GameObject)Resources.Load("TypeB");
        typeA[1] = (GameObject)Resources.Load("TypeA1");
        typeB[1] = (GameObject)Resources.Load("TypeB1");
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
    private void OnTriggerEnter(Collider collision)
    {
        GameObject parent;
        if (collision.gameObject.tag == "Player")
        {
            parent = gameObject.transform.parent.gameObject;
            transform.parent = null;
            Destroy(parent);
            PutSet();
            GetComponent<BoxCollider>().enabled = false;
        }

    }
    //置くやつを決める
    private void PutSet()
    {
        n = Random.Range(0, TypeSize);
        switch (Random.Range(1, 6))
        {
            case 1:
                //B5-1
                Putting(true, 16.9f, 0, 22, 90);
                B3all();
                B4Nall();
                break;
            case 2:
                //B5-2
                Putting(true, -24.9f, 0, 22, 90);
                B3Nall();
                B4all();
                break;
            case 3:
                //B5-3
                Putting(false, -14.9f, 2.3f, 30, -90);
                B3all();
                B4all();
                break;
            case 4:
                //B5-4
                Putting(false, 4.9f, 2.3f, 20, 90);
                B3all();
                B4all();
                break;
            default:
                //B5-5
                Putting(false, -10, 0, 24, 180);
                B3all();
                B4all();
                break;
        }

    }
    //B3-all
    private void B3all()
    {
        switch (Random.Range(1, 6))
        {
            case 1:
                //B3-1
                Putting(true, -28, -2.5f, 12, 0);
                break;
            case 2:
                //B3-2
                Putting(true, -28, -2.5f, -29.8f, 0);
                break;
            case 3:
                //B3-3
                Putting(false, 16, 0, -19.8f, 180);
                break;
            case 4:
                //B3-4
                Putting(false, -26, 0, 0, 0);
                break;
            default:
                //B3-5
                Putting(false, -30, -2.3f, -14.9f, 90);
                break;
        }
    }
    //B4-all
    private void B4all()
    {
        switch (Random.Range(1, 6))
        {
            case 1:
                //B4-1
                Putting(true, 18, -2.5f, -31.8f, 180);
                break;
            case 2:
                //B4-2
                Putting(true, 18, -2.5f, 10, 180);
                break;
            case 3:
                //B4-3
                Putting(false, 26, 0, 0, 0);
                break;
            case 4:
                //B4-4
                Putting(false, 16, 0, -19.8f, 180);
                break;
            default:
                //B4-5
                Putting(false, 20, -2.3f, -4.9f, -90);
                break;
        }
    }
    //B3-not all
    private void B3Nall()
    {
        switch (Random.Range(1, 5))
        {
            case 1:
                //B3-2
                Putting(true, -28, -2.5f, -29.8f, 0);
                break;
            case 2:
                //B3-3
                Putting(false, 16, 0, -19.8f, 180);
                break;
            case 3:
                //B3-4
                Putting(false, -26, 0, 0, 0);
                break;
            default:
                //B3-5
                Putting(false, -30, -2.3f, -14.9f, 90);
                break;
        }
    }
    //B4-not all
    private void B4Nall()
    {
        switch (Random.Range(1, 5))
        {
            case 1:
                //B4-1
                Putting(true, 18, -2.5f, -31.8f, 180);
                break;
            case 2:
                //B4-3
                Putting(false, 26, 0, 0, 0);
                break;
            case 3:
                //B4-4
                Putting(false, 16, 0, -19.8f, 180);
                break;
            default:
                //B4-5
                Putting(false, 20, -2.3f, -4.9f, -90);
                break;
        }
    }
    private void Putting(bool type, float x, float y, float z, int a)
    {
        if (type)
        {
            GameObject newmap = Instantiate(typeA[n]) as GameObject;
            newmap.transform.parent = transform;
            newmap.transform.localPosition = new Vector3(x, y, z);
            newmap.transform.localEulerAngles = new Vector3(0, a, 0);
        }
        else
        {
            GameObject newmap = Instantiate(typeB[n]) as GameObject;
            newmap.transform.parent = transform;
            newmap.transform.localPosition = new Vector3(x, y, z);
            newmap.transform.localEulerAngles = new Vector3(0, a, 0);
        }
    }
}
