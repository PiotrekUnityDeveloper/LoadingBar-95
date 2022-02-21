using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectManager : MonoBehaviour
{
    public bool isLandscape;

    // Start is called before the first frame update
    void Start()
    {
        if (isLandscape == true)
        {
            Screen.orientation = ScreenOrientation.Landscape;
        }
        else
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
