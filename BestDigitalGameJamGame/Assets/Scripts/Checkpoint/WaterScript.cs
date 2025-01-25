using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    public RespawnScript RespawnController;

    private void OnTriggerEnter(Collider other)//if player touches death plane, respawn them at current checkpoint
    {
        if(other.gameObject.CompareTag("Wick"))
        {
            RespawnController.Respawn();
        }
    }
}
