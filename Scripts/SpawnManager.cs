using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject fencePrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerMovement playerMoventScrip;

    // Start is called before the first frame update
    void Start()
    {
        playerMoventScrip = GameObject.Find("Player1").GetComponent<PlayerMovement>();
        InvokeRepeating("FenceSpawn", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FenceSpawn()
    {
        if(playerMoventScrip.gameOver == false)
        {
            Instantiate(fencePrefabs, spawnPos, fencePrefabs.transform.rotation);
        }
        
    }
}    

