using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform feetPosistion;

    public float speed;
    public float horizontal;

    public float jumpForce;
    private bool isGrounded;
    public float checkRadius;

    public bool movingToNextLocation;
    public bool movingToPosition = true;

    public LayerMask ground;

    Animator animator;
    Rigidbody2D rb;

    Transform startPos, targetPos;

    public static string targetposistion = "leftTarget";
    public static string startPosition = "leftStart";

    // Start is called before the first frame update
    void Start()
    {

        targetPos = GameObject.Find(targetposistion).transform;
        startPos = GameObject.Find(startPosition).transform;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        transform.position = startPos.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        print(movingToPosition);
        print(Mathf.Abs(transform.position.x - targetPos.position.x));

        if(transform.position.x - targetPos.position.x >= 0)
        {
            movingToPosition = false;
        }
        
        if(movingToPosition == true)
        {
            rb.position = Vector2.MoveTowards(rb.position, targetPos.position, 4 * Time.fixedDeltaTime);
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal");

            if (movingToNextLocation == true)
            {
                if (transform.eulerAngles == new Vector3(0, 0, 0))
                {
                    rb.velocity = Vector2.right * 4;
                }
                else if (transform.eulerAngles == new Vector3(0, 180, 0))
                {
                    rb.velocity = Vector2.right * -4;
                }
            }
            else
            {
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
                animator.SetFloat("Speed", Mathf.Abs(horizontal));
            }
        }
           
    }
    private void Update()
    {
        flip();
        isGrounded = Physics2D.OverlapCircle(feetPosistion.position, checkRadius, ground);
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
       
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
