using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    protected float fVelocity = 20.0f;
    protected Rigidbody CannonBallBody;

    // Update is called once per frame
    void Update()
    {
        
    }

    public float CannonBallSpeed
    {
        get { return fVelocity; }
        set
        {
            fVelocity = value;
        }
    }

    public void CreateCannonBall()
    {
        CannonBallBody = GetComponentInChildren<Rigidbody>();
        Debug.Log("Ball created");
        Debug.Log(CannonBallBody != null);
    }

    public void ResetBall(Vector3 v3Pos, Quaternion qRotation)
    {
        CannonBallBody.velocity = Vector3.zero;
        transform.position = v3Pos;
        transform.rotation = qRotation;
    }

    public void BallFired()
    {
        CannonBallBody.AddForce(CannonBallBody.transform.forward * fVelocity, ForceMode.Impulse);
        Debug.Log(CannonBallBody.transform.forward * fVelocity);
    }
}
