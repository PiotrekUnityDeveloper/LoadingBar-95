using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutLevelManager : MonoBehaviour
{
    public int totalLevels;

    [Header("SORT FIRST PLS!!!1!")]
    public List<GameObject> levelbuttons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < totalLevels; i++)
        {
            if(PlayerPrefs.GetInt("level" + i) == 1)
            {
                levelbuttons[i].GetComponent<Button>().interactable = true;
            }
            else if (PlayerPrefs.GetInt("level" + i) == 0)
            {
                levelbuttons[i].GetComponent<Button>().interactable = false;
            }
        }

        levelbuttons[1].GetComponent<Button>().interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
