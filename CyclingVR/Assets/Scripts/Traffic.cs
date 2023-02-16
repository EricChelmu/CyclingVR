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
    void FixedUpdate()
    {
        //Initial code for making objects look at their target node
        //direction = targetNode.transform.position - transform.position;
        //transform.LookAt(targetNode.transform.position);
        if (!targetNode.isStopSign)
        {
            //transform.LookAt(targetPosition);

            //transform.position = Vector3.MoveTowards(transform.position, targetNode.transform.position, 5 * Time.deltaTime);

            Vector3 targetPosition = targetNode.transform.position;
            rb.MovePosition(Vector3.MoveTowards(transform.position, targetPosition, 10 * Time.deltaTime));
            targetPosition.y = transform.position.y;
            Vector3 lookTargetDirection = (targetNode.transform.position - transform.position).normalized;
            Vector3 currentDirection = transform.forward;
            float dotProduct = Vector3.Dot(lookTargetDirection, currentDirection);
            float angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

            //This makes sure the vehicles do not rotate more than they should, as without this they rotated forever 360 degrees
            if(Vector3.Dot(lookTargetDirection, transform.right) < 0)
                angle = -angle;
            //Rotation speed
            transform.Rotate(0, angle * Time.deltaTime * 2.5f, 0);


            //if (lookTargetDirection.sqrMagnitude != 0)
            //{
            //    Quaternion lookDirection = Quaternion.LookRotation(lookTargetDirection, Vector3.up);
            //    transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, 0.01f);
            //}
        }
        //This used to stop all vehicles in the game before, but I soon got rid of it because it is not realistic at all
        //If there is suddenly a stop sign at the road, only the cars that see the stop sign should stop
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
