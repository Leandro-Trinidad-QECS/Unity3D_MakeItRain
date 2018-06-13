using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class pickup : MonoBehaviour {

    private Rigidbody rb;
    public GameObject playerCamLocation;

    [SerializeField]
    private bool holding;
    private bool closeToObject;
    private Vector3 objPos ;
    [Range(3,5)]
    public float range;
    [Range(0, 1)]
    public float pickupMoveSpeed;
    RaycastHit hit;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
	}
	void Update()
	{
        //able to pickup the object
        if(Vector3.Distance(rb.transform.position,playerCamLocation.transform.position) <= range) {

            closeToObject = true;
        } else {
            closeToObject = false;
        }

        if(holding && closeToObject) {

            //makes it always face the player
            Quaternion currentRot = transform.rotation;
            Quaternion destinedRot = playerCamLocation.transform.rotation;
            transform.rotation = Quaternion.Lerp(currentRot, destinedRot, pickupMoveSpeed);


            // moves the block to middle of screen
            float dist = 3f;
            Vector3 currentPos = transform.position;
            Vector3 destinedPos = playerCamLocation.transform.position + playerCamLocation.transform.forward * dist;

            transform.position = Vector3.Lerp(currentPos, destinedPos, pickupMoveSpeed);




            // other
            rb.useGravity = false;
            transform.parent = playerCamLocation.transform;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;



            // outlines the box
            if (Physics.Raycast(playerCamLocation.transform.position, playerCamLocation.transform.forward, out hit, range) 
                && hit.collider.gameObject.CompareTag("pickup")
                && !holding)
            {
                Debug.Log("Asd");
                //Debug.DrawLine(playerCamLocation.transform.position, playerCamLocation.transform.forward * range);
            }
        }
        if(!closeToObject || !holding) {
            holding = false;
            rb.useGravity = true;
            transform.parent = null;
        }
	}

	private void OnMouseDown()
	{
        if(closeToObject) {
            holding = true;
            rb.useGravity = false;
            rb.detectCollisions = true;
        }

	}
	private void OnMouseUp()
	{
        holding = false;

        rb.useGravity = true;
	}
}
