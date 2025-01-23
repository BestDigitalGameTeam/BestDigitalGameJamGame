using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBulletScript : MonoBehaviour
{

    public float fBulletSpeed = 100f;

    private float fStartTime;
    // Start is called before the first frame update
    void Start()
    {
        fStartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.forward * (fBulletSpeed * Time.deltaTime);
        if (Time.time - fStartTime >= 3.0f)
        {
            //Self Destruct after 3 seconds
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //Player and Enemy triggers
        //TODO Add health to player
    }
}
