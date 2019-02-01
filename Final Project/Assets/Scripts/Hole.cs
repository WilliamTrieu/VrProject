/*
 * Author: William Trieu 500624858
 * Created for: CPS841 - Final Project
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip a1; 
    public AudioClip a2;

    public GameObject NextSpawn, Camera, ball;
    public GameObject rc;
	// Use this for initialization
	void Start () {
        audioSource.clip = a1;
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {   
            //set camera rig to next hole
            Camera.transform.position = NextSpawn.transform.position;
            //set ball spawn to next hole
            ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            ball.GetComponent<Rigidbody>().rotation = new Quaternion(0, 0, 0, 0);
            ball.transform.position = NextSpawn.transform.position + new Vector3(0,0.1f,0);
            //set ball spawn to next hole spawn
            rc.GetComponent<RightController>().setBallSpawn(NextSpawn.transform.position + new Vector3(0, 0.1f, 0));
            rc.GetComponent<RightController>().setBallOrigin(NextSpawn.transform.position + new Vector3(0, 0.1f, 0));

            if (audioSource.clip == a1){
                audioSource.clip = a2;
                audioSource.Play();
            }
            else{
                audioSource.clip = a1;
                audioSource.Play();
            }
        }
    }
}
