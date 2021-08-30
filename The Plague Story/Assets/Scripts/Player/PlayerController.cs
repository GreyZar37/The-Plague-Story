using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Transform feetPosistion;

    public float speed;
    public float horizontal;

    float jumpForce = 6f;
    private bool isGrounded;
    public float checkRadius;

    public static bool enteringHouse = false;

    public bool hidden;

    public bool movingToNextLocation;
    public bool movingToPosition = true;

    public static bool attacking;
    float attackCooldown = 1.25f;
    public  float currentAttackTimer;

    public LayerMask ground;

    Animator animator;
    public static Rigidbody2D rb;

    Transform startPos, targetPos;
    Transform startPosHouse;

    public static string targetposistion = "leftTarget";
    public static string startPosition = "leftStart";

    public static string houseStartPosition = "DoorOneStart";

    public AudioClip bite;
    public AudioClip run;

    AudioSource audioSource;

    // Start is called before the first frame update

    
    void Start()
    {
        
        enteringHouse = false;
        hidden = false;
        audioSource = GetComponent<AudioSource>();

        if (DataSaver.houseEnter == true)
        {
            movingToPosition = false;
        }
        currentAttackTimer = attackCooldown;
        if(targetposistion == "leftTarget")
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (DataSaver.houseEnter == false)
        {
            targetPos = GameObject.Find(targetposistion).transform;
            startPos = GameObject.Find(startPosition).transform;
        }
        else
        {
            startPosHouse = GameObject.Find(houseStartPosition).transform;
        }
       


       

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if(DataSaver.houseEnter == false)
        {
            transform.position = startPos.position;
          
        }
        else
        {
            transform.position = startPosHouse.position;
         
           
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        
        if (DataSaver.houseEnter == false)
        {
         if(targetPos != null)
            {
                if (transform.position.x - targetPos.position.x == 0)
                {

                    movingToPosition = false;
                    animator.SetFloat("Speed", 0);
                }
            }
           
        }

        



            if (movingToPosition == true)
        {
            animator.SetFloat("Speed", 0.1f);
            if (DataSaver.houseEnter == false)
            {
                rb.position = Vector2.MoveTowards(rb.position, new Vector2(targetPos.position.x, rb.position.y), 4 * Time.fixedDeltaTime);
                
            }
           
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
                else  if(attacking == false && enteringHouse == false)
                {
                    rb.constraints = RigidbodyConstraints2D.None;
                    rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
                horizontal = Input.GetAxis("Horizontal");
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
           

                if(enteringHouse == false)
                {
                    animator.SetFloat("Speed", Mathf.Abs(horizontal));
                }
                else if(enteringHouse == true)
                {
                    hidden = true;
                    animator.SetFloat("Speed", 0);
                }

            }
        }
           
    }
    private void Update()
    {
        if (EndGameScript.ending == true)
        {
            this.gameObject.GetComponent<PlayerController>().enabled = false;
        }
        currentAttackTimer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && currentAttackTimer <= 0)
        {
            currentAttackTimer = attackCooldown;
            audioSource.PlayOneShot(bite);
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

    void playSound()
    {
        audioSource.PlayOneShot(run);
    }

}
