using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    private float rand;
    public int enemyAmount = 10;

    void Start()
    {
        
        // spawns enemies that can be bigger than the player
        for (int i = 0; i < enemyAmount; i++)
        {
            enemy.tag = "enemy";
            SpawnEnemy(0.5f, 5.0f, -30.0f, 30.0f);
        }
        // spawns enemies that are the size or smaller than the player
        for (int i = 0; i < enemyAmount / 2; i++)
        {
            enemy.tag = "enemy";
            SpawnEnemy(0.5f, 1.0f, -30.0f, 30.0f);
        }
    }


    #region Spawn Enemy Function
    /// <summary>
    /// Spawns one enemy with a random size and a random position.
    /// </summary>
    /// <param name="minScale">Set a value to determine the minimum Enemy Scale</param>
    /// <param name="maxScale">Set a value to determine the maximum Enemy Scale</param>
    /// <param name="spawnX">Set a Value to determine the minumum X position</param>
    /// <param name="spawnY">Set a Value to determine the maximum Y position</param>

    public void SpawnEnemy(float minScale, float maxScale, float spawnX, float spawnY)
    {
        rand = Random.Range(minScale, maxScale);
        enemy.transform.localScale = new Vector3(rand, rand, 0);

        Instantiate(enemy, new Vector3(Random.Range(spawnX, spawnY), Random.Range(spawnX, spawnY), 0), Quaternion.identity);
    }

    #endregion Spawn Enemy Function
}