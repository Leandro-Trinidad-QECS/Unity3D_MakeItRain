using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Follow : MonoBehaviour {
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Vector3 offset2;

	private void LateUpdate()
	{
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(player.position + offset2);
	}
}
