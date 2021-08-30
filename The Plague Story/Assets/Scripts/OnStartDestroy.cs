using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnStartDestroy : MonoBehaviour
{
    public GameObject tutorialOne;
    public GameObject tutorialTwo;
    public GameObject tutorialThree;

    public GameObject[] ObjectsToDestory;
    // Start is called before the first frame update

    private void Start()
    {
        if (DataSaver.firstToturialFinished == true)
        {
            Destroy(tutorialOne);
        }

        if (DataSaver.secondToturialFinished == true)
        {
            Destroy(tutorialTwo);
        }

        if (DataSaver.eatenMeatPile == true)
        {
            if(SceneManager.GetActiveScene().name == "Forrest")
            {
                Destroy(ObjectsToDestory[0]);
            }
          
        }


            if (SceneManager.GetActiveScene().name == "Road")
            {
                if(DataSaver.bittenLeftFarmer == true)
                {
                    Destroy(ObjectsToDestory[0]);
                }
                if (DataSaver.bittenRightFarmer == true)
                {
                    Destroy(ObjectsToDestory[1]);
                
                }

            if (DataSaver.workerWasBitten == true && DataSaver.kokWasBitten == true)
            {
                Destroy(ObjectsToDestory[1]);
                Destroy(ObjectsToDestory[0]);
            }
        }

        if (SceneManager.GetActiveScene().name == "Village")
        {
            if (DataSaver.thirdToturialFinished == true)
            {
                Destroy(tutorialThree);
            }
            if(DataSaver.workerWasBitten == true)
            {
                Destroy(ObjectsToDestory[0]);
            }
            if (DataSaver.workerWasBitten == true && DataSaver.kokWasBitten == true)
            {
                Destroy(ObjectsToDestory[1]);
            }

        }
    }
}

