using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public bool isGameOver;
    public bool isOnGround;
    public float score; 
    private float scoreAdded = 1.0f;
    public GameObject gameOverMenuUI;
    private GameObject CardsCanvas;
    public TextMeshProUGUI scoreText;
    private Animator characterAnimator;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        characterAnimator = this.GetComponent<Animator>();
        CardsCanvas = GameObject.Find("CardsCanvas");
        score = 0;
        StartCoroutine(UpdateScore());
    }
    private void OnCollisionEnter2D(Collision2D other)
    {        
        if (other.gameObject.CompareTag("Enemy"))
        {
            HandleGameOver();
        }
        if(other.gameObject.CompareTag("Ground") && isGameActive)
        {
            isOnGround = true;
        }
    } 
    private void HandleGameOver()
    {
        isGameOver = true;
        isGameActive = false;
        gameOverMenuUI.SetActive(true);
        CardsCanvas.SetActive(false);
    } 
    IEnumerator UpdateScore()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(.2f);
            score += scoreAdded;
            scoreText.text = score+" meters";
        }        
    }      
}
