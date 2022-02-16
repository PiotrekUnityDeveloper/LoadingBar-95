using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MahjongManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        StartCoroutine(pointcounter());
    }

    public IEnumerator pointcounter()
    {
        yield return new WaitForSecondsRealtime(1);

        PlayerPrefs.SetInt("Mahjong", (PlayerPrefs.GetInt("Mahjong", 0) + 10));
        StartCoroutine(pointcounter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject PauseWindow;

    public void TogglePausedMenu(bool ispaused)
    {
        PauseWindow.SetActive(ispaused);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("LB95");
    }

}
