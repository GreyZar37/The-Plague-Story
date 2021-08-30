using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KokScript : MonoBehaviour
{
    bool playerNearby;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("WasBitten", DataSaver.kokWasBitten);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerNearby)
        {
            DataSaver.kokWasBitten = true;
          
            animator.SetBool("WasBitten", DataSaver.kokWasBitten);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
