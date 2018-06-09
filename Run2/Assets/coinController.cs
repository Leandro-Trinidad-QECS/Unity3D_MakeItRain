using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour {
    public float sizey;
    new private Collider collider;
	// Use this for initialization
	void Start () {
        collider = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 5, 0, Space.World);

        if(isGround()) {
            StartCoroutine(Destroyobj());
        }

	}

    IEnumerator Destroyobj() {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    bool isGround()
    {
        // checs if the user is touching the ground using raycast
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        sizey = (collider.bounds.size.y / 2) + 0.1f;
        if (Physics.Raycast(ray, out hit, sizey))
        {
            return true;
        }
        return false;
    }
}
