using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private GameObject player2;
    GameObject[] balls;
    public static Ball instance;

    void Start()
    {
        player2 = GameObject.FindGameObjectWithTag("Player");
        balls = GameObject.FindGameObjectsWithTag("Ball");
        instance = this;
    }

    public GameObject GetBall()
    {
        foreach (GameObject ball in balls)
        {
            Debug.Log(ball.transform.position.x);
            return ball;
        }
        return null;
    }
}
