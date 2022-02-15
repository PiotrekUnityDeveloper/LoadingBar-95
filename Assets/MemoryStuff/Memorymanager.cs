using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Memorymanager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartMEMGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CLoseGame()
    {
        SceneManager.LoadScene("LB95");
    }

    public GameObject PauseWindow;

    public void ToggleWindow(bool state)
    {
        PauseWindow.SetActive(state);
    }
}
