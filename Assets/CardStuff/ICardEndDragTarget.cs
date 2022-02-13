// Interface for cards and interactable draw piles (main piles and discard piles).
public interface ICardEndDragTarget
{
    CardPile CardPile { get; }
    bool CardCanBePutOnHere(Card cardToPutOn);
}
