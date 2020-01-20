using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public GameObject hand;
    public GameObject ball;

    Collider ballCol;
    Rigidbody ballRb;

    void Start()
    {
        ballCol = ball.GetComponent<SphereCollider>();
        ballRb = ball.GetComponent<Rigidbody>();
    }

    public void getBall()
    {
        ball.transform.SetParent(hand.transform);
        ballCol.isTrigger = false;
        ball.transform.localPosition = new Vector3(-2.816319e-06f, -0.1810183f, 0.4845861f);
        ballRb.useGravity = false;
    }

}
