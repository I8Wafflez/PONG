using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetup : MonoBehaviour 
{
	public Camera mainCam;

	public BoxCollider2D topWall;
	public BoxCollider2D bottomWall;
	public BoxCollider2D leftWall;
	public BoxCollider2D rightWall;

	public Transform player1;
	public Transform player2;
	public Transform theBall;

	static int playerScore1 = 0;
	static int playerScore2 = 0;
	static string displayText = "";
	static string endInfo1 = "";
	static string endInfo2 = "";

	public Text scoreDisplay1;
	public Text scoreDisplay2;
	public Text winnerDisplay;
	public Text endInfoDisplay1;
	public Text endInfoDisplay2;

	public KeyCode newGame;
	public KeyCode endGame;

	void Start () 
	{
		//sets the players position relative to the screen resolution
		player1.position = new Vector3(mainCam.ScreenToWorldPoint(new Vector3(75f, 0f, 0f)).x, player1.position.y, 0f);
		player2.position = new Vector3(mainCam.ScreenToWorldPoint(new Vector3(Screen.width - 75f, 0f, 0f)).x, player2.position.y, 0f);

		//places the edge hitboxes relative to the screen resolution
		topWall.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
		topWall.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 0.5f);

		bottomWall.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
		bottomWall.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - 0.5f);

		leftWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
		leftWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

		rightWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
		rightWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);
	}

	public static void Score(string wallName)
	{
		//adds a point to scoring side
		if(wallName == "rightWall")
		{
			playerScore1 += 1;
		}
		else if(wallName == "leftWall")
		{
			playerScore2 += 1;
		}
	}

	public static bool Winner()
	{
		//function to check if there is a winner then displays winner to screen
		if(playerScore1 == 9 || playerScore2 == 9)
		{
			if(playerScore1 == 9)
			{
				displayText = "Player 1 wins!";
				endInfo1 = "Press space to reset";
				endInfo2 = "Press esc to exit game";
			}
			else
			{
				displayText = "Player 2 wins!";
				endInfo1 = "Press space to reset";
				endInfo2 = "Press esc to exit game";
			}	
			return true;
		}
		else
		{
			return false;
		}
	}

	void Update() 
	{
		//displays the at 9 points
		winnerDisplay.text = displayText;
		endInfoDisplay1.text = endInfo1;
		endInfoDisplay2.text = endInfo2;

		//real time score UI
		scoreDisplay1.text = "" + playerScore1;
		scoreDisplay2.text = "" + playerScore2;

		//resets game on keypress
		if(Input.GetKeyUp(newGame))
		{
			playerScore1 = 0;
			playerScore2 = 0;
			theBall.SendMessage("ResetBall");
			displayText = "";
			endInfo1 = "";
			endInfo2 = "";
		}
		else if(Input.GetKeyUp(endGame))
		{
			Application.Quit();
		}


	}
}
