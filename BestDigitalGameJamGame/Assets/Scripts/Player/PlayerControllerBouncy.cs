using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBouncy : MonoBehaviour
{
    public float fMoveSpeed;
    public float fJumpForce;
    public float fRollSpeed;
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
        Vector3 MoveDir = new Vector3(0, 0,Input.GetAxis("Vertical"));
        float fRealMoveSpeed = Input.GetKey(KeyCode.LeftShift) ? fMoveSpeed*2 : fMoveSpeed; // Double move speed when 'sprinting'
        
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(PlayerCollider.ClosestPoint(new Vector3(transform.position.x,0,transform.position.z)), Vector3.down, 0.5f, LayerMask.NameToLayer("Respawn"))) //TODO Fix collision layers
        {
            PlayerBody.AddForce(new Vector3(0,fJumpForce,0), ForceMode.Impulse);
        }

        if (MoveDir.z != 0f)//If trying to roll
        {
            Vector3 moveDirection = PlayerCamera.transform.forward;
            moveDirection.y = 0;
            
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.left);
            
            PlayerBody.transform.rotation = Quaternion.Lerp(PlayerBody.transform.rotation, targetRotation, fRollSpeed * Time.deltaTime);
        }
        
        Vector3 MoveVelocity = PlayerCamera.transform.TransformDirection(MoveDir) * (fRealMoveSpeed * Time.deltaTime);
        PlayerBody.velocity = new Vector3(MoveVelocity.x, PlayerBody.velocity.y, MoveVelocity.z);
        
        transform.position = PlayerBody.position;
    }
}
