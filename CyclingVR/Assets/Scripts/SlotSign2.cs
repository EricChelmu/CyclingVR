using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotSign2 : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        //Check which sign is doing the collision
        if (other.gameObject.name == "Stop Sign2")
        {
            other.transform.position = new Vector3(7.56f, -2.61f, -40.06f);
            other.transform.rotation = new Quaternion(0, -90, 0, 0);
            GameObject CheckerNodeObject = GameObject.FindGameObjectWithTag("CheckerNode2");
            Node CheckerNodeScript = CheckerNodeObject.GetComponent<Node>();
            CheckerNodeScript.isStopSign = true;
            CheckerNodeScript.isPrioritySign = false;
        }
        //Check which sign is doing the collision
        if (other.gameObject.name == "Priority Sign2")
        {
            other.transform.position = new Vector3(7.56f, -2.61f, -40.06f);
            other.transform.rotation = new Quaternion(0, -90, 0, 0);
            GameObject CheckerNodeObject = GameObject.FindGameObjectWithTag("CheckerNode2");
            Node CheckerNodeScript = CheckerNodeObject.GetComponent<Node>();
            CheckerNodeScript.isPrioritySign = true;
            CheckerNodeScript.isStopSign = false;
        }
    }
}
