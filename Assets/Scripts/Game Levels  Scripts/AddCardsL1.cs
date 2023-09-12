using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCardsL1 : MonoBehaviour
{
    [SerializeField] private Transform puzzleField;
    [SerializeField] private GameObject btn;
    public int numberOfCards;
    // Start is called before the first frame update
    void Awake()
    {
        for(int i=0;i< numberOfCards; i++)
        {
            GameObject button = Instantiate(btn);
            button.name = "" + i;
            button.transform.SetParent(puzzleField ,false);
        }

    }
}
