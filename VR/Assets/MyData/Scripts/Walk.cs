using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{

    public int playerSpeed;
    public GameObject wall;
    public int count;
    public string direction;
    public bool teleport = false;
    public static Walk instance;
    GameObject[] stops;
    GameObject[] rights;
    GameObject[] lefts;
    GameObject[] forwards;
    GameObject[] backs;

    // Start is called before the first frame update
    void Start()
    {
        stops = GameObject.FindGameObjectsWithTag("Stop");
        rights = GameObject.FindGameObjectsWithTag("Right");
        lefts = GameObject.FindGameObjectsWithTag("Left");
        forwards = GameObject.FindGameObjectsWithTag("Forward");
        backs = GameObject.FindGameObjectsWithTag("Back");
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == "right" && teleport == true)
        {
            Debug.Log("se está haciendo");
            transform.Translate(1 * playerSpeed * Time.deltaTime, 0, 0);
        }
        if (direction == "left" && teleport == true)
        {
            Debug.Log("pasa");
            transform.Translate(-1 * playerSpeed * Time.deltaTime, 0, 0);
        }
        if (direction == "forward" && teleport == true)
        {
            transform.Translate(0, 0, 1 * playerSpeed * Time.deltaTime);
        }
        if (direction == "back" && teleport == true)
        {
            transform.Translate(0, 0, -1 * playerSpeed * Time.deltaTime);
        }
        if (Input.GetButton("Fire1"))
        {
            transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
        }
        if (count == 4)
        {
            wall.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            count++;
        }
        foreach (GameObject right in rights)
        {
            if (!teleport && other.transform.position == right.transform.position)
            {
                direction = "right";
            }
        }
        foreach (GameObject left in lefts)
        {
            if (!teleport && other.transform.position == left.transform.position)
            {
                direction = "left";
            }
        }
        foreach (GameObject forward in forwards)
        {
            if (!teleport && other.transform.position == forward.transform.position)
            {
                direction = "forward";
            }
        }
        foreach (GameObject back in backs)
        {
            if (!teleport && other.transform.position == back.transform.position)
            {
                direction = "back";
            }
        }
        foreach (GameObject stop in stops)
        {
            if(other.transform.position == stop.transform.position)
            {
                transform.position = new Vector3(stop.transform.position.x, stop.transform.position.y + 0.8f, stop.transform.position.z);
                direction = "null";
                teleport = false;
            }
        }
    }

}
