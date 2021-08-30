using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatRunner : MonoBehaviour
{
    float currentTimer = 10;
   

    // Update is called once per frame
    void Update()
    {
        currentTimer -= Time.deltaTime;
        transform.Translate(4 * Time.deltaTime, 0, 0) ;  
        if(currentTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
