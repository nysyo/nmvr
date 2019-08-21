using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Vector3 position;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = position + player.transform.position;
        if (Input.GetKeyDown(KeyCode.Space)) { transform.Rotate(0, 90, 0); }
    }
}
