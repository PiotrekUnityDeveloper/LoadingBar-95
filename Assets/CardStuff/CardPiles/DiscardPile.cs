using System.Collections.Generic;

public class DiscardPile : InteractableCardPile
{
    private static readonly List<DiscardPile> allDiscardPiles = new List<DiscardPile>(4);

    public CardType MyCardType { get; private set; } = CardType.None;

    private void Awake()
    {
        allDiscardPiles.Add(this);
    }

    public static bool AllAreFull()
    {
        foreach (DiscardPile discardPile in allDiscardPiles)
            if (discardPile.Cards.Count != 13)
                return false;
        return true;
    }

    // Needed for auto completion.
    public static DiscardPile GetSmallest(out Card missingCard)
    {
        DiscardPile smallestDiscardPile = null;

        foreach (DiscardPile discardPile in allDiscardPiles)
            if (smallestDiscardPile == null || discardPile.Cards.Count < smallestDiscardPile.Cards.Count)
                smallestDiscardPile = discardPile;

        missingCard = smallestDiscardPile.GetMissingCard();
        return smallestDiscardPile;
    }

    public static List<CardType> GetMissingCardTypes()
    {
        List<CardType> missingCardTypes = new List<CardType>(4) { CardType.Clubs, CardType.Diamonds, CardType.Hearts, CardType.Spades };
        foreach (DiscardPile discardPile in allDiscardPiles)
            if (discardPile.MyCardType != CardType.None)
                missingCardTypes.Remove(discardPile.MyCardType);
        return missingCardTypes;
    }

    // Returns the card that should be added on top of this discard pile (needed for auto completion).
    public Card GetMissingCard()
    {
        return CardGameManager.Instance.FindCard(MyCardType != CardType.None ? MyCardType : GetMissingCardTypes()[0], Cards.Count == 0 ? 1 : TopCard.value + 1);
    }

    public override bool CardCanBePutOnHere(Card cardToPutOn) => Cards.Count == 0 && cardToPutOn.value == 1;

    public override void Add(Card cardToPutOn, bool addStepToHistory = true)
    {
        if (addStepToHistory)
            History.Add(new History.Step(cardToPutOn.CardPile, cardToPutOn));

        if(Cards.Count == 0) {
            MyCardType = cardToPutOn.type;
            boxCollider.enabled = false;
        }
        
        cardToPutOn.transform.position = transform.position;
        cardToPutOn.transform.parent = transform;

        base.Add(cardToPutOn, addStepToHistory);        
    }

    public override bool CardCanBePutOnCard(Card bottomCard, Card topCard)
    {
        return topCard.type == MyCardType && topCard.value == bottomCard.value + 1 && topCard.transform.childCount == 0;
    }

    public override void Clear()
    {
        base.Clear();
        MyCardType = CardType.None;
        boxCollider.enabled = true;
    }

    // Can always return true since the MouseDragManager only allows for the top card to be dragged anyway.
    public override bool CardIsDragable(Card card) => true;
}
