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
        foreach(var block in path)
        {
            transform.LookAt(block.transform);
            transform.position = block.transform.position;
            
            yield return new WaitForSeconds(0.5f);
        }
    }
}
