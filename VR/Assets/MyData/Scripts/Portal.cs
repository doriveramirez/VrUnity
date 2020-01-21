using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject player;
    public GameObject pedestal;
    public float x, y, z;
    public void GoPortal()
    {
        if (pedestal.transform.childCount > 0)
        player.transform.position = new Vector3(x, y, z);
    }
}