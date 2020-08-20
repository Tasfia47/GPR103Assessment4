using UnityEngine;

public class Goal : MonoBehaviour
{
	public GameObject TrophyFrog;
	public void ShowFrog(bool showFrog)
    {
        TrophyFrog.SetActive(showFrog);
    }



}
