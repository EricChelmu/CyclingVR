using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Traffic[] trafficParticipant;
    private Traffic newParticipant;
    [SerializeField]
    private bool IsSpawner = false;
    public bool firstVehicleStopped = false;
    private int randomParticipant;
    public List<Traffic> newTrafficParticipantList = new List<Traffic>();

    // Start is called before the first frame update
    void Start()
    {
        if (IsSpawner)
        {
            StartCoroutine(SpawnAtIntervals());
        }
    }
    void Update()
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
        GameObject CheckerNodeObject = GameObject.FindGameObjectWithTag("CheckerNode");
        Node CheckerNodeScript = CheckerNodeObject.GetComponent<Node>();
        if (!CheckerNodeScript.isStopSign)
        {
            newParticipant = Instantiate(trafficParticipant[randomParticipant], transform.position, Quaternion.identity);
            newTrafficParticipantList.Add(newParticipant);
            Node currentNode = GetComponent<Node>();
            newParticipant.targetNode = currentNode.PickNextNode();
        }
        
    }
}
