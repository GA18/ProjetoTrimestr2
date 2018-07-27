using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

	public float horizontalSpeed = 10f;

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
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

	}


	void MoveHorizontal(float speed) {
		rb.velocity = new Vector2(speed, rb.velocity.y);
	}

	void StopMoving() {
		rb.velocity = new Vector2(0f, rb.velocity.y);
	}
}
