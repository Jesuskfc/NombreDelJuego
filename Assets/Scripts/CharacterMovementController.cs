﻿using UnityEngine;
using System.Collections;

public abstract class CharacterMovementController : MonoBehaviour {

	[SerializeField]
	protected float speed;

	[SerializeField]
	protected float jump;

	protected bool onFloor = false;

	public bool jumpAllowed{

		get{ 
			return onFloor;
		}

		set{ 
			onFloor = value;
		}

	}

	protected void Move(float movement){

		//Movimiento izq der

		this.gameObject.transform.Translate(new Vector3(movement,0,0));

	}

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

	protected void Jump(){
		
		//Salto

		if (jumpAllowed)
			this.gameObject.GetComponent<Rigidbody2D> ().ResetAndAddForce (Vector2.up * jump);
	}

}