using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GiveCards();
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
            MouseDragManager.draggingEnabled = false;
            StartCoroutine(AutoComplete());
        }
    }

    private IEnumerator AutoComplete()
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

    private void OnGameEnd()
    {
        int time = Timer.Instance.Stop();
        //HighscoreManager.Instance.Add(time);
        History.Reset();
    }
}
