using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    new private Collider collider;
    public Animator anim;
    public float sizey;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    [Range(1,10)]
    public float jumpVelocity;
    public float speed;
    private bool pressJump;


	private void Start()
	{
        collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
	}

	void Update()
    {

        // jump button
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
        transform.Translate(x, 0,0);
        if(isGround() && Input.GetButtonDown("Jump")) {
            rb.velocity = Vector3.up * jumpVelocity;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            pressJump = true;
        }

        if(isGround() && pressJump) {
            //Do animation of squish
            anim.SetBool("isFall", true);
            print(1);
            pressJump = false;
        }
        //if(isGround() && !pressJump) {
        //    anim.SetBool("isFall", false);
        //}

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