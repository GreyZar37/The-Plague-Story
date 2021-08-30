using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeBackground : MonoBehaviour
{

    public Sprite[] sprites;
    public AudioSource audioSource;
    public AudioClip fire;
    public AudioClip ambient;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name == "Village")
        {
            if (DataSaver.workerWasBitten == false && DataSaver.kokWasBitten == false)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
                audioSource.PlayOneShot(ambient);
            }
            else if (DataSaver.workerWasBitten == true && DataSaver.kokWasBitten == false)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
              
            }
            else if (DataSaver.workerWasBitten == true && DataSaver.kokWasBitten == true)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
                audioSource.PlayOneShot(fire);
            }

        }
        else if(SceneManager.GetActiveScene().name == "Road")
        {
            if (DataSaver.workerWasBitten == true && DataSaver.kokWasBitten == true)
            {
                audioSource.PlayOneShot(fire);
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
