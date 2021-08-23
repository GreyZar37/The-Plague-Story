using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{

    SceneController sceneController;

    public string levelToLoad;
    public string moveToTarget;

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
        if(collision.tag == "Player")
        {
            Movement.targetposistion = targetPosition;
            Movement.startPosition = startPosition;
            player.GetComponent<Movement>().movingToNextLocation = true;
            sceneController.FadeToLevel(levelToLoad);
        }
    }

}
