using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Traffic[] trafficParticipant;

    [SerializeField]
    private bool IsSpawner = false;
    private int randomParticipant;

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
           randomParticipant = Random.Range(0, 2);
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
        Traffic newParticipant = Instantiate(trafficParticipant[randomParticipant], transform.position, Quaternion.identity);
        Node currentNode = GetComponent<Node>();
        newParticipant.targetNode = currentNode.PickNextNode();
    }
}
