using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListener : MonoBehaviour
{
    public bool Triggered = false;//the current button state
    public bool Toggleable = true;//if something can be pressed more than once

    // Update is called once per frame
    void Update()
    {
        if(Triggered)//if button has currently been pressed do A, else do B
        {
            this.transform.Rotate(new Vector3(0,0.01f,0), Space.Self);
        }
        else
        {
            this.transform.Rotate(new Vector3(0,-0.01f,0), Space.Self);
        }
    }
}
