using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Waypoint : MonoBehaviour
{
    Vector2Int gridPos;
    const int gridSize = 10;
    public bool isPlacable = true;
    public bool isExplored = false;
    public Waypoint exploredFrom;

    [SerializeField] GameObject tower;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetScenePos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize) * gridSize, 
            Mathf.RoundToInt(transform.position.z / gridSize) * gridSize);
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize), 
            Mathf.RoundToInt(transform.position.z / gridSize));
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(isPlacable)
            {
                var towerFactory = FindObjectOfType<TowerFactory>();
                towerFactory.AddTower(this);
            }
        }
        else
        {
            Debug.Log($"Turret can not be placed");
        }
    }
}
