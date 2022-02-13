using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SolitaireManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject CloseWindow;
    public GameObject RestartWindow;

    public void ToggleRestartDialog(bool ison)
    {
        CloseWindow.SetActive(ison);
    }

    public void ToggleCloseDialog(bool ison)
    {
        RestartWindow.SetActive(ison);
    }

    public void HideAllWindows()
    {
        CloseWindow.SetActive(false);
        RestartWindow.SetActive(false);
    }

    public void CloseGame()
    {
        SceneManager.LoadScene("LB95");   
    }
}
