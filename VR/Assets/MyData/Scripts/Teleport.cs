using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;

    public void TeleportPlayer()
    {
        if (player.transform.position.x <= transform.position.x + 1 && player.transform.position.x > transform.position.x - 1)
        {
            player.transform.position = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
            Walk.instance.teleport = true;
        }
    }
}
