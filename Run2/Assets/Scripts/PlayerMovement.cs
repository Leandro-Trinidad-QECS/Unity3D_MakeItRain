using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Collider collider;
    public float sizey;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    [Range(1,10)]
    public float jumpVelocity;
    public float speed;

	private void Awake()
	{
        collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
	}

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = Vector3.left * speed;

        }
        
        // jump button
        if(isGround() && Input.GetButtonDown("Jump")) {
            rb.velocity = Vector3.up * jumpVelocity;
        } else {
            if(Input.GetKeyDown(KeyCode.A)) {
            rb.velocity = Vector3.left * speed;
            
        }
        }
        if(rb.velocity.y < 0) {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        } else if(rb.velocity.y > 0 && !Input.GetButton("Jump")) {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }
    bool isGround() {
        // checs if the user is touching the ground using raycast
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        sizey = (collider.bounds.size.y / 2) + 0.1f;
        if(Physics.Raycast(ray, out hit, sizey)) {
            return true;
        }
        return false;
    }
}