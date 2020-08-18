using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSpawner : MonoBehaviour
{

	public float spawnDelay = 1f;

	public GameObject car;

	public Transform[] spawnPoints;

	float nextTimeToSpawn = 0f;

	void Update()
	{
		if (nextTimeToSpawn <= Time.time)
		{
			SpawnCar();
			nextTimeToSpawn = Time.time + spawnDelay;
		}
	}

	void SpawnCar()
	{
		int randomIndex = Random.Range(0, spawnPoints.Length);
		Transform spawnPoint = spawnPoints[randomIndex];

		Instantiate(car, spawnPoint.position, spawnPoint.rotation);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Car")
		{
			Debug.Log("WE LOST!");
			Score.CurrentScore = 0;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

}

