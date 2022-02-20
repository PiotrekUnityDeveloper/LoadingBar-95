using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelOnclik : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)/* && GameObject.Find("WinArea").GetComponent<CutAreaSCR>().currentTool == 2*/) //buggy idk why
        {
            if(GameObject.Find("WinArea").GetComponent<CutAreaSCR>().currentTool == 2 && GameObject.Find("WinArea").GetComponent<CutAreaSCR>().remsLimited == true && GameObject.Find("WinArea").GetComponent<CutAreaSCR>().remsRemaining > 0)
            {
                GameObject.Find("WinArea").GetComponent<CutAreaSCR>().ObjectDestroyed();
                Destroy(this.gameObject);
            }
            else if(GameObject.Find("WinArea").GetComponent<CutAreaSCR>().remsLimited == false && GameObject.Find("WinArea").GetComponent<CutAreaSCR>().currentTool == 2)
            {
                GameObject.Find("WinArea").GetComponent<CutAreaSCR>().ObjectDestroyed();
                Destroy(this.gameObject);
            }
        }
    }

    
}
