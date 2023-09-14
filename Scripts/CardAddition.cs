using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// this script is not being used at the moment... //
public class CardAddition : MonoBehaviour
{
    private bool cardSpawnedForScore;
    public GameObject[] cardsToAdd;
    private GameManager gameManagerScript;
    /* // this feature has bug. While dragging a card before entering the collision, time slows. It should be normal.
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("CardAdditionCollision"))
        {
            SpawnCard();
        }
    }
    */
    private void Start() 
    {
        gameManagerScript = GameObject.Find("Character").GetComponent<GameManager>();
    }
    private void Update() 
    {
        if (gameManagerScript.score > 0 && gameManagerScript.score % 15 == 0 && !cardSpawnedForScore)
        {
            SpawnCard();
            cardSpawnedForScore = true; // Set flag to true after spawning
        }

        // Reset the flag when the score goes beyond the current interval
        if (gameManagerScript.score % 15 != 0)
        {
            cardSpawnedForScore = false;
        }
    }
    void SpawnCard()
    {
        int randomCard = Random.Range(0, cardsToAdd.Length);
        GameObject newCard = Instantiate(cardsToAdd[randomCard],new Vector2(0,0),cardsToAdd[randomCard].transform.rotation);
        GameObject cardPanel = GameObject.Find("Card Panel");
        newCard.transform.SetParent(cardPanel.transform); //make it child of card canvas
    }
}
