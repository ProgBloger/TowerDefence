using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    PathFinder pathFinder;
    void Start()
    {
        pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(EnemyMove(path));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemyMove(List<Waypoint> path)
    {
        print("Enemy started moving");
        foreach(var block in path)
        {
            transform.LookAt(block.transform);
            transform.position = block.transform.position;
            
            print($"Enemy moved to {block.ToString()}");
            yield return new WaitForSeconds(2f);
        }
        print("Enemy finished moving");
    }
}
