using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressDrag : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    [HideInInspector]
    public bool isDragging;

    public bool candrag = true;

    public int fingerpoints;

    public int ballpoints;
    public int balltouches;



    // Start is called before the first frame update
    void Start()
    {
        fingerpoints = 0;
    }

    // Update is called once per frame
    void Update()
    {



        //put code other than progressbar dragging here!

        if(candrag == false)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;

            mousePos = Camera.main.ScreenToWorldPoint(mousePos);


            startPosX = mousePos.x - this.gameObject.transform.localPosition.x;
            startPosY = mousePos.y - this.gameObject.transform.localPosition.y;

            isDragging = true;

            fingerpoints += 1;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;

        }

        if (Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse X") > 0)
        {
            if(Input.GetMouseButton(0))
            {
                //Vector3 mousePos;
                //mousePos = Input.mousePosition;

                //mousePos = Camera.main.ScreenToWorldPoint(mousePos);


                //startPosX = mousePos.x - this.gameObject.transform.localPosition.x;
                //startPosY = mousePos.y - this.gameObject.transform.localPosition.y;


                //isDragging = true;
            }
        }
        

        if (isDragging)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);



            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);

        }

        if (this.gameObject.transform.position.x < 3.15f)
        {
            this.gameObject.transform.position = new Vector2(3.15f, this.transform.position.y);
        }

        if (this.gameObject.transform.position.x > 9)
        {
            this.gameObject.transform.position = new Vector2(9f, this.transform.position.y);
        }

        if (this.gameObject.transform.position.y > 3.90f)
        {
            this.gameObject.transform.position = new Vector2(this.transform.position.x, 3.90f);
        }

        if (this.gameObject.transform.position.y < -4.04f)
        {
            this.gameObject.transform.position = new Vector2(this.transform.position.x, -4.04f);
        }
    }
}
