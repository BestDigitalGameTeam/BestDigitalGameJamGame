using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleableOnOffObj : MonoBehaviour, iButtonListener
{
    public bool bIsActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressed()
    {
        bIsActive = !bIsActive;
    }
}
