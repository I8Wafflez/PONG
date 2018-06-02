using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour 
{
	Rigidbody2D rigBody;

	AudioSource hitSound;

	public float ballSpeed = 100f;
	static int speedLevel = 0;
	float levelIncrease = 1f;

	void OnCollisionEnter2D(Collision2D colInfo)
	{
		rigBody = GetComponent<Rigidbody2D>();
		hitSound = GetComponent<AudioSource>();

		if (colInfo.collider.tag == "playerLeft" || colInfo.collider.tag == "playerRight")
		{
			//speeds up the ball on every hit by levelIncrease
			if(colInfo.collider.tag == "playerLeft" && speedLevel < 100)
			{
				rigBody.AddForce(new Vector2(levelIncrease, 0f));
				speedLevel++;
			}
			else if(colInfo.collider.tag == "playerRight" && speedLevel < 100)
			{
				rigBody.AddForce(new Vector2(-levelIncrease, 0f));
				speedLevel++;
			}

			//adds momentum in the relative direction in the vertical
			rigBody.AddForce(new Vector2(0f, colInfo.relativeVelocity.y));
			hitSound.Play();
		}
	}
	
	public void ResetBall()
	{
		//centers the ball at 0 with 0 velocity and waits 2 seconds before launching
		rigBody = GetComponent<Rigidbody2D>();
		
		rigBody.velocity = new Vector2(0f, 0f);
		rigBody.MovePosition(new Vector2(0f, 0f));
		StartCoroutine(waitTwoSeconds());
	}

	void GoBall()
	{
		rigBody = GetComponent<Rigidbody2D>();

		float startSide =  Random.Range(0f, 1f);
		float angleStart = Random.Range(0f, 1f);
		speedLevel = 0;

		//launches the ball in a random direction
		if(startSide <= 0.5f)
		{
			rigBody.AddForce(new Vector2(-ballSpeed, angleStart*40 - 20));
			Debug.Log("Adding force GoBALL");
		}
		else
		{
			rigBody.AddForce(new Vector2(ballSpeed, angleStart*40 - 20));
			Debug.Log("Adding force GoBALL");
		}
	}
	
	IEnumerator waitTwoSeconds()
	{
		//waits two seconds before launching the ball in a random direction
		yield return new WaitForSeconds(2);
		GoBall();
	}

	void Start() 
	{
		StartCoroutine(waitTwoSeconds());
	}
}
