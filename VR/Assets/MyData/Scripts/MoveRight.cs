using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public GameObject player;

    public void MoveToRight()
    {
        player.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
