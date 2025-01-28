using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    protected Collider ObjectCollider;
    protected bool bPlayerInteracting;

    // Start is called before the first frame update
    void Start()
    {
        ObjectCollider = GetComponent<Collider>();
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.transform.parent.CompareTag("Player"))
        {
            bPlayerInteracting = true;
            Debug.Log("Player can interact with object!");
            InteractWithPlayer(other);
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.transform.parent.CompareTag("Player"))
        {
            bPlayerInteracting = false;
        }
    }

    protected virtual void InteractWithPlayer(Collider PlayerCollider)
    {
        Debug.Log("Player can interact with object!");
    }
}
