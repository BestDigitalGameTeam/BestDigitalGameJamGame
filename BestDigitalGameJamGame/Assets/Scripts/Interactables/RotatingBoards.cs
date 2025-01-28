using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBoards : ToggleableOnOffObj
{
    public float fRotationAmtDegrees = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bIsActive)
        {
            // if active then rotate 
            gameObject.transform.Rotate(0, fRotationAmtDegrees * Time.deltaTime, 0);
        }
    }
}
