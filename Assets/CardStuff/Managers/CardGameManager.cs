using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardGameManager : MonoBehaviour
{
    private List<Card> cardInstances;
    private int actionCounter;

    public readonly float cardOffset = 0.4f;
    public List<GameObject> cardPrefabs;
    public Sprite cardBack;
    public TextMeshProUGUI actionCounterTextMesh;
    // If true, all cards are sorted and put on 4 main piles when new cards are given.
    public bool testMode = false;

    [Header("Card piles")]
    public MainPile[] mainPiles;    
    public DiscardPile[] discardPiles;
    public ClosedDrawPile closedDrawPile;
    public OpenDrawPile openDrawPile;

    public static CardGameManager Instance { get; private set; }
    public bool IsAutoCompleting { get; private set; } = false;
    public int ActionCounter { get { return actionCounter; } set
        {
            actionCounter = value;
            actionCounterTextMesh.text = "Moves: " + ActionCounter.ToString();
            if (ActionCounter == 1)
                Timer.Instance.enabled = true;
        }
    }

    public bool isCardGameWon;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GiveCards();
        isCardGameWon = false;
    }

    public Slider SolitaireJRProgress;
    public Text ProgressText;

    private void Update()
    {
        if(isCardGameWon == false)
        {
            if(DiscardPile.AllAreFull() == true)
            {
                OnGameEnd();
                //isCardGameWon = true;  moved to onGameEnd()
            }
        }

        SolitaireJRProgress.value = DiscardPile.HowManyCardsOn() * 5; //game progress
        ProgressText.text = (SolitaireJRProgress.value * 20) + "%";

    }

    public void CheckForCompletion()
    {
        if (DiscardPile.AllAreFull() == true)
        {
            OnGameEnd();
        }
    }

    private void GiveCards()
    {
        Timer.Instance.ResetTime();
        ActionCounter = 0;

        cardInstances = new List<Card>();
        foreach (GameObject cardPrefab in cardPrefabs)
            cardInstances.Add(Instantiate(cardPrefab).GetComponent<Card>());

        List<Card> cardsToGive = new List<Card>(cardInstances.Count);
        cardsToGive.AddRange(cardInstances);

        if (testMode)
        {
            cardsToGive.Reverse();
            for(int i = 0; i < 4; i++)
                for(int j = 0; j < 13; j++)
                    mainPiles[i].Add(cardsToGive.Grab(0), false);
        }
        else
        {            
            cardsToGive.Shuffle();

            int numberOfCards = 1;
            foreach (MainPile mainPile in mainPiles)
            {
                mainPile.AddInitialCards(cardsToGive.Grab(0, numberOfCards));
                numberOfCards++;
            }

            foreach(Card card in cardsToGive)
                closedDrawPile.Add(card, false);
        }
    }

    // Gets executed by the respective button in the menu bar UI.
    public void GiveNewCards()
    {
        if (IsAutoCompleting)
            return;

        foreach (MainPile mainPile in mainPiles)
            mainPile.Clear();
        closedDrawPile.Clear();
        openDrawPile.Clear();
        foreach (DiscardPile discardPile in discardPiles)
            discardPile.Clear();

        MouseDragManager.draggingEnabled = true;
        Timer.Instance.enabled = false;
        History.Reset();
        GiveCards();        
    }

    public Card FindCard(CardType type, int value)
    {
        foreach (Card card in cardInstances)
            if (card.type == type && card.value == value)
                return card;
        return null;
    }

    public void CheckIfFinishedOrReadyForAutoComplete()
    {
        if (DiscardPile.AllAreFull())
        {
            OnGameEnd();
        }
        else if (openDrawPile.Cards.Count == 0 && closedDrawPile.Cards.Count == 0 && MainPile.AllAreRevealedCompletely())
        {
            if(SceneManager.GetActiveScene().name == "Solitaire1")
            {
                MouseDragManager.draggingEnabled = false;
            }
            
            StartCoroutine(AutoComplete());
        }
    }

    private IEnumerator AutoComplete()
    {
        IsAutoCompleting = false;

        if (SceneManager.GetActiveScene().name == "Solitaire1")
        {
            IsAutoCompleting = true;
            WaitForSeconds wait = new WaitForSeconds(0.2f);

            while (!DiscardPile.AllAreFull())
            {
                DiscardPile smallestDiscardPile = DiscardPile.GetSmallest(out Card cardToAdd);
                cardToAdd.Move(smallestDiscardPile, false, false, true);
                yield return wait;
            }

            IsAutoCompleting = false;
            OnGameEnd();
        }
    }

    public GameObject WinPanel;

    private void OnGameEnd()
    {
        WinPanel.SetActive(true);
        isCardGameWon = true;

        if(SceneManager.GetActiveScene().name == "Solitaire1")
        {
            PlayerPrefs.SetInt("SolitaireBonus", (PlayerPrefs.GetInt("SolitaireBonus", 0) + 150000));
        }
        else //the player is playing simple solitaire version (aka progressolitaire)
        {
            PlayerPrefs.SetInt("SimpleSolitaireBonus", (PlayerPrefs.GetInt("SimpleSolitaireBonus", 0) + 50000));
        }

        if(SceneManager.GetActiveScene().name == "Solitaire1" && ActionCounter < 100)
        {
            PlayerPrefs.SetInt("LessThan100", 1);

        }
        else if(SceneManager.GetActiveScene().name == "Solitaire1" && ActionCounter < 200)
        {
            PlayerPrefs.SetInt("LessThan200", 1);
        }
        else if(SceneManager.GetActiveScene().name != "Solitaire1" && ActionCounter < 50)
        {
            //i am not sure if it works but it should give some points to the player if hes playing simple solitaire and has less than 50 moves
        }

        int time = Timer.Instance.Stop();
        //HighscoreManager.Instance.Add(time);
        History.Reset();
    }
}
