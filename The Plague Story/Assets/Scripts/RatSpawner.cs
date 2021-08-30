using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawner : MonoBehaviour
{
    public GameObject ratPrefab;

    float currenTimer;
    float cooldown = 0.2f;

    float starttimer = 15f;

    public GameObject credits;

    // Update is called once per frame
    void Update()
    {
        if(EndGameScript.ending == true)
        {
            starttimer -= Time.deltaTime;
            if (starttimer <= 0)
            {
                currenTimer -= Time.deltaTime;
                if (currenTimer <= 0)
                {

                    Instantiate(ratPrefab, transform.position, transform.rotation);
                    currenTimer = cooldown;
                    credits.SetActive(true);

                }
            }
        }
      
        
    }
}
