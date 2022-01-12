using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint startPoint, endPoint;
    // Start is called before the first frame update
    Queue<Waypoint> queue = new Queue<Waypoint>();
    Waypoint searchPoint;
    [SerializeField] bool isRunning = true;
    public List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
    };

    public List<Waypoint> GetPath()
    {
        if(path.Count == 0)
        {
            LoadBlocks();
            SetColorStartAndEnd();
            PathFindAlgorythm();
            CreatePath();
        }

        return path;
    }

    private void CreatePath()
    {
        path.Add(endPoint);
        Waypoint prevPoint = endPoint.exploredFrom;
        while(prevPoint != startPoint){
            prevPoint.SetTopColor(Color.yellow);
            path.Add(prevPoint);
            prevPoint = prevPoint.exploredFrom;
        }
        path.Add(startPoint);
        path.Reverse();
    }

    private void PathFindAlgorythm()
    {
        queue.Enqueue(startPoint);
        while(queue.Count > 0 && isRunning == true)
        {
            searchPoint = queue.Dequeue();
            searchPoint.isExplored = true;
            CheckForEndPoint();
            ExploreNearPoints();
        }
    }

    private void CheckForEndPoint()
    {
        if(searchPoint == endPoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNearPoints()
    {
        if(!isRunning)
        {
            return;
        }

        foreach(Vector2Int direction in directions)
        {
            Vector2Int nearPointCoordinates = searchPoint.GetGridPos() + direction;
            try
            {
                Waypoint nearPoint = grid[nearPointCoordinates];
                AddPointToQueue(nearPoint);
            }
            catch
            {
            }
        }
    }

    private void AddPointToQueue(Waypoint nearPoint)
    {
        if(nearPoint.isExplored || queue.Contains(nearPoint))
        {
            return;
        }

        nearPoint.exploredFrom = searchPoint;
        queue.Enqueue(nearPoint);
    }

    private void SetColorStartAndEnd()
    {
        startPoint.SetTopColor(Color.green);
        endPoint.SetTopColor(Color.cyan);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach(var wp in waypoints)
        {
            var gridPosition = wp.GetGridPos();
            bool isOverlapping = grid.ContainsKey(gridPosition);
            if(isOverlapping)
            {
                Debug.LogWarning($"Overlapping {wp}");
            }
            else{
                
                grid.Add(gridPosition, wp);
                wp.SetTopColor(Color.black);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
