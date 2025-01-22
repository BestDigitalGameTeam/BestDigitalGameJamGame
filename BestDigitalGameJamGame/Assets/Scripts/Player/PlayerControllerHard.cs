using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerHard : MonoBehaviour
{
    public float fMoveSpeed;
    public float fJumpForce;
    private float fStandUpSpeed = 1.0f;
    private float fStandUpPos = 0.0f;
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
        if (Input.GetKey(KeyCode.LeftControl)) // not yet working
        {
            // stand up speed in seconds
            // add to stand up pos for lerp
            fStandUpPos += fStandUpSpeed * Time.deltaTime;
            Debug.Log(fStandUpPos);

            //Vector3 newRotationDirection = Vector3.RotateTowards(Vector3.Normalize(transform.TransformDirection(0, 10, 0)), Vector3.Normalize(Vector3.up), fRotationPerFrame, 0.0f);
            Vector3 newRotationDirection = Vector3.Lerp(Vector3.Normalize(PlayerBody.transform.up), Vector3.Normalize(Vector3.up), fStandUpPos);

            // Draw a ray pointing at target direction
            Debug.DrawRay(PlayerBottomOrigin.transform.position, newRotationDirection, Color.red, 0.0f);
            //Debug.DrawRay(PlayerBottomOrigin.transform.position, PlayerBody.transform.up, Color.green, 0.0f);
            //Debug.DrawRay(PlayerBottomOrigin.transform.position, Vector3.up, Color.blue, 0.0f);

            PlayerBottomOrigin.transform.rotation = Quaternion.FromToRotation(PlayerBody.transform.up, newRotationDirection);
            //PlayerBottomOrigin.transform.rotation = Quaternion.LookRotation(PlayerBody.transform.up, newRotationDirection);
        }

        Vector3 MoveVelocity = PlayerCamera.transform.TransformDirection(MoveDir) * (fRealMoveSpeed * Time.deltaTime);
        PlayerBody.velocity = new Vector3(MoveVelocity.x, PlayerBody.velocity.y, MoveVelocity.z);
        
        transform.position = PlayerBody.position;
    }
}
