using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMakerA : MonoBehaviour
{
    private GameObject[] typeA;
    private GameObject[] typeB;
    private int TypeSize = 2;
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
        int n = Random.Range(0, TypeSize);
        switch (Random.Range(1, 6))
        {
            case 1:
                //A1-1
                Putting(true, n, 20, 0, -43.8f, 180);
                switch (Random.Range(2, 6))
                {
                    case 2:
                        //A2-2
                        Putting(true, n, 20, 0, 39.8f, 180);
                        break;
                    case 3:
                        //A2-3
                        Putting(false, n, 28, 2.5f, 29.8f, 0);
                        break;
                    case 4:
                        //A2-4
                        Putting(false, n, 18, 2.5f, 10, 180);
                        break;
                    default:
                        //A2-5
                        Putting(false, n, 22, 0, 24.9f, -90);
                        break;
                }
                break;
            case 2:
                //A1-2
                Putting(true, n, 20, 0, -2, 180);
                //A2-1
                break;
            case 3:
                //A1-3
                Putting(false, n, 28, 2.5f, -12, 0);
                switch (Random.Range(2, 5))
                {
                    case 2:
                        //A2-2
                        Putting(true, n, 20, 0, 39.8f, 180);
                        break;
                    case 3:
                        //A2-3
                        Putting(false, n, 28, 2.5f, 29.8f, 0);
                        break;
                    default:
                        //A2-4
                        Putting(false, n, 18, 2.5f, 10, 180);
                        break;
                }
                break;
            case 4:
                //A1-4
                Putting(false, n, 18, 2.5f, -31.8f, 180);
                switch (Random.Range(2, 6))
                {
                    case 2:
                        //A2-2
                        Putting(true, n, 20, 0, 39.8f, 180);
                        break;
                    case 3:
                        //A2-3
                        Putting(false, n, 28, 2.5f, 29.8f, 0);
                        break;
                    case 4:
                        //A2-4
                        Putting(false, n, 18, 2.5f, 10, 180);
                        break;
                    default:
                        //A2-5
                        Putting(false, n, 22, 0, 24.9f, -90);
                        break;
                }
                break;
            default:
                //A1-5
                Putting(false, n, 22, 0, -16.9f, -90);
                switch (Random.Range(2, 5))
                {
                    case 2:
                        //A2-2
                        Putting(true, n, 20, 0, 39.8f, 180);
                        break;
                    case 3:
                        //A2-3
                        Putting(false, n, 28, 2.5f, 29.8f, 0);
                        break;
                    default:
                        //A2-5
                        Putting(false, n, 22, 0, 24.9f, -90);
                        break;
                }
                break;
        }
        
    }
    private void Putting(bool type,int n,float x,float y,float z,int a)
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