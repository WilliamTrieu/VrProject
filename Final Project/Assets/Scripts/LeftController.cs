/*
 * Author: William Trieu 500624858
 * Created for: CPS841 - Final Project
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftController : MonoBehaviour {
    public Transform ControllerEnd;
    public SteamVR_TrackedController controller;
    public GameObject rig;
    public float maxRayDistance = 20;
    public GameObject markerYes;
    public GameObject markerNo;
    private LineRenderer laser;
    private bool move;
    private Vector3 location;
    public GameObject ballOrigin;

    // Use this for initialization
    void Start () {
        laser = GetComponent<LineRenderer>();
        move = false;
        laser.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(controller.transform.position, controller.transform.forward);
        RaycastHit hit;

        if (controller.padTouched) {
            Debug.DrawLine(controller.transform.position, controller.transform.position + controller.transform.forward * maxRayDistance, Color.green);
            laser.enabled = true;
            laser.SetPosition(0, ControllerEnd.position);
            //raycast only to floor
            if (Physics.Raycast(ray, out hit, maxRayDistance)) {
                //show green marker for valid move and sets location
                if (hit.transform.CompareTag("floor")) {
                    move = true;
                    location = hit.point;
                    markerYes.transform.position = hit.point;
                    markerYes.SetActive(true);
                    markerNo.SetActive(false);
                }
                //removes the ability to teleport if the marker is red and not on floor
                else {
                    Debug.DrawLine(hit.point, hit.point + Vector3.up, Color.blue);
                    laser.SetPosition(1, hit.point);
                    markerNo.transform.position = hit.point;
                    move = false;
                    markerYes.SetActive(false);
                    markerNo.SetActive(true);
                }
                laser.SetPosition(1, hit.point);
                markerNo.transform.position = hit.point;

                if (controller.padPressed && move) {
                    SteamVR_Fade.View(Color.black, 0.3f);
                    Invoke("moving", 0.5f);
                    Invoke("clear", 0.6f);
                    move = false;
                    markerYes.SetActive(false);
                }
            }
            //when you point the ray to not the floor
            else {
                move = false;
                laser.SetPosition(1, ControllerEnd.position + (controller.transform.forward * maxRayDistance));
                markerNo.transform.position = ControllerEnd.position + (controller.transform.forward * maxRayDistance);
                markerYes.SetActive(false);
                markerNo.SetActive(true);
            }

        }
        if (controller.triggerPressed)
        {
            location = ballOrigin.transform.position;
            SteamVR_Fade.View(Color.black, 0.3f);
            Invoke("moving", 0.5f);
            Invoke("clear", 0.6f);
        }
        else {
            laser.enabled = false;
            markerYes.SetActive(false);
            markerNo.SetActive(false);
            move = false;
        }
    }
    void moving() {
        rig.transform.position = location;
    }
    void clear() {
        SteamVR_Fade.View(Color.clear, 0.5f);
    }
}
