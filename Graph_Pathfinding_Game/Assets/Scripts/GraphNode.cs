using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GraphNode<T, GameObject>
{
    T value;
    GameObject obj;
    List<GraphNode<T, GameObject>> neighbors;

    public GraphNode(T value)
    {
        this.value = value;
        neighbors = new List<GraphNode<T, GameObject>>();
    }
    
    public T Value
    {
        get { return value; }
    }

    public void SetObj(GameObject obj)
    {
        this.obj = obj;
    }

    public List<GraphNode<T, GameObject>> Neighbors
    {
        get { return neighbors; }
    }

    public bool AddNeighbor (GraphNode<T, GameObject> neighbor)
    {
        if (neighbors.Contains(neighbor))
        {
            return false;
        }
        else
        {
            neighbors.Add(neighbor);
            return true;
        }
    }

    public bool RemoveNeighbor(GraphNode<T, GameObject> neighbor)
    {
        return neighbors.Remove(neighbor);
    }

    public bool RemoveAllNeighbors()
    {
        for(int i = neighbors.Count - 1; i >= 0; i--)
        {
            neighbors.RemoveAt(i);
        }
        return true;
    }
}

