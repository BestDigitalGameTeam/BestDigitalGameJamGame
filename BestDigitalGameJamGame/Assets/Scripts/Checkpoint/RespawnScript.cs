using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Checkpoint;
    
    private void OnTriggerEnter(Collider other)//if player touches death plane, respawn them at current checkpoint
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //move player
            Player.transform.position = Checkpoint.transform.GetChild(0).gameObject.transform.position;
            //rotate player
            Player.transform.eulerAngles = new Vector3(0,0,0);
            //stop momentum
            Player.GetComponentInChildren<Rigidbody>().velocity = Vector3.zero;
            Player.GetComponentInChildren<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}
