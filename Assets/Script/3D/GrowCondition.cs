﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowCondition : MonoBehaviour
{
    GameObject outline;
    GameObject enemy;
    public float growScale   = 0.2f;
    public float shrinkScale = 0.2f;
    Material Enemy;


    private void Start()
    {
        outline = GameObject.FindGameObjectWithTag("outline");
        enemy = GameObject.FindGameObjectWithTag("enemy");
    }


    private void Update()
    {
        if(transform.localScale.x <= 0)
        {


            Destroy(gameObject);
            Debug.Log("destroyed BENE BENEDIKT KIRCHMEIER ");
        }


        // color for enemies that are bigger
        if (Input.GetKeyDown(KeyCode.R))
        {
            Enemy.color = Color.red;
        }

        // color for enemies that are smaller
        if (Input.GetKeyDown(KeyCode.G))
        {
            Enemy.color = Color.red;
        }
    }


    
    private void OnCollisionStay(Collision collision)
    {

        
       
        //smaller

        if (transform.localScale.magnitude > collision.transform.localScale.magnitude && enemy == true)
        {
            transform.localScale += new Vector3(growScale, growScale, 0);
            collision.transform.localScale -= new Vector3(shrinkScale, shrinkScale, 0);
        }

        // bigger
        if (transform.localScale.magnitude < collision.transform.localScale.magnitude && enemy == true)
        {
            transform.localScale -= new Vector3(shrinkScale, shrinkScale, 0);
            collision.transform.localScale += new Vector3(growScale, growScale, 0);
        }

        if (transform.localScale.magnitude < collision.transform.localScale.magnitude)
        {
            Debug.Log(transform.localScale.magnitude);
            Debug.Log(collision.transform.localScale.magnitude);

        }
       
        /*
        
        Debug.LogWarning("Collision!Collision");
        // smaller
        if (transform.localScale.x < gameObject.transform.localScale.x && transform.localScale.y < gameObject.transform.localScale.y)
        {
            transform.localScale += new Vector3(growScale, growScale, 0);
        }

        // bigger
        if (transform.localScale.x > gameObject.transform.localScale.x && transform.localScale.y > gameObject.transform.localScale.y)
        {
            transform.localScale -= new Vector3(shrinkScale, shrinkScale, 0);
        }
        // */
    } 
    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("Collision!Trigger" + gameObject.tag);
        // smaller

        
        if (transform.localScale.magnitude > other.transform.localScale.magnitude && enemy == true)
        {
            transform.localScale += new Vector3(growScale, growScale, 0);
            other.transform.localScale -= new Vector3(shrinkScale, shrinkScale, 0);
        }

        // bigger
        if (transform.localScale.magnitude < other.transform.localScale.magnitude && enemy == true)
        {
            transform.localScale -= new Vector3(shrinkScale, shrinkScale, 0);
            other.transform.localScale += new Vector3(growScale, growScale, 0);
        }

        if (transform.localScale.magnitude < other.transform.localScale.magnitude)
        {
            Debug.Log(transform.localScale.magnitude);
            Debug.Log(other.transform.localScale.magnitude);

        }
        
        

    }
    // */

   

}
