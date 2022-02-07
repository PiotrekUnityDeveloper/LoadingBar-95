using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Image windowGraph;

    public float startingX;
    public float startingY;

    public float startingIncrementX;
    public float startingIncrementY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGraphWindow()
    {
        //windowGraph.gameObject.SetActive(true);
        //StartCoroutine(clipincreaser());
    }

    public IEnumerator clipincreaser()
    {
        yield return new WaitForSecondsRealtime(0.01f);
        /*
        //windowGraph.pixelsPerUnit += 0.1f;
        windowGraph.gameObject.transform.localScale += new Vector3(windowGraph.gameObject.transform.localScale.x + startingX, windowGraph.gameObject.transform.localScale.y + startingY, windowGraph.gameObject.transform.localScale.z);

        startingX += startingIncrementX;
        startingY += startingIncrementY;

        
        if(windowGraph.gameObject.GetComponent<RectTransform>().localScale.x > 5.98f)
        {
            //stop the loop pls
            //hope itll work :o
        }
        else
        {
            StartCoroutine(clipincreaser());
        }
        */
    }
}
