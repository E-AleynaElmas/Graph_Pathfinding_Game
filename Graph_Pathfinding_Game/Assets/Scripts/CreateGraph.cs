using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGraph : MonoBehaviour
{
    public static CreateGraph Instance;

    public GameObject nodePrefab;
    public Graph<Vector2> graph = new Graph<Vector2>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        else
            Instance = this;

    }

    void Start()
    {
        Create();
    }

    private void Draw()
    {
        int i = 0;
        foreach (var node in graph.Nodes)
        {
            GameObject obj = Instantiate(nodePrefab, new Vector3(node.Value.x, node.Value.y, 0), Quaternion.identity);
            obj.name = "node" + i;
            i++;
            
            foreach (var edge in node.Neighbors)
            {
                GameObject lineObj = new GameObject();
                lineObj.AddComponent<LineRenderer>();

                LineRenderer line = lineObj.GetComponent<LineRenderer>();
                line.material = new Material(Shader.Find("Sprites/Default"));

                // set width of the renderer
                line.startWidth = 0.05f;
                line.endWidth = 0.05f;

                // set the position
                line.SetPosition(0, new Vector3(node.Value.x, node.Value.y, 0));
                line.SetPosition(1, new Vector3(edge.Value.x, edge.Value.y, 0));

                lineObj.transform.parent = obj.transform;


            }
            obj.transform.parent = transform;
            LineColorEdit(obj);
        }
    }

    private void Create()
    {
        for (int i = 0; i < 20; i++)
        {
            float x = Random.Range(-2, 2);
            float y = Random.Range(-4, 4);
            graph.AddNode(new Vector2(x, y));
        }

        for (int i = 0; i < graph.Count; i++)
        {
            int rnd = Random.Range(2, 3);
            for (int j = 0; j < rnd; j++)
            {
                graph.AddEdge(graph.Nodes[i], graph.Nodes[Random.Range(0, graph.Nodes.Count)]);
            }
        }

        Draw();
    }

    private void LineColorEdit(GameObject node)
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        for (int i = 0; i < node.transform.childCount; i++)
        {
            LineRenderer rend = node.gameObject.transform.GetChild(i).GetComponent<LineRenderer>();           
            rend.startColor = randomColor;
            rend.endColor = randomColor;
        }
    }

}
