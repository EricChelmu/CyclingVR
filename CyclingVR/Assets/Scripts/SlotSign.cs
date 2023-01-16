using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotSign : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Stop Sign")
        {
            other.transform.position = new Vector3(0, 0, 0);
            Debug.Log("position moved");
        }
    }
}
