using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public GameObject player;
    public bool movement;

    public void MoveToRight()
    {
        player.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
        movement = true;
        do
        {
            player.transform.Translate(0, 1, 0);
        } while (movement);
    }
}
