using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 20f)] float spawnInterval;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] AudioClip enemySpwanSound;
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
            GetComponent<AudioSource>().PlayOneShot(enemySpwanSound);
            // add enemy to scene
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = transform;
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
