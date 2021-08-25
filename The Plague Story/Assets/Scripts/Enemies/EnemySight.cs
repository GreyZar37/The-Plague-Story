using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    // Start is called before the first frame update

    public float distance;

    public Transform[] targetPositions;
    public Transform lookTransform;
    int chooseTarget;
    bool isMoving = true;

    public float speed = 2f;

    void Start()
    {
        chooseTarget = Random.Range(0, targetPositions.Length);

        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPositions[chooseTarget].position, speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            giveNewTarget();
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
    }
}
