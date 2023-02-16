using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Traffic[] trafficParticipant;
    private Traffic newParticipant;
    [SerializeField] private bool IsSpawner = false;
    public bool firstVehicleStopped = false;
    private int randomParticipant;
    private List<Traffic> newTrafficParticipantList = new List<Traffic>();

    // Start is called before the first frame update
    void Start()
    {
        if (IsSpawner)
        {
            StartCoroutine(SpawnAtIntervals());
        }
    }
    void FixedUpdate()
    {
           randomParticipant = Random.Range(0, 3);
    }

    IEnumerator SpawnAtIntervals()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(3);
        }
    }
    void Spawn()
    {
        //Find the node that checks for signs
        GameObject CheckerNodeObject = GameObject.FindGameObjectWithTag("CheckerNode");
        Node CheckerNodeScript = CheckerNodeObject.GetComponent<Node>();
        //The traffic will only spawn if the checker node is not a stop sign, to prevent stacking of cars at the beginning of the road
        if (!CheckerNodeScript.isStopSign)
        {
            newParticipant = Instantiate(trafficParticipant[randomParticipant], transform.position, Quaternion.identity);
            newTrafficParticipantList.Add(newParticipant);
            Node currentNode = GetComponent<Node>();
            newParticipant.targetNode = currentNode.PickNextNode();
        }
        
    }
}
