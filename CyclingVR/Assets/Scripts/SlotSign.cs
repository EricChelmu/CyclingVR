using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotSign : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Stop Sign")
        {
            other.transform.position = new Vector3(-7.96f, -2.59f, -55.44f);
            other.transform.rotation = new Quaternion(0, 90, 0, 0);
            GameObject CheckerNodeObject = GameObject.FindGameObjectWithTag("CheckerNode");
            Node CheckerNodeScript = CheckerNodeObject.GetComponent<Node>();
            CheckerNodeScript.isStopSign = true;
            CheckerNodeScript.isPrioritySign = false;
        }
        if (other.gameObject.name == "Priority Sign")
        {
            other.transform.position = new Vector3(-7.96f, -2.59f, -55.44f);
            other.transform.rotation = new Quaternion(0, 90, 0, 0);
            GameObject CheckerNodeObject = GameObject.FindGameObjectWithTag("CheckerNode");
            Node CheckerNodeScript = CheckerNodeObject.GetComponent<Node>();
            CheckerNodeScript.isPrioritySign = true;
            CheckerNodeScript.isStopSign = false;
        }
    }
}
