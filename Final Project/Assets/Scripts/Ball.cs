/*
 * Author: William Trieu 500624858
 * Created for: CPS841 - Final Project
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public SteamVR_TrackedObject trackedObj;
    public GameObject rig;
    public GameObject rc;
    private bool isMoving;
	// Use this for initialization
	void Start () {
        isMoving = false;
	}

    // Update is called once per frame
    void Update() {
        //teleport to ball when its far enough away and the ball has come to a complete stop
        if (GetComponent<Rigidbody>().velocity.x == 0 && GetComponent<Rigidbody>().velocity.z == 0 && isMoving)
        {
            isMoving = false;
            if (rig.transform.position.x - GetComponent<Rigidbody>().transform.position.x > 0.5 || rig.transform.position.x - GetComponent<Rigidbody>().transform.position.x < -0.5 || rig.transform.position.z - GetComponent<Rigidbody>().transform.position.z > 0.5 || rig.transform.position.z - GetComponent<Rigidbody>().transform.position.z < -0.5) {
                rc.GetComponent<RightController>().setBallOrigin(GetComponent<Rigidbody>().transform.position);
                SteamVR_Fade.View(Color.black, 0.3f);
                Invoke("moving", 0.5f);
                Invoke("clear", 0.6f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("club")) {
            //take velocity from the club and apply to ball
            GetComponent<Rigidbody>().velocity = other.GetComponent<Club>().getVelocity() * 3.00f;
            isMoving = true;
            SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(1000);
        }
        if (other.CompareTag("floor")) {
            //reset ball
            rc.GetComponent<RightController>().resetBall();
        }
    }
    void moving()
    {
        rig.transform.position = GetComponent<Rigidbody>().transform.position;
    }
    void clear()
    {
        SteamVR_Fade.View(Color.clear, 0.5f);
    }
    public void setScore() {
    }
}
