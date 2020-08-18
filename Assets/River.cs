using UnityEngine;
using UnityEngine.SceneManagement;

public class River : MonoBehaviour
{

	void OnTriggerEnter2D()
	{
		Debug.Log("YOU Lost");
		//Score.CurrentScore += 100;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
