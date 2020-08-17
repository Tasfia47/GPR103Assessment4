using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject car;
    public float spawnDelay = 1f;
    float nextTimeToSpawn = 0f;
   // float countDownTimer = 3f;
    

    // Update is called once per frame
    void Update()
    {
       if(nextTimeToSpawn<= Time.time/10)
        {
            SpawnCar();
            nextTimeToSpawn = (Time.time/10) + spawnDelay;
        }
    }
    void SpawnCar ()
    {
        Instantiate(car);
    }
}
 