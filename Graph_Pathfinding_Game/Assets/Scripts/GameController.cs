using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public delegate void OnClickListener(Vector2 position);

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
        graph.Find(position);
        Debug.Log("Click" + position.x+ ","+position.y);
    }

    public Graph<Vector2> graph;
    void Start()
    {
        graph = CreateGraph.Instance.graph;
    }

    void Update()
    {
        
    }
}
