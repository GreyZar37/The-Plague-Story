using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestoryGameobject : MonoBehaviour
{

    public GameObject[] saveGameobjects;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < saveGameobjects.Length; i++)
        {
            print(saveGameobjects[i].name);
            DontDestroyOnLoad(saveGameobjects[i]);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }


}
