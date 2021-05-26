using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNode<T>
{
    T value;
    GameObject obj;
    List<GraphNode<T>> neighbors;

    public GraphNode(T value)
    {
        this.value = value;
        neighbors = new List<GraphNode<T>>();
    }
    
    public T Value
    {
        get { return value; }
    }

    public void SetObj(GameObject obj)
    {
        this.obj = obj;
    }

    public GameObject Obj()
    {
        return obj; 
    }

    public List<GameObject> NeighborsObj()
    {
        List<GameObject> neighborsObj = new List<GameObject>();
        for (int i = 0; i < neighbors.Count; i++)
        {
            neighborsObj.Add(neighbors[i].obj);
        }
        return neighborsObj;
    }

    public List<GraphNode<T>> Neighbors
    {
        get { return neighbors; }
    }

    public bool AddNeighbor (GraphNode<T> neighbor)
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

    public bool RemoveNeighbor(GraphNode<T> neighbor)
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

