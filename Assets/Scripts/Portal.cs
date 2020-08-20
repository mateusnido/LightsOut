using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject otherPortal;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            other.transform.position = otherPortal.transform.position;
    }
}
