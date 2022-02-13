using UnityEngine;

public class OpenDrawPile : CardPile
{
    public ClosedDrawPile closedDrawPile;

    public override void Add(Card cardToAdd, bool addStepToHistory = true)
    {
        if (addStepToHistory)
            History.Add(new History.Step(cardToAdd.CardPile, cardToAdd));

        cardToAdd.transform.parent = transform;
        cardToAdd.ShowSide(CardSide.Front);
        base.Add(cardToAdd, addStepToHistory);

        SetCardPositions();     
    }

    // Shifts the top 2 cards slightly, so the player can always see the top 3 cards.
    private void SetCardPositions()
    {
        int offsetMultiplicator = Cards.Count > 2 ? 2 : Cards.Count - 1;
        for(int i = Cards.Count - 1; i >= 0; i--)
        {
            Card card = Cards[i];
            if(offsetMultiplicator > 0)
            {
                card.transform.position = transform.position + Vector3.right * offsetMultiplicator * CardGameManager.Instance.cardOffset;
                offsetMultiplicator--;
            }
            else
                card.transform.position = transform.position;
        }
    }

    public void AddAllBackToClosedDrawPile()
    {
        if (Cards.Count == 0)
            return;

        Cards.Move(closedDrawPile, true);
    }

    public override void Remove(Card cardToRemove)
    {
        base.Remove(cardToRemove);
        SetCardPositions();
    }

    public override bool CardIsDragable(Card card) => Cards.IndexOf(card) == Cards.Count - 1;
}
