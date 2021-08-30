using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontDestoryGameobject : MonoBehaviour
{

    bool playOnce;
    
    // Start is called before the first frame update
    void Start()
    {
       
        if (DataSaver.firstTimeAudio == true)
        {
            DontDestroyOnLoad(gameObject);
            DataSaver.firstTimeAudio = false;
        }
        else
        {
            Destroy(gameObject);
        }
       
       
    }

    
    // Update is called once per frame
    void Update()
    {
       if(SceneManager.GetActiveScene().name == "Death")
        {
            gameObject.GetComponent<AudioSource>().Stop();
            playOnce = false;
        }
       else if(playOnce == false)
        {
            gameObject.GetComponent<AudioSource>().Play();
            playOnce = true;
           
        }


       if(EndGameScript.ending == true)
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }


}
