using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour 
{
	AudioSource scoreSound;	

	void OnTriggerEnter2D(Collider2D hitInfo) 
	{
		if(hitInfo.name == "Ball")
		{
			//scores a point to the opposite player
			string wallName = transform.name;

			scoreSound = GetComponent<AudioSource>();
			scoreSound.Play();		
			GameSetup.Score(wallName);

			if(!GameSetup.Winner())
			{
				hitInfo.gameObject.SendMessage("ResetBall");
			}
		}
		
	}
}
