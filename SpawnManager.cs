using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnEnemy;
    // POWERUP SPAWN
    public GameObject spawnPowerUp;
    private Vector3 spawPos;
    private float startDelay = 2;
    private float startDelayPowerUps = 4; // POWERUP
    private float repeatDelayPowerUps = 5; // POWERUP
    private float repeatDelay = 2;
    private float rangePosY;
    private float rangePosX;

    // Start is called before the first frame update
    void Start()
    {
        // TEST SPAWN

        // Repeating on start and delay
        InvokeRepeating("SpawnEnemy", startDelay, repeatDelay);
        InvokeRepeating("SpawnPowerUps", startDelayPowerUps, repeatDelayPowerUps); // POWER ups
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // SPAWN ENEMY
    void SpawnEnemy()
    {
        // INDEX RANDOM 
        int indexRandom = Random.Range(0, spawnEnemy.Length);
        rangePosY = Random.Range(-3, 4);
        rangePosX = Random.Range(12, 15);

        spawPos = new Vector3(rangePosX, rangePosY, -2); // USE RANDOM VECTOR POSITION 
        
        Instantiate(spawnEnemy[indexRandom], spawPos, spawnEnemy[indexRandom].transform.rotation);
    }

    //  SPAWN POWERUP
    void SpawnPowerUps()
    {
        // INDEX RANDOM 
        int indexRandom = Random.Range(0, spawnEnemy.Length);
        rangePosY = Random.Range(-3, 8);
        rangePosX = Random.Range(-5, 18);

        spawPos = new Vector3(rangePosX, rangePosY, -2); // USE RANDOM VECTOR POSITION 

        Instantiate(spawnPowerUp, spawPos, spawnPowerUp.transform.rotation);
    }
}
