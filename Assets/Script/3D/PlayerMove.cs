using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  # region Movement Variables


    public float speed = 0.2f;
    [SerializeField] float travel;
    public float maxSpeed = 2;
    public float travelMultiuplier = 0.2f;
    public float slowOut = 0.95f;
    private Rigidbody playerRB;

    GameObject enemySpawner;

    #endregion

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner");
    }
    void Update()
    {


        if (Input.GetMouseButton(1))
        {
            transform.localScale +=new Vector3(0.1f, 0.1f, 0);
        }

        // distance to be traveled
        if (Input.GetMouseButton(0))
        {
            travel += travelMultiuplier;
            transform.localScale -= new Vector3(travelMultiuplier/10, travelMultiuplier/10, 0);
            enemySpawner.GetComponent<EnemySpawn>().SpawnEnemy(travelMultiuplier, travelMultiuplier, playerRB.transform.position.x+1, playerRB.transform.position.y+1);
        }

        // lose condition
        if (transform.localScale.y <= 0)
        {
            Debug.Log("bene Benedikt Kirchmeier");
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

        if (travel <= 0.1)
        {
            travel = 0;
        }

        // 
        if (travel >= 4)
        {
            travel = maxSpeed;
        }
       

        for (int i = 0; i < travel; i++)
        {
            transform.position -= transform.up * speed;
           // playerRB.velocity = Vector3.up * speed;
            
        }

        if (mousePos.x > 0)
        {
            angle = 360 - angle;
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);

      //  Debug.Log(angle);
        travel *= slowOut;

    }



}
