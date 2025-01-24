using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerInZone : MonoBehaviour
{
    private Collider ObjectCollider;

    // Start is called before the first frame update
    void Start()
    {
        ObjectCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.transform.parent.CompareTag("Player"))
        {
            
        }
    }
}
