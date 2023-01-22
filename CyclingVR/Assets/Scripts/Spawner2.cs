using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    [SerializeField]
    private Traffic[] trafficParticipant;
    private Traffic newParticipant;
    [SerializeField]
    private bool IsSpawner = false;
    public bool firstVehicleStopped2 = false;
    private int randomParticipant;
    private List<Traffic> newTrafficParticipantList = new List<Traffic>();
    private float timer = 0;
    private GameObject CheckerNodeObject;
    private Node CheckerNodeScript;

    // Start is called before the first frame update
    void Start()
    {
        CheckerNodeObject = GameObject.FindGameObjectWithTag("CheckerNode2");
        CheckerNodeScript = CheckerNodeObject.GetComponent<Node>();
        if (IsSpawner)
        {
            StartCoroutine(SpawnAtIntervals());
        }
    }
    void Update()
    {
        Debug.Log(timer);
        randomParticipant = Random.Range(0, 2);
        if (timer <= 9.5)
            timer += Time.deltaTime;
        if (timer >= 9.5 && timer != 10)
        {
            CheckerNodeScript.isStopSign = true;
            timer = 10;
        }
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
        if (!CheckerNodeScript.isStopSign)
        {
            newParticipant = Instantiate(trafficParticipant[randomParticipant], transform.position, Quaternion.identity);
            newTrafficParticipantList.Add(newParticipant);
            Node currentNode = GetComponent<Node>();
            newParticipant.targetNode = currentNode.PickNextNode();
        }

    }
}
