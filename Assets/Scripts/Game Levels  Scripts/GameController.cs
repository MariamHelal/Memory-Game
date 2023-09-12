using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    [SerializeField] private Sprite bgImage;
    [SerializeField] private Button nextLevelButton;

    public Sprite[] cards;

    public List<Sprite> GameCards =new List<Sprite> ();

    public List<Button> btns =new List<Button>();

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;
    
    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessCard ,secondGuessCard;

    private bool flag =false;

    void Awake()
    {
        cards = Resources.LoadAll<Sprite>("Sprites/Cards");
    }

    void Start()
    {
        GetButtons();
        AddListener();
        AddGameCards();
        Shuffle(GameCards);
        CheckIfTheGameIsFinished();
        nextButtonDeactivate();
        gameGuesses = GameCards.Count / 2;

    }
    //add buttons and give them background
    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("CardButton");

        for(int i=0;i<objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
    }
    //add the same card two times
    void AddGameCards()
    {
        int looper=btns.Count;
        int index = 0;

        for(int i = 0; i < looper; i++)
        {
           if(index==looper/2)
            {
                index = 0;
            }
            GameCards.Add(cards[index]);
            index++;
        }
    }
    //listener to add function to buttons
    void AddListener()
    {
        foreach(Button btn in btns)
        {
            btn.onClick.AddListener(()=> PickACard());
        }
    }

    public void PickACard()
    {
        string nameOfButton=UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;


        if (!firstGuess)
        {
            firstGuess=true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessCard = GameCards[firstGuessIndex].name;

            btns[firstGuessIndex].image.sprite = GameCards[firstGuessIndex];


        }else if(!secondGuess){
            
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            secondGuessCard= GameCards[secondGuessIndex].name;
            btns[secondGuessIndex].image.sprite = GameCards[secondGuessIndex];
            
            countGuesses++;
            StartCoroutine(CheckIfTheCardsMatch());

            

        }
    }
    IEnumerator CheckIfTheCardsMatch()
    {
        yield return new WaitForSeconds(0.25f);
        if(firstGuessCard == secondGuessCard )
        {
            if (btns[firstGuessIndex] == btns[secondGuessIndex])
            {
                btns[firstGuessIndex].image.sprite = bgImage;
                btns[secondGuessIndex].image.sprite = bgImage;
            }
            else
            {
                yield return new WaitForSeconds(0.05f);
                btns[firstGuessIndex].interactable = false;
                btns[secondGuessIndex].interactable = false;
            
            }
            
            CheckIfTheGameIsFinished();
        }
        else
        { 
            
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
           
        }
        yield return new WaitForSeconds(0.05f);
        firstGuess = secondGuess = false;

    }
    void CheckIfTheGameIsFinished()
    {
        countCorrectGuesses++;

        if (countCorrectGuesses == gameGuesses)
        {
            Debug.Log("Level Finished");
            Debug.Log("It Took you "+ countGuesses +" guesses to finish the level");

            flag = true;
            nextLevelButton.interactable = true;
        }
        pass();
    }
    void Shuffle(List<Sprite> list)
    {
        nextLevelButton.interactable = false;
        for (int i=0;i<list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex= Random.Range(i,list.Count);
            list[i] = list[randomIndex];
            list[randomIndex]= temp;

        }
    }
    public void nextButtonDeactivate()
    {
        
        
        if(flag==true)
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(nextSceneIndex + 1);

        }

    }

    public void pass()
    {
        int currentLevel =SceneManager.GetActiveScene().buildIndex;

        if (flag == true && currentLevel>= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel);
        }

        Debug.Log("Level " + PlayerPrefs.GetInt("levelsUnlocked") + "Unlocked");
    }

}
