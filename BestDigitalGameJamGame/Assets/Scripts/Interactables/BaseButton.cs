using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseButton : InteractableObject
{
    private Collider m_PlayerCollider;

    public List<GameObject> ConnectedObjects = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (bPlayerInteracting && m_PlayerCollider) InteractWithPlayer(m_PlayerCollider);
    }

    protected override void InteractWithPlayer(Collider PlayerCollider)
    {
        m_PlayerCollider = PlayerCollider;

        if (PlayerCollider.GetComponentInParent<PlayerControllerHard>().PlayerIsUpright())
        {
            Debug.Log("Player has pressed button!");
            bPlayerInteracting = false;

            //when the button is pressed, iterate through listeners
            foreach (GameObject listener in ConnectedObjects)
            {
                // Tell listener that button has been pressed
                listener.GetComponent<iButtonListener>().ButtonPressed();
            }
        }
    }
}
