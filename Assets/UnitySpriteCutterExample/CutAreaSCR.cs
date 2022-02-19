using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutAreaSCR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int levelid;

    public Slider TimeOutSlider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*

         if (collision.tag == "TargetBall")
         {
             TimeOutSlider.GetComponent<CanvasGroup>().alpha = 1.0f;
         }
        */

        if (collision.tag == "TargetBall")
        {
            StartCoroutine(CountdowntoWin());
        }
    }

    public Text countdownText;

    public IEnumerator CountdowntoWin()
    {
        countdownText.GetComponent<CanvasGroup>().alpha = 1f;
        countdownText.text = "3";
        yield return new WaitForSecondsRealtime(1);
        countdownText.text = "2";
        yield return new WaitForSecondsRealtime(1);
        countdownText.text = "1";
        yield return new WaitForSecondsRealtime(1);
        countdownText.text = "";
        GameisWonBro();
    }

    public IEnumerator ContinuousBreaker()
    {
        StartCoroutine(ContinuousBreaker());
        yield break;
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        /*
        if (collision.tag == "TargetBall")
        {
            print("COLLIDIN");

            if(TimeOutSlider.value < 30)
            {
                TimeOutSlider.value += 0.1f;
            }
            else if(TimeOutSlider.value > 29.8f)
            {
                //win bro
                GameisWonBro();
            }
        }
        */
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*
        if (collision.tag == "TargetBall")
        {
            TimeOutSlider.value = 0;
            TimeOutSlider.GetComponent<CanvasGroup>().alpha = 0f;
        }
        */

        countdownText.text = "";

        StartCoroutine(breaker());
    }

    public IEnumerator breaker()
    {
        yield break;
    }

    public GameObject WinScreen;

    public void GameisWonBro()
    {
        //StartCoroutine(ContinuousBreaker());
        countdownText.GetComponent<CanvasGroup>().alpha = 0f;

        PlayerPrefs.SetInt(("level" + levelid), 1);
        WinScreen.SetActive(true);
    }

    public void CloseGame()
    {
        SceneManager.LoadScene("LB95");
    }

    //[SerializeField] public Scene nextLevelScene;

    public string nextSceneName;

    public void NextLevel()
    {
        SceneManager.LoadScene(/*nextLevelScene.name*/ nextSceneName);
    }

    public void OnWillRenderObject()
    {
        
    }
}