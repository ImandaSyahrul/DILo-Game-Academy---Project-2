﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
	// Pemain 1
	public PlayerController player1; // skrip
	private Rigidbody2D player1Rigidbody;
	public UnityEvent onWin;
	public UnityEvent onLose;
	public UnityEvent onEndMatch;

	// Pemain 2
	public PlayerController player2; // skrip
	private Rigidbody2D player2Rigidbody;

	// Bola
	public BallController ball; // skrip
	private Rigidbody2D ballRigidbody;
	private CircleCollider2D ballCollider;

	// Skor maksimal
	public int maxScore;
	// Start is called before the first frame update
	void Start()
    {
		player1Rigidbody = player1.GetComponent<Rigidbody2D>();
		player2Rigidbody = player2.GetComponent<Rigidbody2D>();
		ballRigidbody = ball.GetComponent<Rigidbody2D>();
		ballCollider = ball.GetComponent<CircleCollider2D>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }


	// Untuk menampilkan GUI
	void OnGUI()
	{
		// Tampilkan skor pemain 1 di kiri atas dan pemain 2 di kanan atas
		GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + player1.Score);
		GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + player2.Score);

		// Tombol restart untuk memulai game dari awal
		if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
		{
			// Ketika tombol restart ditekan, reset skor kedua pemain...
			player1.ResetScore();
			player2.ResetScore();

			// ...dan restart game.
			ball.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
		}

		// Jika pemain 1 menang (mencapai skor maksimal), ...
		if (player1.Score == maxScore)
		{
			// ...tampilkan teks "PLAYER ONE WINS" di bagian kiri layar...
			GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 10, 2000, 1000), "PLAYER ONE WINS");

			// ...dan kembalikan bola ke tengah.
			ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
			
		}
		// Sebaliknya, jika pemain 2 menang (mencapai skor maksimal), ...
		else if (player2.Score == maxScore)
		{
			// ...tampilkan teks "PLAYER TWO WINS" di bagian kanan layar... 
			GUI.Label(new Rect(Screen.width / 2 + 30, Screen.height / 2 - 10, 2000, 1000), "PLAYER TWO WINS");

			// ...dan kembalikan bola ke tengah.
			ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
			


		}
	}

	void Lose()
	{
		onLose.Invoke();
	}

	void Win()
	{
		onWin.Invoke();
	}
}
