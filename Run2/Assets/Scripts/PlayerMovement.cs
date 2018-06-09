using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Collider collider;
    public float sizey;
	private void Start()
	{
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();

	}
	void Update()
    {
        if(isGround() && Input.GetButton("Jump")) {
            rb.AddForce(0.0f,1.0f*2,0,ForceMode.Impulse);
        }
        //raycast to gorund to detect if on ground
       
    }
    bool isGround() {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        sizey = (collider.bounds.size.y / 2) + 0.1f;
        if(Physics.Raycast(ray, out hit, sizey)) {
            return true;
        }
        return false;
    }
}