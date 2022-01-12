using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 20f)] float spawnInterval;
    [SerializeField] EnemyMovement enemyPrefab;
    void Start()
    {
        // launch co program
        StartCoroutine(EnemySpawn());
    }

    // create co program of the spawner
    IEnumerator EnemySpawn()
    {
        // load infinity spawn cycle
        while(true)
        {
            // add enemy to scene
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            // wait 
            yield return new WaitForSeconds(spawnInterval);
            print($"After {spawnInterval} sec");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
