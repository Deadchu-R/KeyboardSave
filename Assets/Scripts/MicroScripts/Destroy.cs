using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject gameObj; // declare a gameobject to distroy
    public float destroyTime; // an float to declare how much time to wait until destroy
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObj, destroyTime); // will destroy the gameObject afer an "destroyTime" seconds
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
