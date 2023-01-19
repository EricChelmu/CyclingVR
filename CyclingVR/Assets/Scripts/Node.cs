using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField]
    private List<Node> nodes;
    public bool isStopSign = false;
    public bool isPrioritySign = false;

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

