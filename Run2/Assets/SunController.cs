﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour {

    public float dayLength;
    private float rotationSpeed;
	// Update is called once per frame
	void Update () {
        rotationSpeed = Time.deltaTime / dayLength;
        transform.Rotate(-rotationSpeed, 0, 0);
	}
}
//var dayLength : float;
// var rotationSpeed : float;
 
// function Update()
//{

//    rotationSpeed = Time.deltaTime / dayLength;

//    transform.Rotate(0, rotationSpeed, 0);

//}