using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGraph : MonoBehaviour
{
    public static CreateGraph Instance;

    public GameObject nodePrefab;
    public Graph<Vector2> graph = new Graph<Vector2>();
    public GameObject lastNode;

    [SerializeField]
    int nodeCount = 20;

    int maxNeighborCount = 3;
    int desiredNeighborCount = 2;

    private List<GameObject> graphObjList = new List<GameObject>();
    private int neighborsCounter;
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
        SetDeActive();
        lastNode = graph.Nodes[graph.Count - 1].Obj();
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
            node.SetObj(obj);
            graphObjList.Add(obj);
            obj.transform.parent = transform;
            LineColorEdit(obj);
        }
    }

    private void Create()
    {
        for (int i = 0; i < nodeCount; i++)
        {
            float x = Random.Range(-2, 2);
            float y = Random.Range(-4, 4);
            graph.AddNode(new Vector2(x, y));
        }

        for (int i = 0; i < graph.Count; i++)
        {
            int rnd = desiredNeighborCount;

            neighborsCounter = 0;
            while (graph.Nodes[i].Neighbors.Count < rnd && neighborsCounter < nodeCount)
            {
                var node = graph.Nodes[Random.Range(0, graph.Nodes.Count)];
                neighborsCounter++;
                if (node.Neighbors.Count < maxNeighborCount)
                {
                    graph.AddEdge(graph.Nodes[i], node);

                }
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

    private void SetDeActive()
    {
        graphObjList[0].SetActive(true);

        for (int i = 0; i < graphObjList[0].transform.childCount; i++)
        {
            GameObject child = graphObjList[0].transform.GetChild(i).gameObject;
            child.SetActive(false);
        }

        for (int i = 1; i < graphObjList.Count; i++)
        {
            graphObjList[i].SetActive(false);
            for (int j = 0; j < graphObjList[i].transform.childCount; j++)
            {
                GameObject child = graphObjList[i].transform.GetChild(j).gameObject;
                child.SetActive(false);
            }
        }
    }

    public void Restart()
    {
        ClickDetection.clickCounter = 0;
        Clear();
        graphObjList.Clear();
        graph.Clear();
        Start();
    }

    private void Clear()
    {
        for(int i = 0; i < graphObjList.Count; i++)
        {
            Destroy(graphObjList[i]);
        }
    }

}
