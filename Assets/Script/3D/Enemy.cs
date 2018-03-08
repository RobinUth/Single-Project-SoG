using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Material material;
    Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        material = GetComponent<Renderer>().material;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // color for enemies that are bigger
        if (transform.localScale.x > player.localScale.x)
        {
            material.color = Color.red;
        }

        // color for enemies that are smaller
        if (transform.localScale.x < player.localScale.x)
        {
            material.color = Color.green;
        }
    
}
}
