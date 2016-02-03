﻿using UnityEngine;
using System.Collections;

public class PJMovementController : MonoBehaviour {

	[SerializeField]
	private float speed;

	[SerializeField]
	private float jump;

	private bool onFloor = false;

	public bool jumpAllowed{

		get{ 
			return onFloor;
		}

		set{ 
			onFloor = value;
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		//Movimiento izq der


		float movement = Input.GetAxis ("Horizontal") * speed;
		this.gameObject.transform.Translate(new Vector3(movement,0,0));

		Debug.Log (this.transform.rotation);


		/*
		 * 
		 * Valorar entre Flip Sprite o Flip Gameobject
		 * 
		 * 
		//mirada del pj
		if (movement > 0)
			this.transform.rotation = new Quaternion (0,0,0,1.0f);

		if (movement < 0)
			this.transform.rotation = new Quaternion (0,-1.0f,0,0);
		*/

		//Salto
		if (jumpAllowed) {

			float canJump = Input.GetAxis ("Vertical");
			if (canJump > 0) {
				this.gameObject.GetComponent<Rigidbody2D> ().ResetAndAddForce(Vector2.up * jump);
			}
		}


			

	}



}
