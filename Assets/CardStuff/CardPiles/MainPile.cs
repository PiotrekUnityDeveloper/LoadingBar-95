using System.Collections.Generic;
using UnityEngine;

public class MainPile : InteractableCardPile
{
    private static readonly List<MainPile> allMainPiles = new List<MainPile>(7);

    private void Awake()
    {
        allMainPiles.Add(this);
    }

    // Checks if all cards in all main piles are showing their front side (needed for checking if the game is over).
    public static bool AllAreRevealedCompletely()
    {
        foreach (MainPile mainPile in allMainPiles)
            if (!mainPile.IsRevealedCompletely())
                return false;
        return true;
    }

    public void AddInitialCards(List<Card> _cards)
    {
        for(int i = 0; i < _cards.Count; i++)
        {
            Card card = _cards[i];
            if (i < _cards.Count - 1)
                card.ShowSide(CardSide.Back);

            card.transform.position = transform.position + Cards.Count * CardGameManager.Instance.cardOffset * Vector3.down;
            card.transform.parent = transform;
            base.Add(card, false);
        }
    }

    public override bool CardCanBePutOnHere(Card cardToPutOn)
    {
        return Cards.Count == 0 && cardToPutOn.value == 13;
    }

    public override void Add(Card cardToPutOn, bool addStepToHistory = true)
    {
        if (addStepToHistory)
            History.Add(new History.Step(cardToPutOn.CardPile, cardToPutOn));

        cardToPutOn.transform.position = transform.position + Cards.Count * CardGameManager.Instance.cardOffset * Vector3.down;
        cardToPutOn.transform.parent = Cards.Count == 0 ? transform : TopCard.transform;
        boxCollider.enabled = false;
        base.Add(cardToPutOn, addStepToHistory);

        if (cardToPutOn.transform.TryGetComponentsInChildrenExcludingSelf(out Card[] childCards))
            AddChildCards(childCards);
    }

    // When a card with children is dragged onto this pile, this method adds them to this pile, too.
    private void AddChildCards(Card[] childCards)
    {
        foreach (Card childCard in childCards)
        {
            childCard.CardPile = this;
            childCard.SortingOrder = Cards.Count;
            Cards.Add(childCard);
        }
    }

    public override void Remove(Card cardToRemove)
    {
        if(cardToRemove.transform.TryGetComponentsInChildrenExcludingSelf(out Card[] childCards))
            foreach (Card childCard in childCards)
                Cards.Remove(childCard);

        base.Remove(cardToRemove);

        if (Cards.Count > 0 && TopCard.CurrentlyShowingSide == CardSide.Back)
        {            
            TopCard.ShowSide(CardSide.Front);
            // When a card gets flipped to the front, it will be saved in this history step.
            // This ensures that the card will be flipped back when the player undos this step.
            History.flippedCard = TopCard;
        }
    }

    public override bool CardCanBePutOnCard(Card bottomCard, Card topCard)
    {
        return bottomCard.CurrentlyShowingSide == CardSide.Front &&
               bottomCard.Color != topCard.Color &&
               topCard.value == bottomCard.value - 1 &&
               bottomCard == TopCard;
    }

    public bool IsRevealedCompletely()
    {
        foreach (Card card in Cards)
            if (card.CurrentlyShowingSide == CardSide.Back)
                return false;
        return true;
    }

    public override bool CardIsDragable(Card card) => card.CurrentlyShowingSide == CardSide.Front;
}
