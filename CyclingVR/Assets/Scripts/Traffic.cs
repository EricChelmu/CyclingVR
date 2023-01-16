using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traffic : MonoBehaviour
{
    public Node targetNode { get; set; }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetNode.transform.position, 5 * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetNode.transform.position) == 0)
        {
            targetNode = targetNode.PickNextNode();
        }
        if (!targetNode)
        {
            Destroy(gameObject);
        }
        transform.LookAt(targetNode.transform.position);
    }
}
