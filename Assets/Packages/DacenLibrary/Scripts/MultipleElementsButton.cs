using UnityEngine;
using UnityEngine.UI;

public class MultipleElementsButton : Button
{
    public Graphic[] targetGraphics;
    public ButtonClickedEvent _onClick;

    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        Color newColor = Color.white;
        switch (state)
        {
            case SelectionState.Normal:      newColor = colors.normalColor;      break;
            case SelectionState.Highlighted: newColor = colors.highlightedColor; break;
            case SelectionState.Pressed:     newColor = colors.pressedColor;     break;
            case SelectionState.Selected:    newColor = colors.selectedColor;    break;
            case SelectionState.Disabled:    newColor = colors.disabledColor;    break;
        }

        foreach (Graphic graphic in targetGraphics)
            if(graphic != null)
                graphic.CrossFadeColor(newColor, instant ? 0 : colors.fadeDuration, true, true);
    }
}
