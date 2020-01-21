using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour
{

    public GameObject ball;
    public GameObject pedestal;
    public GameObject portal;

    Collider ballCol;
    Rigidbody ballRb;
    Renderer portalMaterial;
    bool portalActivated = false;

    void Start()
    {
        ballCol = ball.GetComponent<SphereCollider>();
        ballRb = ball.GetComponent<Rigidbody>();
        portalMaterial = portal.GetComponent<Renderer>();
    }

    public void PutBall()
    {
        ball.transform.SetParent(pedestal.transform);
        ballCol.isTrigger = false;
        ballRb.useGravity = false;
        ball.transform.localPosition = new Vector3(0f, 0.6f, 0f);
        portalMaterial.material.SetColor("_Color", Color.white);
        portalActivated = true;
    }
}
