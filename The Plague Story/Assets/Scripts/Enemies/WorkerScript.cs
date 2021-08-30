using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerScript : MonoBehaviour
{
    bool playerNearby;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("WasBitten", DataSaver.workerWasBitten);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerNearby)
        {
            DataSaver.workerWasBitten = true;
            animator.SetBool("WasBitten", DataSaver.workerWasBitten);
        }  
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerNearby = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerNearby = false;

        }
    }
}
