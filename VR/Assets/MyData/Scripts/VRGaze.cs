﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGaze : MonoBehaviour
{

    public Image imgGaze;

    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer;

    public int distanceOfRay = 10;
    private RaycastHit _hit;

    GameObject[] rights;
    GameObject[] lefts;
    GameObject[] forwards;
    GameObject[] backs;

    // Start is called before the first frame update
    void Start()
    {
        rights = GameObject.FindGameObjectsWithTag("Right");
        lefts = GameObject.FindGameObjectsWithTag("Left");
        forwards = GameObject.FindGameObjectsWithTag("Forward");
        backs = GameObject.FindGameObjectsWithTag("Back");
    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            if(imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Teleport"))
            {
                _hit.transform.gameObject.GetComponent<Teleport>().TeleportPlayer();
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Right"))
            {
                _hit.transform.gameObject.GetComponent<Teleport>().TeleportPlayer();
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Left"))
            {
                _hit.transform.gameObject.GetComponent<Teleport>().TeleportPlayer();
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Forward"))
            {
                _hit.transform.gameObject.GetComponent<Teleport>().TeleportPlayer();
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Back"))
            {
                _hit.transform.gameObject.GetComponent<Teleport>().TeleportPlayer();
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Ball"))
            {
                _hit.transform.gameObject.GetComponent<Ball>().getBall();
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Pedestal"))
            {
                _hit.transform.gameObject.GetComponent<Pedestal>().PutBall();
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Portal"))
            {
                _hit.transform.gameObject.GetComponent<Portal>().GoPortal();
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Endgame"))
            {
                _hit.transform.gameObject.GetComponent<Endgame>().End();
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Start"))
            {
                _hit.transform.gameObject.GetComponent<MenuController>().ChangeScene();
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Exit"))
            {
                _hit.transform.gameObject.GetComponent<MenuController>().QuitApp();
            }
        }
    }

    public void GVROn()
    {
        gvrStatus = true;
    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
    }
}
