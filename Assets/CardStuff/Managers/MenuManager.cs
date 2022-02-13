using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button undoButton;
    public Button giveNewCardsButton;

    // Gets executed by the respective button in the menu bar UI.
    public void UndoLastStep()
    {
        if (!CardGameManager.Instance.IsAutoCompleting)
            History.UndoLastStep();
    }

    // If the highcore canvas is shown, both buttons are not interactable (and the other way around).
    public void ToggleUndoButton() => undoButton.interactable = !undoButton.interactable;
    public void ToggleGiveNewCardsButton() => giveNewCardsButton.interactable = !giveNewCardsButton.interactable;

    // Gets executed by the respective button in the menu bar UI.
    public void Quit() => Application.Quit();
}
