using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstackleConroler : MonoBehaviour
{

    [SerializeField]
     Obstacle[] obstacles = null;


    public void   ShatterAllObstacle()
    {
        if (transform.parent != null)
        { 
         transform.parent = null;
        }

        foreach(Obstacle item  in obstacles)
        {
            item.Shatter();

        }
        StartCoroutine(RemoveAllSahtterPart());
    }

    IEnumerator RemoveAllSahtterPart()
    {
        yield return new  WaitForSeconds(1);
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
