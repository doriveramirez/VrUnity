﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{

    public GameObject ball;
    public GameObject hand;
    public float handPower;

    bool inHands = false;
    Collider ballCol;
    Rigidbody ballRb;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        ballCol = ball.GetComponent<SphereCollider>();
        ballRb = ball.GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            if (!inHands)
            {
                ballCol.isTrigger = true;
                ball.transform.SetParent(hand.transform);
                ball.transform.localPosition = new Vector3(0f, -.672f, 1.5f);
                ballRb.velocity = Vector3.zero;
                ballRb.useGravity = false;
                inHands = true;
            }
            else
            {
                ballCol.isTrigger = false;
                ballRb.useGravity = true;
                this.GetComponent<Grab>().enabled = false;
                ball.transform.SetParent(null);
                ballRb.velocity = cam.transform.rotation * Vector3.forward * handPower;
                inHands = false;
            }
        }
    }
}
