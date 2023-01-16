using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class BikeMovement : MonoBehaviour
{
    public SteamVR_Action_Vector2 input;
    private CharacterController characterController;
    private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        if (input.axis.magnitude >= 0.1f)
        {
            Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
            //transform.position = speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up);
            characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up));
        }
    }
}