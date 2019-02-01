/*
 * Author: William Trieu 500624858
 * Created for: CPS841 - Final Project
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Watch : MonoBehaviour {

    public TextMesh Timer;
    private float time;
    public SteamVR_TrackedObject tracked;
    private bool finished;
    // Use this for initialization
    void Start () {
        time = 0f;
        setTimer();
        finished = false;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = tracked.transform.position;
        transform.rotation = tracked.transform.rotation;
        if (finished == false){
            time += Time.deltaTime;
            setTimer();
        }
    }
    void setTimer()
    {
        if (finished == false)
        {
            Timer.text = "Time: " + time.ToString("F2");
        }
    }
    public void setFinished(bool a) {
        finished = a;
        Timer.text = "Time: " + time.ToString("F2");
    }
}
