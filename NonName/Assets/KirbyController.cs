using UnityEngine;
using System.Collections;

public class KirbyController : MonoBehaviour {
	
	public float maxSpeed;
	Rigidbody2D myRB;
	Animator myAnim;
	bool facingLeft;
	bool onGround = false;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;
	
	
	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator>();
	}
	
	void Update(){
		if(onGround && Input.GetAxis("Jump")>0){
			onGround = false;
			myRB.AddForce(new Vector2(0, jumpHeight));
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//check if grounded
		onGround = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius, groundLayer);
		
		float move = Input.GetAxis("Horizontal");
		myRB.velocity = new Vector2(move*maxSpeed, myRB.velocity.y);
		if(move>0&&facingLeft){
			flip();
		}
		else if(move<0&&!facingLeft){
			flip();
		}
	}
	
	void flip(){
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
