﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2D : MonoBehaviour
{
    #region Movement Variables


    public float speed2D = 0.1f;
    [SerializeField] float travel2D;
    public float maxSpeed2D = 2;
    public float travelMultiuplier2D = 0.2f;
    public float slowOut2D = 0.95f;
    #endregion


    void Update()
    {
        

        if (Input.GetMouseButton(1))
        {
             transform.localScale += new Vector3(0.1f, 0.1f, 0);
           // transform.Translate(Vector3.right * )
        }

        // distance to be traveled
        if (Input.GetMouseButton(0))
        {
            travel2D += travelMultiuplier2D;

            
        }

        // lose condition
        if (transform.localScale.y <= 0)
        {
            Debug.Log("crying bene Benedikt Kirchmeier");
        }

        /*
         Vector3 mousePos = Input.mousePosition;

        //To make mousePos relative to center of screen
        mousePos.x -= Screen.width / 2;
        mousePos.y -= Screen.height / 2;

        //To make mousePos relative to transform
        mousePos += transform.position;
        var angle = Vector3.Angle(mousePos, Vector3.up);

        //For 360 degree angle
        if (mousePos.x < 0)
            angle = 360 - angle;

        transform.rotation = Quaternion.Euler(0, 0, angle);
        */
    }


    private void FixedUpdate()
    {

        Vector3 mousePos = Input.mousePosition;

        mousePos.x -= Screen.width / 2;
        mousePos.y -= Screen.height / 2;

        mousePos += transform.position;
        var angle = Vector3.Angle(mousePos, Vector3.up);

        if (travel2D <= 0.1)
        {
            travel2D = 0;
        }

        if (travel2D >= 4)
        {
            travel2D = maxSpeed2D;
        }


        for (int i = 0; i < travel2D; i++)
        {
            transform.position -= transform.up * speed2D;

        } 

        if (mousePos.x > 0)
        {
            angle = 360 - angle;
        }
        transform.rotation = Quaternion.Euler(0, 180, angle);

        //  Debug.Log(angle);
        travel2D *= slowOut2D;

    }



}
