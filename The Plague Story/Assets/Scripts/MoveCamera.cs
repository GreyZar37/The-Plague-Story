using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(EndGameScript.ending == true)
        {
            transform.Translate(0.3f * Time.deltaTime, 0, 0);
        }
       
      
    }
}
