using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawnToCardPanel : MonoBehaviour
{
    public GameObject jumpCard;
    private GameObject cardPanel;
    // Start is called before the first frame update
    void Start()
    {
        cardPanel = GameObject.Find("CardsCanvas"); //change this later
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("touched");
            GameObject newCard = Instantiate(jumpCard, transform.position, Quaternion.identity);
            newCard.transform.SetParent(cardPanel.transform);
        }
    }
}
