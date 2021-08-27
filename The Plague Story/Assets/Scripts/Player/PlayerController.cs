using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform feetPosistion;

    public float speed;
    public float horizontal;

    public float jumpForce;
    private bool isGrounded;
    public float checkRadius;

    public bool movingToNextLocation;
    public bool movingToPosition = true;

    bool attacking;
    float attackCooldown = 1.25f;
    float currentAttackTimer;

    public LayerMask ground;

    Animator animator;
    Rigidbody2D rb;

    Transform startPos, targetPos;

    public static string targetposistion = "leftTarget";
    public static string startPosition = "leftStart";

    // Start is called before the first frame update
    void Start()
    {

        currentAttackTimer = attackCooldown;
        if(targetposistion == "leftTarget")
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
        targetPos = GameObject.Find(targetposistion).transform;
        startPos = GameObject.Find(startPosition).transform;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        transform.position = startPos.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {



        if(transform.position.x - targetPos.position.x == 0)
        {
            movingToPosition = false;
            animator.SetFloat("Speed", 0);
        }

        if (movingToPosition == true)
        {
            animator.SetFloat("Speed", 0.1f);
            rb.position = Vector2.MoveTowards(rb.position, new Vector2(targetPos.position.x, rb.position.y), 4 * Time.fixedDeltaTime);
        }
        else
        {
           

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
            else if(movingToNextLocation == false)
            {
                if(attacking == true)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                }
                else
                {
                    rb.constraints = RigidbodyConstraints2D.None;
                    rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
                horizontal = Input.GetAxis("Horizontal");
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
                animator.SetFloat("Speed", Mathf.Abs(horizontal));
            
            }
        }
           
    }
    private void Update()
    {
        currentAttackTimer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && currentAttackTimer <= 0)
        {
            currentAttackTimer = attackCooldown;
            attacking = true;
        }
        animator.SetBool("Attacking", attacking);

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
    void attackAnimDone()
    {
        attacking = false;
    }
}
