using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GUIText restartText;
	public GUIText gameOverText;
	private AudioSource backgroundMusic;
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GUIText scoreText;
	private int score;
	private bool gameOver;
	private bool restart;

	void Start()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		StartCoroutine(SpawnWaves());
		backgroundMusic = GetComponent<AudioSource> ();
		backgroundMusic.Play ();
		score = 0;
		UpdateScore ();
	}

	void Update(){
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while(true)
		{
			for(int i = 0; i < hazardCount; i++)
			{
				SpawnAsteroid ();
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	void SpawnAsteroid()
	{
		Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (hazards[Random.Range (1, hazards.Length)], spawnPosition, spawnRotation);

	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}

}
