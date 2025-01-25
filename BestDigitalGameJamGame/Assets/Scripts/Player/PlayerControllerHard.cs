using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerHard : MonoBehaviour
{
    public float fMoveSpeed;
    public float fJumpForce;
    public float fGravityForce;

    private float fStandUpSpeed = 2.0f;
    private float fStandUpPos = 0.0f;

    private Rigidbody PlayerBody;
    public Camera PlayerCamera;
    private CapsuleCollider PlayerCollider;
    private SphereCollider PlayerInteractionCollider;
    private LayerMask GroundedMask;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PlayerBody = gameObject.GetComponentInChildren<Rigidbody>();
        PlayerCollider = gameObject.GetComponentInChildren<CapsuleCollider>(); //If other capsule colliders are added to the player this will break
        PlayerInteractionCollider = gameObject.GetComponentInChildren<SphereCollider>(); //If other sphere colliders are added to the player this will break
    }
    
    void Update()
    {
        // pivot point at base of player capsule
        Vector3 v3PivotPoint = (PlayerBody.transform.position - (PlayerBody.transform.up * PlayerBody.GetComponent<Collider>().bounds.extents.y));

        Vector3 MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float fRealMoveSpeed = Input.GetKey(KeyCode.LeftShift) ? fMoveSpeed * 1.5f : fMoveSpeed; // increase move speed when sprinting
        
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(PlayerCollider.ClosestPoint(new Vector3(v3PivotPoint.x, 0, v3PivotPoint.z)), Vector3.down, 0.5f, LayerMask.NameToLayer("Respawn"))) //TODO Fix collision layers
        {
            PlayerBody.AddForce(new Vector3(0, fJumpForce, 0), ForceMode.Impulse);
        }
        
        // PLAYER CAN STAND UP
        if (Input.GetKey(KeyCode.LeftControl) && fStandUpPos < fStandUpSpeed) // not yet working
        {
            //// stand up speed in seconds
            //// add to stand up pos for lerp
            //// if it exceeds 1, clamp to 1
            fStandUpPos += fStandUpSpeed * Time.deltaTime;

            // new up vector direction
            Vector3 newDirection;

            if (fStandUpPos >= fStandUpSpeed)
            {
                newDirection = Vector3.up;
            }
            else
            {
                // calculate the rotated vector from old up position to world up, if rotating at the stand up speed, as per each frame
                newDirection = Vector3.RotateTowards(PlayerBody.transform.up, Vector3.up, fStandUpSpeed * Time.deltaTime, 0.0f);
            }

            // rotate around the pivot by the axis that is formed by the cross product of old and new direction
            PlayerBody.transform.RotateAround(v3PivotPoint, Vector3.Cross(PlayerBody.transform.up, newDirection), Vector3.Angle(PlayerBody.transform.up, newDirection));
        }
        else
        {
            // if user has released control key, allow them to stand up again
            if (!Input.GetKey(KeyCode.LeftControl))
            {
                fStandUpPos = 0.0f; 
            }
        }

        Vector3 MoveVelocity = PlayerCamera.transform.TransformDirection(MoveDir) * (fRealMoveSpeed * Time.deltaTime);
        PlayerBody.velocity = new Vector3(MoveVelocity.x, PlayerBody.velocity.y, MoveVelocity.z);
        
        transform.position = PlayerBody.position;
        transform.rotation = PlayerBody.rotation;
    }

    public bool PlayerIsUpright()
    {
        return (Vector3.Angle(PlayerBody.transform.up, Vector3.up) < 5);
    }
}
