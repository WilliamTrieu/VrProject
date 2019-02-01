/*
 * Author: William Trieu 500624858
 * Created for: CPS841 - Final Project
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 finalPosition;

    // Use this for initialization
    void Start()
    {
        initialPosition = transform.position;
        finalPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        initialPosition = finalPosition;
        finalPosition = transform.position;
    }

    public Vector3 getVelocity()
    {
        return (finalPosition - initialPosition) / Time.deltaTime;
    }
}
