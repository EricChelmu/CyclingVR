using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField]
    private List<Node> nodes;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Node PickNextNode()
    {
        if (nodes.Count != 0)
        {
            return nodes[Random.Range(0, nodes.Count)];
        }
        return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 0.2f);

        foreach (var node in nodes)
        {
            Gizmos.DrawLine(transform.position, node.transform.position);
        }
    }
}

