using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnter : MonoBehaviour
{
    SceneController sceneController;

    public string levelToLoad;

    public string startPosition;


    bool playerNearBy;


    void Start()
    {
        
        sceneController = GameObject.FindObjectOfType<SceneController>();
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) && playerNearBy == true)
        {
            PlayerController.houseStartPosition = startPosition;
            DataSaver.houseEnter = true;
            sceneController.FadeToLevel(levelToLoad);
            PlayerController.enteringHouse = true;
            PlayerController.rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
     

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            playerNearBy = true;
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            playerNearBy = false;
        }
    }

}
