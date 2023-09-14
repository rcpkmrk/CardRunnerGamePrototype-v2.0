using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    // Start is called before the first frame update
    private float backGroundLength;
    private Vector2 initialPosition;
    [SerializeField] int repeatedSprites;
    void Start()
    {
        initialPosition = transform.position;
        backGroundLength = gameObject.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < initialPosition.x - backGroundLength / repeatedSprites)
        {
            transform.position = initialPosition; 
        }  
    }
}
