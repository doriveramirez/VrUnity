using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{

    public GameObject ball;
    public GameObject hand;
    public float handPower;
    public static Grab instance;
    public bool taken = false;

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
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (taken)
        {
            if (!inHands && hand.GetComponent<Handgrab>().canGrab)
            {
                ballCol.isTrigger = true;
                ball.transform.SetParent(hand.transform);
                ball.transform.localPosition = new Vector3(0f, 0f, 1f);
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
