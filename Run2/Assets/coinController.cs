using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour {
    public int amount = 1;
    public float scaleAmmount;
    public float scaledur = 0.5f;
    public Vector3 scaleSpeed;
    private coinController otherCoin;
    private Score playerscore;
    new private MeshCollider collider;
	// Use this for initialization
	void Start () {
        collider = GetComponent<MeshCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 5, 0, Space.World);
        transform.localScale = scaleSpeed * scaleAmmount;

        StartCoroutine(Destroyobj());


	}
	private void OnCollisionEnter(Collision collision)
	{
        if(collision.collider.CompareTag("coin")) {
            otherCoin = collision.gameObject.GetComponent<coinController>();

            if (amount <= otherCoin.amount)
            {
                otherCoin.amount += amount;
                otherCoin.scaleAmmount += scaledur;
                Destroy(gameObject);
            }
        }

        if(collision.collider.CompareTag("Player")) {
            playerscore = collision.gameObject.GetComponent<Score>();
            playerscore.score += amount;
            Destroy(gameObject);
        }

	}

	IEnumerator Destroyobj() {
        yield return new WaitForSeconds(30);
        Destroy(gameObject);
    }

}
