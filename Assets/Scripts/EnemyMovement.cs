using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    PathFinder pathFinder;
    [SerializeField] float speed = 0.5f;
    Castle castle;
    void Start()
    {
        castle = FindObjectOfType<Castle>();
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
            
            yield return new WaitForSeconds(speed);

            transform.position = block.transform.position;
        }
        var enemyDamage = GetComponent<EnemyDamage>();
        enemyDamage.BlowUpCastle();
        castle.DamageCastle();
    }
}
