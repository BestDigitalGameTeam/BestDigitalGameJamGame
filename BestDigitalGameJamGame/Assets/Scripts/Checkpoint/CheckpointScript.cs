using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public RespawnScript respawn;//the death plane incharge of respawning

    private void OnTriggerEnter(Collider other)//if the player touches the collider, set the new checkpoint to this one
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Touched!");
            respawn.Checkpoint = this.gameObject;
        }
    }
}
