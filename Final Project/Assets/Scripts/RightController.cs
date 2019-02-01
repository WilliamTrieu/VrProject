/*
 * Author: William Trieu 500624858
 * Created for: CPS841 - Final Project
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightController : MonoBehaviour {
    public SteamVR_TrackedController controller;
    public GameObject rig;
    public GameObject ball;
    private Vector3 ballOriginLocation;
    public GameObject ballOrigin;
    // Use this for initialization
    void Start () {
        ballOriginLocation = ball.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

    }
    public void setBallSpawn(Vector3 newSpawn) {
        ballOrigin.transform.position = newSpawn;
    }
    public void setBallOrigin(Vector3 newSpawn) {
        ballOriginLocation = newSpawn;
    }
    public void resetBall() {
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        ball.GetComponent<Rigidbody>().rotation = new Quaternion(0, 0, 0, 0);
        ball.transform.position = ballOriginLocation;
    }
}
