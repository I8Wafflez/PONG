using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
	
	Rigidbody2D rigBody;

	public string moveUp;
	public string moveDown;
	public float speed = 10.0f;

	void Start() 
	{
		rigBody = GetComponent<Rigidbody2D>();
	}
	
	void Update() 
	{
		//moves the relative platform on key input
		if(Input.GetButton(moveUp))
		{
			rigBody.velocity = Vector2.up * speed;
		
		}
		else if(Input.GetButton(moveDown))
		{
			rigBody.velocity = Vector2.down * speed;
		}
		else
		{
			rigBody.velocity = Vector2.zero;
		}
	}
}
