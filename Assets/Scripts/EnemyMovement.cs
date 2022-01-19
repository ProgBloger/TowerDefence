using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    PathFinder pathFinder;
    [SerializeField] float speed = 0.5f;
    [SerializeField] float moveStep;
    Castle castle;
    Vector3 targetPosition;
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
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime*moveStep);
    }

    IEnumerator EnemyMove(List<Waypoint> path)
    {
        foreach(var block in path)
        {
            transform.LookAt(block.transform);

            targetPosition = block.transform.position;
            
            yield return new WaitForSeconds(speed);
        }
        var enemyDamage = GetComponent<EnemyDamage>();
        enemyDamage.BlowUpCastle();
        castle.DamageCastle();
    }
}
