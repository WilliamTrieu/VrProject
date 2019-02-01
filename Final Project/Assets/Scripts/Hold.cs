/*
 * Author: William Trieu 500624858
 * Created for: CPS841 - Final Project
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold : MonoBehaviour {
    public SteamVR_TrackedObject tracked;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = tracked.transform.position;
        transform.rotation = tracked.transform.rotation;
    }
}
