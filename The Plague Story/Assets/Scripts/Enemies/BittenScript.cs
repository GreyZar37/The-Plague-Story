using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BittenScript : MonoBehaviour
{
    // Start is called before the first frame update

    EnemyController enemyController;
    Animator animator;

    bool playerNearBy;
    public bool wasBitten;

 

    Rigidbody2D rb2D;

    private void Start()
    {
        enemyController = GetComponent<EnemyController>();
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if(this.gameObject.name == "FarmerLeft")
        {
            wasBitten = DataSaver.bittenLeftFarmer;

        }
        if(this.gameObject.name == "FarmerRight")
        {
            wasBitten = DataSaver.bittenRightFarmer;
        }


    }

    void Update()
    {
        if (Input.GetMouseButton(0) && playerNearBy == true && enemyController.working == true && PlayerController.attacking == true)
        {
            wasBitten = true;
            if (wasBitten == false)
            {
                enemyController.lastXposistion = gameObject.transform.position.x;
            }



            if (this.gameObject.name == "FarmerLeft")
            {

                DataSaver.bittenLeftFarmer = true;

            }
            if (this.gameObject.name == "FarmerRight")
            {
                DataSaver.bittenRightFarmer = true;
            }


            rb2D.velocity = Vector2.right * 6;

            animator.SetBool("WasBitten", true);
            animator.speed = 1.25f;
        } 
      
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
       
            playerNearBy = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            playerNearBy = false;

        }
    }
}
