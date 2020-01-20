﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour
{

    public GameObject ball;
    public GameObject pedestal;
    public GameObject portal;

    Collider ballCol;
    Rigidbody ballRb;


    void Start()
    {
        ballCol = ball.GetComponent<SphereCollider>();
        ballRb = ball.GetComponent<Rigidbody>();
        var portalMaterial = portal.GetComponent<Renderer>();
    }

    public void PutBall()
    {
        ball.transform.SetParent(pedestal.transform);
        ballCol.isTrigger = false;
        ballRb.useGravity = false;
        ball.transform.localPosition = new Vector3(0f, 1f, 0f);
    }
}