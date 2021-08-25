using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    Animator animator;

    public float distance;

    public Transform[] targetPositions;
    public Transform lookTransform;
    int chooseTarget;
    bool isMoving = true;
    bool working;
    float distanceFromTarget;

    float lastXposistion;

    public float speed = 2f;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        lastXposistion = gameObject.transform.position.x;
        chooseTarget = Random.Range(0, targetPositions.Length);

        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {


        flip();
        animator.SetBool("Working", working);

        if (isMoving == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2 (targetPositions[chooseTarget].position.x,transform.position.y), speed * Time.deltaTime);
        }


        distanceFromTarget = transform.position.x - targetPositions[chooseTarget].position.x;
        if (distanceFromTarget == 0)
        {
            working = true;
        }


        RaycastHit2D hitInfo = Physics2D.Raycast(lookTransform.position, transform.right, distance);
        if (hitInfo.collider != null)
        {
            Debug.DrawLine(lookTransform.position, hitInfo.point, Color.red);
        }
        else
        {
            Debug.DrawLine(lookTransform.position, lookTransform.position + transform.right * distance, Color.green);

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
}
