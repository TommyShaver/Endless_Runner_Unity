using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private float speed = 10.0f;
    private float leftBound = -15;
    private PlayerMovement playerMovementScript;


    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript = GameObject.Find("Player1").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovementScript.gameOver == false && playerMovementScript.speedUp == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (playerMovementScript.speedUp == true && playerMovementScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * 35);
        }

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

       
    }
}
