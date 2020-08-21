using UnityEngine;

public class Goal : MonoBehaviour
{
    // public GameObject Goal1, Goal2, Goal3, Goal4;

    public GameObject TrophyFrog;
    //public void ShowFrog(bool showFrog)
    //{
    //   TrophyFrog.SetActive(showFrog);
    //}
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }

    }
