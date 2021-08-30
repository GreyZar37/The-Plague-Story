using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyControllerKnight : MonoBehaviour
{
    // Start is called before the first frame update

    Animator animator;

    public float distance;

    Transform playerTarget;
    GameObject Player;

    public Transform[] targetPositions;
    public Transform lookTransform;
    int chooseTarget;
    bool chasing;
    public bool looking;
    float distanceFromPatrolTarget;
    float distanceFromPlayerTarget;

    float distanceFromPlayer;
    Vector2 lookDirection;

    public float lastXposistion;

    public float walkSpeed = 2f;
    public float runSpeed = 5f;

    RaycastHit2D hitInfo;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        lastXposistion = gameObject.transform.position.x;
        chooseTarget = Random.Range(0, targetPositions.Length);
        Player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.queriesStartInColliders = false;
        playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (chasing == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetPositions[chooseTarget].position.x, transform.position.y), walkSpeed * Time.deltaTime);
        }
       
         

        if (Player.GetComponent<PlayerController>().hidden == false || chasing == true)
          {
          

            hitInfo = Physics2D.Raycast(new Vector2(lookTransform.position.x, playerTarget.position.y), lookDirection, distance);

            if (hitInfo.collider != null)
                {

                    if (hitInfo.collider.tag == "Player")
                    {
                        distance = 8;
                        distanceFromPlayerTarget = Mathf.Abs(transform.position.x - playerTarget.position.x);
                        transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerTarget.position.x, transform.position.y), runSpeed * Time.deltaTime);
                        chasing = true;
                        looking = false;
                        if (distanceFromPlayerTarget <= 1f)
                        {
                        SceneManager.LoadScene("Death");
                        }
                        Debug.DrawLine(lookTransform.position, hitInfo.point, Color.red);
                    }
                    else
                    {
                        Debug.DrawLine(lookTransform.position, lookTransform.position + transform.right * distance, Color.green);
                        saveLastPosistion();
                    if(this.gameObject.name == "Knight (1)")
                    {
                        distance = 4;
                    }
                        
                        if (chasing == true)
                        {
                            giveNewTarget();
                        }
                        chasing = false;

                    }
                }
 
               
             }
            else
            {
                saveLastPosistion();
                chasing = false;
            }

     
    }
    // Update is called once per frame
    void Update()
    {

        distanceFromPlayer = transform.position.x - playerTarget.position.x;

        if (looking == true)
        {
            if (distanceFromPlayer > 0)
            {

                lookDirection = new Vector2(-1,0);
            }
            if (distanceFromPlayer < 0)
            {
                lookDirection = new Vector2(1, 0);

            }

        }
        else
        {
          lookDirection = transform.right;
        }

        flip();
        animator.SetBool("Looking", looking);
        animator.SetBool("Chasing", chasing);



       


        distanceFromPatrolTarget = transform.position.x - targetPositions[chooseTarget].position.x;
        if (distanceFromPatrolTarget == 0)
        {
            looking = true;
        }
       

    }
    void giveNewTarget()
    {
        int newTarget = Random.Range(0, targetPositions.Length);
      
        while (chooseTarget == newTarget)
        {
            newTarget = Random.Range(0, targetPositions.Length);
        }
        chooseTarget = newTarget;
        lastXposistion = gameObject.transform.position.x;
        looking = false;
    }


    void flip()
    {
        if (gameObject.transform.position.x > lastXposistion)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (gameObject.transform.position.x < lastXposistion)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    void saveLastPosistion()
    {
        if (chasing == true)
        {
            lastXposistion = gameObject.transform.position.x;
        }
    }

  

}
