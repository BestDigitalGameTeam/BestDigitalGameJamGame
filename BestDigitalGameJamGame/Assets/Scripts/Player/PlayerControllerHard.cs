using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerHard : MonoBehaviour
{
    public float fMoveSpeed;
    public float fJumpForce;
    public float fStandUpSpeed;
    public GameObject PlayerBottomOrigin;

    private Rigidbody PlayerBody;
    public Camera PlayerCamera;
    private CapsuleCollider PlayerCollider;
    private LayerMask GroundedMask;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PlayerBody = gameObject.GetComponentInChildren<Rigidbody>();
        PlayerCollider = gameObject.GetComponentInChildren<CapsuleCollider>(); //If other capsule colliders are added to the player this will break
    }
    
    void Update()
    {
        Vector3 MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float fRealMoveSpeed = Input.GetKey(KeyCode.LeftShift) ? fMoveSpeed * 2 : fMoveSpeed; // Double move speed when 'sprinting'
        
        if (Input.GetKeyDown(KeyCode.Space) &&Physics.Raycast(PlayerCollider.ClosestPoint(new Vector3(transform.position.x,0,transform.position.z)), Vector3.down, 0.5f, LayerMask.NameToLayer("Respawn"))) //TODO Fix collision layers
        {
            PlayerBody.AddForce(new Vector3(0,fJumpForce,0), ForceMode.Impulse);
        }
        
        // TO GET WORKING
        if (Input.GetKeyDown(KeyCode.LeftControl)) // not yet working
        {
            Vector3 newRotationDirection = Vector3.RotateTowards(transform.TransformDirection(0, 1, 0), new Vector3(PlayerBottomOrigin.transform.position.x, 10, PlayerBottomOrigin.transform.position.z), fStandUpSpeed * Time.deltaTime, 0.0f);
            PlayerBottomOrigin.transform.rotation = Quaternion.LookRotation(newRotationDirection);
        }

        Vector3 MoveVelocity = PlayerCamera.transform.TransformDirection(MoveDir) * (fRealMoveSpeed * Time.deltaTime);
        PlayerBody.velocity = new Vector3(MoveVelocity.x, PlayerBody.velocity.y, MoveVelocity.z);
        
        transform.position = PlayerBody.position;
    }
}
