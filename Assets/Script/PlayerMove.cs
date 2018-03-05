using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 0.2f;
    [SerializeField] float travel;

    void Update()
    {

        
        

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

        if (travel <= 0)
        {
            travel = 0;
        }

        if (Input.GetMouseButton(0))
        {
            travel += 0.4f;
        }

        for (int i = 0; i < travel; i++)
        {
            transform.position -= transform.up * speed;
            
        }

        if (mousePos.x > 0)
        {
            angle = 360 - angle;
        }
        transform.rotation = Quaternion.Euler(0, 180, angle);

        Debug.Log(angle);
        travel -= 0.2f;

    }



}
