using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclesPrefabs;
    private Vector3 spawnPos = new Vector3(25, 2, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerMovement playerMoventScrip;

    // Start is called before the first frame update
    void Start()
    {
        playerMoventScrip = GameObject.Find("Player1").GetComponent<PlayerMovement>();
        InvokeRepeating("ObstaclesSpawn", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ObstaclesSpawn()
    {
        int obstacleIndex = Random.Range(0, obstaclesPrefabs.Length);
        Vector3 rotation = new Vector3(0, 0, 0);

        if(playerMoventScrip.gameOver == false)
        {
            Instantiate(obstaclesPrefabs[obstacleIndex], spawnPos, Quaternion.Euler(rotation));
        }
        
    }
}    

