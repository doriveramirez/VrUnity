﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgrab : MonoBehaviour
{
    public bool canGrab = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            canGrab = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        canGrab = false;
    }

}
