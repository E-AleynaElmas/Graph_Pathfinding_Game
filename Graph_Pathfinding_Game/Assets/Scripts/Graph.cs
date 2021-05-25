using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph<T>
{
    List<GraphNode<T, GameObject>> nodes = new List<GraphNode<T, GameObject>>();

    public Graph(){}

    public int Count
    {
        get { return nodes.Count; }
    }

    public List<GraphNode<T, GameObject>> Nodes
    {
        get { return nodes; }
    }

    public void Clear()
    {
        foreach(GraphNode<T, GameObject> node in nodes)
        {
            node.RemoveAllNeighbors();
        }

        for(int i= nodes.Count - 1; i >= 0; i--)
        {
            nodes.RemoveAt(i);
        }
    }

    public bool AddNode (T value)
    {
        if(Find(value) != null)
        {
            return false;
        }
        else
        {
            nodes.Add(new GraphNode<T, GameObject>(value));
            return true;
        }
    }

    public bool AddEdge(GraphNode<T, GameObject> node1, GraphNode<T, GameObject> node2)
    {
        if(node1 == null || node2 == null)
        {
            return false;
        }
        else if (node1.Neighbors.Contains(node2))
        {
            return false;
        }
        else
        {
            node1.AddNeighbor(node2);
            node2.AddNeighbor(node1);
            return true;
        }
    }

    public bool RemoveNode(T value)
    {
        GraphNode<T, GameObject> removeNode = Find(value);
        if(removeNode == null)
        {
            return false;
        }
        else
        {
            nodes.Remove(removeNode);
            foreach(GraphNode<T, GameObject> node in nodes)
            {
                node.RemoveNeighbor(removeNode);
            }
            return true;
        }
    }

    public bool RemoveEdges(T value1, T value2)
    {
        GraphNode<T, GameObject> node1 = Find(value1);
        GraphNode<T, GameObject> node2 = Find(value2);

        if (node1 == null || node2 == null)
        {
            return false;
        }
        else if (!node1.Neighbors.Contains(node2))
        {
            return false;
        }
        else
        {
            node1.RemoveNeighbor(node2);
            node2.RemoveNeighbor(node1);
            return true;
        }
    }

    public GraphNode<T, GameObject> Find(T value)
    {
        foreach(GraphNode <T, GameObject> node in nodes)
        {
            if (node.Value.Equals(value))
            {
                return node;
            }
        }
        return null;
    }
}

