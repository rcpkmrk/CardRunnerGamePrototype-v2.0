using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] cardsToSpawn;
    public float cardSpawnPositionX;
    public float cardSpawnPositionY;
    public float destinationX;
    public float destinationY;
    public float journeyLength;
    public bool reachedDestination;
    public Vector2 cardSpawnPosition;
    public Vector2 destination;
    private Vector2 centerCircle;
    public float minSpawnDelay = 0.1f;
    public float maxSpawnDelay = 5f;
    public float randomDelay;
    private GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {          
        StartCoroutine(SpawnEnemies());   
        StartCoroutine(SpawnCardsRoutine());     
        gameManagerScript = GameObject.Find("Character").GetComponent<GameManager>();        
    }

    // Update is called once per frame
    void Update()
    {        
        
    }
    IEnumerator SpawnEnemies()
    {
        while (true) //put gameover method condition
        {
            // Calculate a random delay between spawns
            randomDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(randomDelay);

            // Spawn a random enemy
            int randomEnemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomEnemy], new UnityEngine.Vector3(11f, -2.5f, 0f), enemies[randomEnemy].transform.rotation);
        }
    }
    /*
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    //                             THIS BLOCK IS FOR CARD SPAWN(On Canvas)                           //
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    void SpawnCards()  // finds points on a circle and its opposite point as destination, creates cards
    {
        cardSpawnPositionX = Random.Range(-700f,5240f);
        float circleRadius = (700f+5240f)/2f;
        centerCircle = new Vector2(1920f,1080);
        cardSpawnPositionY = Mathf.Sqrt(circleRadius*circleRadius - (cardSpawnPositionX-centerCircle.x)*(cardSpawnPositionX-centerCircle.x)) + centerCircle.y;
        cardSpawnPosition = new Vector2(cardSpawnPositionX,cardSpawnPositionY);
        destinationX = -cardSpawnPositionX + 2*centerCircle.x;
        destinationY = -cardSpawnPositionY;
        destination = new Vector2(destinationX,destinationY);

        GameObject newCard = Instantiate(cardsToSpawn[0], cardSpawnPosition, cardsToSpawn[0].transform.rotation);
        StartCoroutine(MoveCard(newCard));
    }
    IEnumerator MoveCard(GameObject card) // leps cards to the destination
    {
        float startTime = Time.time;
        journeyLength = Vector3.Distance(cardSpawnPosition, destination);
        reachedDestination = false;

        while (!reachedDestination)
        {
            float distanceCovered = (Time.time - startTime) * 1000;
            float fractionOfJourney = distanceCovered / journeyLength;
            card.transform.position = Vector2.Lerp(cardSpawnPosition, destination, fractionOfJourney);

            if (Vector2.Distance((Vector2)card.transform.position, destination) == 0f)
            {
                reachedDestination = true; // Set the flag to true when the card reaches the destination
            }
            yield return null;
        }

        // Destroy the card when it has reached the destination
        Destroy(card.gameObject);      
    }
    IEnumerator SpawnCardsRoutine()
    {
        while (true)
        {
            SpawnCards();
            yield return new WaitForSeconds(3f);
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    */
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    //                              THIS BLOCK IS FOR CARD SPAWN(Gameplay Area)                      //
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    
    void SpawnCards()  // finds points on a circle and its opposite point as destination, creates cards
    {
        cardSpawnPositionX = Random.Range(-12.07f,9.35f);
        float circleRadius = (12.07f+9.35f)/2f;
        centerCircle = new Vector2(-1.36f,0);
        cardSpawnPositionY = Mathf.Sqrt(circleRadius*circleRadius - (cardSpawnPositionX-centerCircle.x)*(cardSpawnPositionX-centerCircle.x)) + centerCircle.y;
        cardSpawnPosition = new Vector2(cardSpawnPositionX,cardSpawnPositionY);
        destinationX = -cardSpawnPositionX + 2*centerCircle.x;
        destinationY = -cardSpawnPositionY;
        destination = new Vector2(destinationX,destinationY);

        GameObject newCard = Instantiate(cardsToSpawn[0], cardSpawnPosition, cardsToSpawn[0].transform.rotation);
        StartCoroutine(MoveCard(newCard));
    }
    IEnumerator MoveCard(GameObject card) // leps cards to the destination
    {
        float startTime = Time.time;
        float journeyLength = Vector3.Distance(cardSpawnPosition, destination);
        bool reachedDestination = false;

        while (!reachedDestination)
        {
            float distanceCovered = (Time.time - startTime) * 10;
            float fractionOfJourney = distanceCovered / journeyLength;
            card.transform.position = Vector2.Lerp(cardSpawnPosition, destination, fractionOfJourney);

            if (Vector2.Distance((Vector2)card.transform.position, destination) == 0f)
            {
                reachedDestination = true; // Set the flag to true when the card reaches the destination
            }
            yield return null;
        }

        // Destroy the card when it has reached the destination
        Destroy(card.gameObject);      
    }
    IEnumerator SpawnCardsRoutine()
    {
        while (true)
        {
            SpawnCards();
            yield return new WaitForSeconds(3f);
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////
}