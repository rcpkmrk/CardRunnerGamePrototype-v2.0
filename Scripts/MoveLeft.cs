using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]float movementSpeed = 1f;
    private GameManager gameManagerScript;
    void Start()
    {
        gameManagerScript = GameObject.Find("Character").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeftFunction();
    }
    void DestroyOutBoundary()
    {
        if(gameObject.CompareTag("Enemy") && transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
    void MoveLeftFunction()
    {
        if(!gameManagerScript.isGameOver)
        {
            transform.Translate(Vector2.left*movementSpeed*Time.deltaTime);
            DestroyOutBoundary(); // Check if it is out of boundary
        }        
    }
}