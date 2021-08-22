using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{


    public float speed;
    public float horizontal;

    public float jumpForce;
    private bool isGrounded;
    public Transform feetPosistion;
    public float checkRadius;

    public LayerMask ground;

    Animator animator;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosistion.position, checkRadius, ground);
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        flip();
    }

    void flip()
    {
        if(horizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(horizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);

        }
    }
}
