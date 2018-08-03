using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

	public float horizontalSpeed = 10f;

	public float jumpSpeed = 600f;

	Rigidbody2D rb;
	SpriteRenderer sr;

	Animator anim;

	bool isJumping = false;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		float horizontalInput = Input.GetAxis("Horizontal"); // -1: Esquerda, 1: Direita
		float horizontalPlayerSpeed = horizontalSpeed * horizontalInput;
		if (horizontalPlayerSpeed != 0) {
			MoveHorizontal (horizontalPlayerSpeed);
		}
		else {
			StopMoving();
		}
		if (Input.GetButtonDown("Jump")) {
			Jump();
		}
	}


	void MoveHorizontal(float speed) {
		rb.velocity = new Vector2(speed, rb.velocity.y);
		if (speed < 0F) {
			sr.flipX = true;
		}
		else if (speed > 0f) {
			sr.flipX = false;
		}
		if(!isJumping) {
		anim.SetInteger("State", 2);
		}
	}

	void StopMoving() {
		rb.velocity = new Vector2(0f, rb.velocity.y);
		if(!isJumping) {
		anim.SetInteger("State", 0);
		}
	}
	void Jump () {
		isJumping = true;
		rb.AddForce(new Vector2(0f, jumpSpeed));
		anim.SetInteger("State", 1);
	}
}
