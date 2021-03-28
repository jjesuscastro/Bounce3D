using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControllerRB : MonoBehaviour
{
    [Header("Third Person Camera")]
    public Transform cam;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    [Header("Movement")]
    public float speed = 10f;
    public float jumpForce = 3f;
    bool isGrounded;
    bool _jump;
    float horizontal;
    float vertical;

    Vector3 checkpoint;
    Rigidbody rBody;
    SphereCollider sphereCollider;
    Animator animator;

    void Awake()
    {
        checkpoint = transform.position;
        rBody = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rBody.MovePosition(rBody.position + (moveDir * speed * Time.deltaTime));
        }

        if (_jump)
        {
            rBody.velocity += (Vector3.up * jumpForce);
            _jump = false;
        }

        GroundCheck();
    }

    void GetInput()
    {
        if (InputCheck.isInputEnabled)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                _jump = true;
            }
        }
        else
        {
            horizontal = vertical = 0;
        }
    }

    void GroundCheck()
    {
        // Will need to change groundcheck with another object
        Debug.DrawRay(transform.position, Vector3.down, Color.green, sphereCollider.radius + 0.2f);
        if (Physics.Raycast(transform.position, Vector3.down, sphereCollider.radius + 0.2f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Interactable"))
        {
            Interactable interactable = other.gameObject.GetComponent<Interactable>();
            if (interactable != null)
                interactable.Interact();

            if (interactable is Obstacle)
            {
                transform.SetParent(null);
                transform.position = checkpoint;
                animator.Play("Damage");
            }
            else if (interactable is Diamond)
            {
                checkpoint = interactable.transform.position;
            }
        }
    }
}
