﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowCondition2D : MonoBehaviour
{
    public float growScale = 0.2f;
    public float shrinkScale = 0.2f;


    private void Update()
    {
        if (transform.localScale.x <= 0)
        {


            Destroy(gameObject);
            Debug.Log("destroyed");
        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {

        
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
    }
    */


    private void OnCollisionStay2D(Collision2D collision)
    {
         

         if (transform.localScale.magnitude > collision.transform.localScale.magnitude)
        {
            transform.localScale += new Vector3(growScale, growScale, 0);
            collision.transform.localScale -= new Vector3(shrinkScale, shrinkScale, 0);
        }

        // bigger
        if (transform.localScale.magnitude < collision.transform.localScale.magnitude)
        {
            transform.localScale -= new Vector3(shrinkScale, shrinkScale, 0);
            collision.transform.localScale += new Vector3(growScale, growScale, 0);
        }

        if (transform.localScale.magnitude < collision.transform.localScale.magnitude)
        {
            Debug.Log(transform.localScale.magnitude);
            Debug.Log(collision.transform.localScale.magnitude);

        }

    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogWarning("Collision!Trigger" + gameObject.tag);
        // smaller


        if (transform.localScale.magnitude > other.transform.localScale.magnitude)
        {
            transform.localScale += new Vector3(growScale, growScale, 0);
            other.transform.localScale -= new Vector3(shrinkScale, shrinkScale, 0);
        }

        // bigger
        if (transform.localScale.magnitude < other.transform.localScale.magnitude)
        {
            transform.localScale -= new Vector3(shrinkScale, shrinkScale, 0);
            other.transform.localScale += new Vector3(growScale, growScale, 0);
        }

        if (transform.localScale.magnitude < other.transform.localScale.magnitude)
        {
            Debug.Log(transform.localScale.magnitude);
            Debug.Log(other.transform.localScale.magnitude);

        }



    } */



}
