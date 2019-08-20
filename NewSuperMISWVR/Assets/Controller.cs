using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
    private float StickToGroundForce;
    //そのままの重力加速度だとふわふわなので自然な動きにするために重力加速度を強くする
    private float MultipleGravity;
    [SerializeField] private float speed;

    private CharacterController CharacterController;
    private Vector2 inputSpeed;
    private Vector3 MoveDir;
    private CollisionFlags CollisionFlags;
    private Camera m_Camera;
    private Mouse MouseLook;
    // Use this for initialization
    void Start()
    {
        StickToGroundForce = 10f;
        MultipleGravity = 3f;
        speed = 10f;

        inputSpeed = new Vector2(0, 0);
        CharacterController = GetComponent<CharacterController>();
        m_Camera = Camera.main;
        MouseLook = GetComponent<Mouse>();
        MouseLook.Init(transform, m_Camera.transform);
    }

    // Update is called once per frame
    private void Update()
    {
        MouseLook.LookRotation(transform, m_Camera.transform);
    }

    //一定時間ごとに実行
    private void FixedUpdate()
    {
        GetInput();
        Vector3 desiredMove = transform.forward * inputSpeed.y + transform.right * inputSpeed.x;
        RaycastHit hitInfo;
        Physics.SphereCast(transform.position, CharacterController.radius, Vector3.down, out hitInfo,
                           CharacterController.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);

        MoveDir.x = desiredMove.x * speed;
        MoveDir.z = desiredMove.z * speed;

        if (CharacterController.isGrounded)
        {
            MoveDir.y = -StickToGroundForce;
        }
        else
        {
            MoveDir += Physics.gravity * MultipleGravity * Time.fixedDeltaTime;
        }
        CollisionFlags = CharacterController.Move(MoveDir * Time.fixedDeltaTime);

        MouseLook.UpdateCursorLock();
    }

    private void GetInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        inputSpeed = new Vector2(horizontal, vertical);

        //入力を標準ベクトルにする
        if (inputSpeed.sqrMagnitude > 1)
        {
            inputSpeed.Normalize();
        }
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (CollisionFlags == CollisionFlags.Below)
        {
            return;
        }
        if (body == null || body.isKinematic)
        {
            return;
        }
        body.AddForceAtPosition(CharacterController.velocity * 0.1f, hit.point, ForceMode.Impulse);
    }
}