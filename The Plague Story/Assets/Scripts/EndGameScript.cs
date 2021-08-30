using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera Camera;
    public static bool ending;
    public Transform toFollow;

    public AudioSource playerAudio;
    
// Start is called before the first frame update
void Start()
    {

        if(DataSaver.kokWasBitten == true && DataSaver.workerWasBitten == true)
        {
            playerAudio.enabled = false;
            ending = true;
            
            gameObject.GetComponent<AudioSource>().Play();
            
            Camera.Follow = toFollow;
        }
    }

   
}
