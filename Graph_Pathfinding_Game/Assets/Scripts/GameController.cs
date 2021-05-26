using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public delegate void OnClickListener(Vector2 position);

    public Graph<Vector2> graph;

    void Start()
    {
        graph = CreateGraph.Instance.graph;
    }

    private void OnEnable()
    {
        ClickDetection.Click += OnClick;
    }
    private void OnDisable()
    {
        ClickDetection.Click -= OnClick;
    }

    private void OnClick(Vector2 position)
    {
        List<GameObject> neighbors = graph.Find(new Vector2(position.x, position.y)).NeighborsObj();
        SetActiveNeighbors(neighbors);
        Debug.Log("Click" + position.x+ ","+position.y);
    }

    private void SetActiveNeighbors(List<GameObject> neighbors)
    {
        for(int i = 0; i < neighbors.Count; i++)
        {
            neighbors[i].gameObject.SetActive(true);
        }
    }    
}
