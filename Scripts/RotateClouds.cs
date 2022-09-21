using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClouds : MonoBehaviour
{
    public Vector3 target = new Vector3(0, 0, 0);
    public float speed = 5;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target, Vector3.up, speed * Time.deltaTime);

    }
}
