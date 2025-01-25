using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseButton : InteractableObject
{
    private Collider m_PlayerCollider;

    public List<GameObject> ConnectedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bPlayerInteracting && m_PlayerCollider) InteractWithPlayer(m_PlayerCollider);
    }

    protected override void InteractWithPlayer(Collider PlayerCollider)
    {
        m_PlayerCollider = PlayerCollider;

        Debug.Log(PlayerCollider.GetComponentInParent<PlayerControllerHard>().PlayerIsUpright());

        if (PlayerCollider.GetComponentInParent<PlayerControllerHard>().PlayerIsUpright())
        {
            Debug.Log("Player has pressed button!");
            bPlayerInteracting = false;
        }
    }
}
