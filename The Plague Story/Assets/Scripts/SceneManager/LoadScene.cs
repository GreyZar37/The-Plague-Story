using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{

    SceneController sceneController;

    public string levelToLoad;

    public string targetPosition;
    public string startPosition;

    GameObject player;

    void Start()
    {
        sceneController = GameObject.FindObjectOfType<SceneController>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && player.GetComponent<PlayerController>().movingToPosition == false)
        {
            PlayerController.targetposistion = targetPosition;
            PlayerController.startPosition = startPosition;
            player.GetComponent<PlayerController>().movingToNextLocation = true;
            sceneController.FadeToLevel(levelToLoad);
        }
    }

}
