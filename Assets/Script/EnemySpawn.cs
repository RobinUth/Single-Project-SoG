using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(enemy, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        }
    }
}