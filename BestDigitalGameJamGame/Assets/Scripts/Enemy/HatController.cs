using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
    public CowBoyEnemyController Owner;

    private void Start()
    {
        Owner = GetComponentInParent<CowBoyEnemyController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        DetachHat();
    }

    private void DetachHat()
    {
        //Hat flies into space currently TODO FIX
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().isTrigger = false;
        Owner.LoseHat(transform.position);
    }
}
