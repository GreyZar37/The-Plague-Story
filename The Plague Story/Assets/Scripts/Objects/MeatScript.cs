using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatScript : MonoBehaviour
{
    
    bool playerNearBy;
    Animator animtor;

    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        animtor = gameObject.GetComponent<Animator>();
        if(DataSaver.eatenMeatPile == true)
        {
            animtor.SetTrigger("Eaten");
        }
        
    }

    // Update is called once per frame
    void Update()
    {

     
        if(playerNearBy == true && Input.GetMouseButtonDown(0))
        {
            animtor.SetTrigger("Eaten");
            DataSaver.eatenMeatPile = true;
            Destroy(wall);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
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
