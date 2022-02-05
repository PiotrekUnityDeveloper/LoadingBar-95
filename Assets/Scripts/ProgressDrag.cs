using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressDrag : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isDragging;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;

            mousePos = Camera.main.ScreenToWorldPoint(mousePos);


            startPosX = mousePos.x - this.gameObject.transform.localPosition.x;
            startPosY = mousePos.y - this.gameObject.transform.localPosition.y;

            isDragging = true;
        }

        if(Input.GetMouseButtonUp(0))
        {
            isDragging=false;

        }

        if(isDragging)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);



            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);

        }
    }
}
