using UnityEngine;

public class MouseDragManager : MonoBehaviour
{
    private Camera mainCamera;
    private Card currentlyDraggedCard = null;
    private Vector2 positionLastFrame;
    private Vector2 MousePosition => mainCamera.ScreenToWorldPoint(Input.mousePosition);

    public LayerMask cardLayerMask;
    public bool debugMode;
    public static bool draggingEnabled = true;

    private void Start()
    {
        mainCamera = Camera.main;
        positionLastFrame = MousePosition;
    }

    // Manages the execution of OnBeginDrag, OnDrag and OnEndDrag of cards.
    private void Update()
    {
        if (!draggingEnabled)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D[] overlappingColliders = Physics2D.OverlapPointAll(MousePosition, cardLayerMask);

            if (overlappingColliders.Length == 0)
                return;

            Card hitCard = null;
            foreach (Collider2D collider in overlappingColliders)
            {
                Card card = collider.GetComponent<Card>();
                if (!card.IsDragable)
                    continue;
                if (hitCard == null || card.SortingOrder > hitCard.SortingOrder)
                    hitCard = card;
            }

            if (hitCard != null)
            {
                PrintDebugMessage("Drag is starting on " + currentlyDraggedCard);
                currentlyDraggedCard = hitCard;
                hitCard.OnBeginDrag();
            }
        }
        else if (Input.GetMouseButton(0) && currentlyDraggedCard != null && MousePosition != positionLastFrame)
        {
            PrintDebugMessage("Drag is continuing on " + currentlyDraggedCard);
            currentlyDraggedCard.OnDrag(MousePosition - positionLastFrame);
        }
        else if (Input.GetMouseButtonUp(0) && currentlyDraggedCard != null)
        {
            PrintDebugMessage("Drag is ending on " + currentlyDraggedCard);
            currentlyDraggedCard.OnEndDrag();
            currentlyDraggedCard = null;
        }

        positionLastFrame = MousePosition;
    }

    private void PrintDebugMessage(string message) { if (debugMode) Debug.Log(message); }
}
