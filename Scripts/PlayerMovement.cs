using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody playerRB;
    private Animator playerAnim;
    private AudioSource playAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSounds;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOneGround = true;
    public bool secondJump = false; 
    public bool gameOver;
    public bool speedUp = false;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        JumpFunction();
        SpeedUp();
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isOneGround = true;
            secondJump = false;
            Debug.Log("On Ground");
            dirtParticle.Play();
        } 
        if (other.gameObject.tag == "Obstacle")
        {
            gameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playAudio.PlayOneShot(crashSounds, 1.0f);

        }
    }
    void JumpFunction()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOneGround && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOneGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playAudio.PlayOneShot(jumpSound, 1.0f);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isOneGround && !secondJump)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOneGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playAudio.PlayOneShot(jumpSound, 1.0f);
            secondJump = true;
        }
    }
    void SpeedUp()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && gameOver == false)
        {
            playerAnim.SetFloat("Speed_Multiplier", 5.0f);
            Debug.Log("That boy runing");
            speedUp = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerAnim.SetFloat("Speed_Multiplier", 1.0f);
            speedUp = false;
            Debug.Log("That boy not runing");
        }
       
               
    }
   
}
