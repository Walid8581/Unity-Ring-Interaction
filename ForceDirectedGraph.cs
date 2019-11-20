using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ForceDirectedGraph : MonoBehaviour
{
    // Name of the input file, no extension
    //public string filename;

    // List for holding data from CSV reader
    public string filename;
    public List<Node> nodes;
   // public float plotScale = 10;
    public float desiredConnectedNodeDistance = 1;
    public float ConnectedNodeForce = 1;
    public float disconnectedNodeForce = 1;


    // The prefab for the data points that will be instantiated
    // public GameObject PointPrefab;

    // Object which will contain instantiated prefabs in hiearchy
    //public GameObject PointHolder;
    //public List<Node> nodes;
    // Start is called before the first frame update
    void Start()
    {
        TextAsset Cardata = Resources.Load<TextAsset>("CarMovement");
        string[] nodes = Cardata.text.Split(new char[] { '\n' });

        //pointList = CSVReader.Read(filename);

        /*nodes = new List<Node>();
        for (int i = 1; i < nodes.Length; i++)
        {
            nodes.Add(new Node() { children = nodes.Where(node => Random.value> 0.5f).ToList(), position= Random.insideUnitSphere*10, velocity= Vector3.zero});
        }*/
    }
   
    // Update is called once per frame
    void Update()
    {
        ApplyGraphForce();

        foreach (var node in nodes)
        {

            node.position += node.velocity * Time.deltaTime;
               
        }  
    }

    private void ApplyGraphForce()
    {
        foreach (var node in nodes)
        {
            var disconnectedNodes = nodes.Except(node.children);
            foreach (var connectedNode in node.children)
            {
                var difference = node.position - connectedNode.position;
                var distance = (difference).magnitude;
                var appliedForce = ConnectedNodeForce * Mathf.Log10(distance / desiredConnectedNodeDistance);
                connectedNode.velocity += appliedForce * Time.deltaTime * difference.normalized; 
            }

            foreach (var disconnectedNode in disconnectedNodes)
            {
                var difference = node.position - disconnectedNode.position;
                var distance = (difference).magnitude;
                if (distance != 0)
                {
                    var appliedForce = disconnectedNodeForce / Mathf.Pow(distance, 2);
                    disconnectedNode.velocity += appliedForce * Time.deltaTime * difference.normalized;
                }
            }
        }

    }
    private void OnDrawGizmos()
    {
        foreach (var node in nodes)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(node.position, 0.125f);
            Gizmos.color = Color.green;
            foreach (var connectedNode in node.children)
            {

                Gizmos.DrawLine(node.position, connectedNode.position);
            }
        
        }
    }
}
public class Node
{
    public Vector3 position;
    public Vector3 velocity;
    public List<Node> children;




}
