using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb;
	BoxCollider2D collider2D;
	public LayerMask groundMask;
	float groundDistance = -1;
	public bool onground = false;

	float fallMultiplier = 1.5F;

	RaycastHit2D[] groundHits = new RaycastHit2D[1];
	
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;
		collider2D = gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		onground = isGrounded();
		if(Input.GetKey(KeyCode.Space) && onground){
			rb.velocity = Vector2.up * 7;
		}
		if(rb.velocity.y < 0){
			rb.velocity += Vector2.up * Physics2D.gravity * fallMultiplier * Time.deltaTime;
		}else if(rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)){
			rb.velocity += Vector2.up * Physics2D.gravity * 2F * Time.deltaTime;
		}

		if(Input.GetKey(KeyCode.RightArrow)){
			rb.position += Vector2.right * 10 * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			rb.position += Vector2.left * 10 * Time.deltaTime;
		}

	}


	bool isGrounded(){
		collider2D.Raycast(-Vector2.up, groundHits, 2F, groundMask);
		groundDistance = groundHits[0].distance-collider2D.bounds.size.y/2;
		//Debug.Log(groundHits[0].distance);
		return groundDistance > 0.2F || groundHits[0].collider == null ? false : true;
	}



}
