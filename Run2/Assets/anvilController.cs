using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anvilController : MonoBehaviour {
    new private MeshCollider collider;
	// Use this for initialization
	void Start () {
        collider = GetComponent<MeshCollider>();
	}

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.collider.CompareTag("Player"))
        {
            //kill player
        }
        if (collision.collider.CompareTag("Ground"))
        {
            StartCoroutine(shatter());
        }
	}
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator shatter() {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
