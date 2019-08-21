using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody rig;
    public GameObject maincamera;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float y = 0;
        if (Input.GetKeyDown(KeyCode.RightShift)) { y = 10; }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, speed*y, moveVertical);
        rig.AddForce(movement * speed, ForceMode.Impulse);
        y = 0;

        transform.eulerAngles = new Vector3(0, maincamera.transform.eulerAngles.y, 0);
    }
}
