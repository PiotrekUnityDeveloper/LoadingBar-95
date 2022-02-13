using System.Collections.Generic;

public static class History
{
    public class Step
    {        
        public CardPile oldCardPile;
        public Card card;
        public Card flippedCard;
        public List<Card> cards;

        public Step(CardPile _oldCardPile, Card _card)
        {
            oldCardPile = _oldCardPile;
            card = _card;
        }

        public Step(CardPile _oldCardPile, List<Card> _cards)
        {
            oldCardPile = _oldCardPile;
            cards = new List<Card>();
            cards.AddRange(_cards);
        }

        public void Undo()
        {
            if(card != null)
            {
                card.Move(oldCardPile, false, false, true);
                if (flippedCard != null)
                    flippedCard.ShowSide(flippedCard.CurrentlyShowingSide == CardSide.Back ? CardSide.Front : CardSide.Back);
            }
            else
            {
                cards.Reverse();
                cards.Move(oldCardPile, false);
            }
        }
    }

    private static readonly Stack<Step> history = new Stack<Step>();

    // A flipped card has to be added to the current history step, if a card gets moved away from a main pile and there is a card underneath it that is turned on its back.
    public static Card flippedCard = null;

    public static void Add(Step step)
    {
        if(flippedCard != null)
        {
            step.flippedCard = flippedCard;
            flippedCard = null;
        }
        history.Push(step);
    }

    public static void Reset()
    {
        history.Clear();
        flippedCard = null;
    }

    public static void UndoLastStep()
    {
        if (history.Count == 0)
            return;

        Step stepToUndo = history.Pop();
        stepToUndo.Undo();
    }
}
