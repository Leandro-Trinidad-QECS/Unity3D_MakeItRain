using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour {
    public float sizey;
    public int amount = 1;
    public float scaleAmmount;
    public float scaledur = 0.5f;
    public Vector3 scaleSpeed;
    private coinController otherCoin;
    new private Collider collider;
	// Use this for initialization
	void Start () {
        collider = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 5, 0, Space.World);
        transform.localScale = scaleSpeed * scaleAmmount;

        StartCoroutine(Destroyobj());


	}
	private void OnCollisionEnter(Collision collision)
	{
        otherCoin = collision.gameObject.GetComponent<coinController>();

        if(amount <= otherCoin.amount) {
            otherCoin.amount += amount;
            otherCoin.scaleAmmount += scaledur;
            Destroy(gameObject);
        }

	}

	IEnumerator Destroyobj() {
        yield return new WaitForSeconds(30);
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
