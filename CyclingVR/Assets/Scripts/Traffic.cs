using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traffic : MonoBehaviour
{
    public Node targetNode { get; set; }
    public Spawner spawner { get; set; }
    private Rigidbody rb;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //direction = targetNode.transform.position - transform.position;
        //transform.LookAt(targetNode.transform.position);
        if (!targetNode.isStopSign)
        {
            //transform.LookAt(targetPosition);

            //transform.position = Vector3.MoveTowards(transform.position, targetNode.transform.position, 5 * Time.deltaTime);
            Vector3 targetPosition = targetNode.transform.position;
            rb.MovePosition(Vector3.MoveTowards(transform.position, targetPosition, 25 * Time.deltaTime));
            targetPosition.y = transform.position.y;
            Vector3 lookTargetDirection = (targetNode.transform.position - transform.position).normalized;
            Vector3 currentDirection = transform.forward;
            float dotProduct = Vector3.Dot(lookTargetDirection, currentDirection);
            float angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

            if(Vector3.Dot(lookTargetDirection, transform.right) < 0)
                angle = -angle;

            transform.Rotate(0, angle * Time.deltaTime * 1.5f, 0);
            //if (lookTargetDirection.sqrMagnitude != 0)
            //{
            //    Quaternion lookDirection = Quaternion.LookRotation(lookTargetDirection, Vector3.up);
            //    transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, 0.01f);
            //}
        }
        //if (targetNode.isStopSign)
        //{

        //    rb.velocity = Vector3.zero;
        //    GameManager.Instance.firstVehicleStopped = true;
        //}
        if (Vector3.Distance(transform.position, targetNode.transform.position) <= 1.5 && !targetNode.isStopSign)
        {
            targetNode = targetNode.PickNextNode();
        }
        if (!targetNode)
        {
            Destroy(gameObject);
        }
    }
}
