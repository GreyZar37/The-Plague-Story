using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    Animator animator;

    public float distance;

    Transform playerTarget;
    public Transform[] targetPositions;
    public Transform lookTransform;
    int chooseTarget;
    bool chasing;
    bool working;
    float distanceFromPatrolTarget;
    float distanceFromPlayerTarget;

    float lastXposistion;

    public float walkSpeed = 2f;
    public float runSpeed = 5f;

    GameObject deathScreen;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        lastXposistion = gameObject.transform.position.x;
        chooseTarget = Random.Range(0, targetPositions.Length);
        playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Physics2D.queriesStartInColliders = false;
        deathScreen = GameObject.FindGameObjectWithTag("DeathScreen");
    }

    private void FixedUpdate()
    {
        if (chasing == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetPositions[chooseTarget].position.x, transform.position.y), walkSpeed * Time.deltaTime);
        }
       
        if (working == false)
        {

            RaycastHit2D hitInfo = Physics2D.Raycast(new Vector2(lookTransform.position.x, playerTarget.position.y), transform.right, distance);
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.tag == "Player")
                {
                    distanceFromPlayerTarget = Mathf.Abs(transform.position.x - playerTarget.position.x);
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerTarget.position.x, transform.position.y), runSpeed * Time.deltaTime);
                    chasing = true;
                    if (distanceFromPlayerTarget <= 1f)
                    {
                        deathScreen.transform.GetChild(0).transform.gameObject.SetActive(true);
                    }
                    Debug.DrawLine(lookTransform.position, hitInfo.point, Color.red);
                }
                else
                {
                    Debug.DrawLine(lookTransform.position, lookTransform.position + transform.right * distance, Color.green);
                    saveLastPosistion();
                    chasing = false;

                }
            }
            else
            {
                saveLastPosistion();
                chasing = false;
            }

        }
    }
    // Update is called once per frame
    void Update()
    {

        flip();
        animator.SetBool("Working", working);
        animator.SetBool("chasing", chasing);



       


        distanceFromPatrolTarget = transform.position.x - targetPositions[chooseTarget].position.x;
        if (distanceFromPatrolTarget == 0)
        {
            working = true;
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
        working = false;
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
