using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionConeTrigger : MonoBehaviour
{
    private CowBoyEnemyController OwnedEnemy;
    private void Start()
    {
        OwnedEnemy = GetComponentInParent<CowBoyEnemyController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        RaycastHit hit;
        if (other.gameObject.CompareTag("Player") && Physics.Raycast(OwnedEnemy.gameObject.transform.position,other.transform.position,out hit,Mathf.Infinity) && hit.rigidbody.gameObject == other.gameObject)
        {
            OwnedEnemy.FoundPlayer(other.gameObject);
        }
    }
    
}
