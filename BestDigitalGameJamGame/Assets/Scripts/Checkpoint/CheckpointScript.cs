using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : InteractableObject
{
    public RespawnScript respawn;//the death plane incharge of respawning

    protected override void InteractWithPlayer(Collider PlayerCollider)
    {
        respawn.Checkpoint = this.gameObject;
    }
}
