using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Puzzle", 1);
        Screen.orientation = ScreenOrientation.Landscape;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject PauseWindowObject;

    public void PauseWindow(bool isok)
    {
        PauseWindowObject.SetActive(isok);
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("LB95");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
