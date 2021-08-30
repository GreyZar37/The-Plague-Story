using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialDestory : MonoBehaviour
{
    public GameObject[] destoryTutorialObjects;
    public GameObject openTutorial;



    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.transform.tag == "Player")
        {
            if (this.gameObject.name == "EndColider Move")
            {
                openTutorial.SetActive(true);
              
            }

            if (this.gameObject.name == "EndColider Villagers")
            {
                DataSaver.secondToturialFinished = true;

            }


            if (this.gameObject.name == "EndColider Tutorial")
            {
                DataSaver.firstToturialFinished = true;;
            }
            
            if (this.gameObject.name == "EndColider City")
            {
                DataSaver.thirdToturialFinished = true; ;
            }

            Destroy(destoryTutorialObjects[0]);

        }
    }
   
}
