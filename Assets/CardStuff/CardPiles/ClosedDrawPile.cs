public class ClosedDrawPile : CardPile
{
    public OpenDrawPile openDrawPile;

    public override void Add(Card cardToAdd, bool addStepToHistory = true)
    {
        if (addStepToHistory)
            History.Add(new History.Step(cardToAdd.CardPile, cardToAdd));

        cardToAdd.ShowSide(CardSide.Back);
        cardToAdd.transform.position = transform.position;
        cardToAdd.transform.parent = transform;
        base.Add(cardToAdd, addStepToHistory);
    }

    // Gets executed by the "pointer click" event on the event trigger component.
    public void OnClick()
    {
        if (Cards.Count > 0)
        {
            Card cardToDiscard = Cards[Cards.Count - 1];
            cardToDiscard.Move(openDrawPile, false, true, true);
        }
        else
        {
            openDrawPile.AddAllBackToClosedDrawPile();
        }
    }

    public void BackCards()
    {
        openDrawPile.AddAllBackToClosedDrawPile();
    }

    public override bool CardIsDragable(Card card) => false;
}
