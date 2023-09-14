using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffectsOnCharacter : MonoBehaviour
{
    private bool isDashed;
    private Dropping droppingScript;
    private GameManager gameManagerScript;
    private Rigidbody2D characterRb;
    private Animator characterAnim;
    private AudioSource audioSource;
    public AudioClip jumpingAudio;
    // Start is called before the first frame update
    void Start()
    {
        droppingScript = GameObject.Find("CardDropArea").GetComponent<Dropping>();
        gameManagerScript = GameObject.Find("Character").GetComponent<GameManager>();
        characterRb = gameObject.GetComponent<Rigidbody2D>();
        characterAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        JumpCardFunction();
        DoubleJumpCardFunction();
        DashCardFunction();
    }
    void JumpCardFunction()
    {
        if(droppingScript.isDropped && droppingScript.isJumpCard && gameManagerScript.isGameActive)
        {
            characterRb.AddForce(new Vector2(0,100),ForceMode2D.Impulse);            
            characterAnim.SetBool("isJumped",true);
            droppingScript.isDropped = false;
            droppingScript.isJumpCard = false;
            gameManagerScript.isOnGround = false;   
            audioSource.PlayOneShot(jumpingAudio);         
        }
        if(gameManagerScript.isOnGround && gameManagerScript.isGameActive)
        {
            characterAnim.SetBool("isJumped",false);
        }
    }
    void DoubleJumpCardFunction()
    {
        if(droppingScript.isDropped && droppingScript.isDoubleJumpCard && gameManagerScript.isGameActive)
        {
            characterRb.AddForce(new Vector2(0,150),ForceMode2D.Impulse);            
            characterAnim.SetBool("isJumped",true);
            droppingScript.isDropped = false;
            droppingScript.isDoubleJumpCard = false;
            gameManagerScript.isOnGround = false;   
            audioSource.PlayOneShot(jumpingAudio);         
        }
        if(gameManagerScript.isOnGround && gameManagerScript.isGameActive)
        {
            characterAnim.SetBool("isJumped",false);
        }
    }
    void DashCardFunction()
    {
        if(droppingScript.isDropped && droppingScript.isDashCard && gameManagerScript.isGameActive)
        {          
            StartCoroutine("DashTime");
            characterAnim.SetBool("isJumped",true);
            droppingScript.isDropped = false;
            droppingScript.isDashCard = false;
            gameManagerScript.isOnGround = false;   
            audioSource.PlayOneShot(jumpingAudio); //add dash audio        
        }
    }
    IEnumerator DashTime()
    {
        float normalTimeScale = Time.timeScale;
        float dashTimeScale = Time.timeScale * 4;
        Vector2 dashPosition = this.transform.position;
        float dashDuration = 1f;
        float elapsedTime = 0f;
        isDashed = true; // Set isDashed to true here

        // Dash movement loop
        while (elapsedTime < dashDuration)
        {
            Time.timeScale = dashTimeScale;
            // Keep the player's position constant during the dash
            this.transform.position = dashPosition;
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }
        isDashed = false;
        Time.timeScale = normalTimeScale;
    }
}
