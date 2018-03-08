using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    #region Player Movement Variables


    public float speed = 0.2f;
    [SerializeField] float travel;
    public float maxSpeed = 2;
    public float travelMultiuplier = 0.2f;
    public float slowOut = 0.95f;
    private Rigidbody playerRB;
    public Transform Player;

    GameObject enemySpawner;
    

    #endregion


    // world Camera



    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner");


    }


    void Update()
    {

        // testing / increasing size of player
        if (Input.GetMouseButton(1))
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0);
        }

        // distance to be traveled
        if (Input.GetMouseButton(0))
        {
            travel += travelMultiuplier;
            transform.localScale -= new Vector3(travelMultiuplier / 10, travelMultiuplier / 10, 0);
           // enemySpawner.GetComponent<EnemySpawn>().SpawnEnemy(travel, travel, playerRB.transform.position.x, playerRB.transform.position.y);
        }

        // lose condition
        if (transform.localScale.y <= 0)
        {
            Debug.Log("bene Benedikt Kirchmeier");
        }



        //transform.Rotate(new Vector3())

        //.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed);
    }


    private void FixedUpdate()
    {

        #region Angle Testing
      

        /*
        var v3 = Input.mousePosition;

        v3 = Camera.main.ScreenToWorldPoint(v3);
        Debug.Log(v3);
        transform.LookAt(new Vector3(0, 0, v3.z));

        //*/
        

        #endregion



        Vector3 mousePos = Input.mousePosition;

        mousePos.x -= Screen.width / 2;
        mousePos.y -= Screen.height / 2;

        mousePos += transform.position;
        var angle = Vector3.Angle(mousePos, Vector3.up);



        if (mousePos.x > 0)
        {
            angle = 360 - angle;
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);

        //Debug.Log(angle);
        travel *= slowOut;
        //Debug.Log(Vector3.Angle(new Vector3(playerRB.transform.position.x, playerRB.transform.position.y), Input.mousePosition));



        //transform.LookAt(Player);


        // condition to stop player moving
        if (travel <= 0.1)
        {
            travel = 0;
        }

        // condition for player not beeing too fast
        if (travel >= 4)
        {
            travel = maxSpeed;
        }

        // player movement
        for (int i = 0; i < travel; i++)
        {
            transform.position -= transform.up * speed;

            // playerRB.velocity = Vector3.up * speed;

        }
    }

}




