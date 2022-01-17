using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 4;
    int towerCount = 0;
    [SerializeField] Tower towerPrefab;

    // Towers Queue
    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        print("Tower Factory Adding Tower!");
        towerCount = towerQueue.Count;
        if(towerCount < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveTowerToNewPosition(baseWaypoint);
        }
    }

    public void InstantiateNewTower(Waypoint baseWaypoint)
    {
        baseWaypoint.isPlacable = false;

        var wpPosition = baseWaypoint.transform.position;
        var newTower = Instantiate(towerPrefab, wpPosition, Quaternion.identity);

        // Set baseWaypoint
        newTower.baseWaypoint = baseWaypoint;
        // Add Tower to Queue
        towerQueue.Enqueue(newTower);
    }

    public void MoveTowerToNewPosition(Waypoint newBaseWaypoint)
    {
        // Remove from Queue the first Tower
        var oldTower = towerQueue.Dequeue();

        // Change the Tower position
        oldTower.transform.position = newBaseWaypoint.transform.position;
        // Set isPlaceable to true
        oldTower.baseWaypoint.isPlacable = true;
        newBaseWaypoint.isPlacable = false;
        // Set baseWaypoint
        oldTower.baseWaypoint = newBaseWaypoint;

        // Add to the end of Queue 
        towerQueue.Enqueue(oldTower);
    }
}
