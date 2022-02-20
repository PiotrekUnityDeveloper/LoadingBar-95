using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutLevelManager : MonoBehaviour
{
    public int totalLevels;

    [Header("SORT FIRST PLS!!!1!")]
    public List<GameObject> levelbuttons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;

        /*
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
        } //resigned


        levelbuttons[1].GetComponent<Button>().interactable = true;
        */
    }

    public void LoadLCutevel(int levelID)
    {
        SceneManager.LoadScene("CutLevel" + levelID);
    }

    public void ExitCutGame()
    {
        SceneManager.LoadScene("LB95");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
