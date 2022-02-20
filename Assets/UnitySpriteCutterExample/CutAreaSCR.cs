using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutAreaSCR : MonoBehaviour
{
    public bool isEnded = false;
    public bool isTouching = false;

    public Text Leveltxt;

    public Text TrashCanText;

    //removing vals

    public int remsRemaining;
    public bool remsLimited;

    private void FixedUpdate()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Leveltxt.text = "Level " + levelid.ToString();

        Screen.orientation = ScreenOrientation.Landscape;

        if (SceneManager.GetActiveScene().name != "CutLevel1" && SceneManager.GetActiveScene().name != "CutLevel2" && SceneManager.GetActiveScene().name != "CutLevel3" && SceneManager.GetActiveScene().name != "CutLevel4")
        {
            SwitchTool(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "CutLevel1" && SceneManager.GetActiveScene().name != "CutLevel2" && SceneManager.GetActiveScene().name != "CutLevel3" && SceneManager.GetActiveScene().name != "CutLevel4"){
            if (remsLimited == true)
            {
                TrashCanText.text = "your trashcan have " + remsRemaining + " slots left";
            }
            else
            {
                TrashCanText.text = "your trash can is a black hole";
            }
        }




       
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
            isTouching = true;
            StartCoroutine(CountdowntoWin());
        }
    }



    public int currentTool = 1;

    public Text CutText;
    public Text RemoveText;

    public Button CutBtn;
    public Button RemoveBtn;
    public AudioSource switchsound;

    public ColorBlock active;
    public ColorBlock unactive;

    public List<Image> CutImgs = new List<Image>();
    public List<Image> RemoveImgs = new List<Image>();

    public void SwitchTool(int toolID) //1==cut; 2==remove;
    {
        unactive.normalColor = new Color(255, 204, 0);
        active.normalColor = new Color(31, 31, 31);

        switchsound.Play();

        if(toolID == 1) //cut
        {
            //setting up the cut tool
            currentTool = 1;
            CutBtn.colors = active;
            CutText.color = unactive.normalColor;

            foreach (Image i in CutImgs)
            {
                i.color = unactive.normalColor;
            }

            //now remove tool
            RemoveBtn.colors = unactive;
            RemoveText.color = active.normalColor;

            foreach(Image j in RemoveImgs)
            {
                j.color = active.normalColor;
            }
        }
        else if (toolID == 2) //remove
        {
            //setting up the cut tool
            currentTool = 2;
            CutBtn.colors = unactive;
            CutText.color = active.normalColor;

            foreach (Image i in CutImgs)
            {
                i.color = active.normalColor;
            }

            //now remove tool
            RemoveBtn.colors = active;
            RemoveText.color = unactive.normalColor;

            foreach (Image j in RemoveImgs)
            {
                j.color = unactive.normalColor;
            }
        }
    }


    public void ObjectDestroyed()
    {
        if(remsLimited == true)
        {
            remsRemaining -= 1;
        }
    }


    public Text countdownText;

    public IEnumerator CountdowntoWin()
    {
        countdownText.GetComponent<CanvasGroup>().alpha = 1f;
        countdownText.text = "3";
        yield return new WaitForSecondsRealtime(1);
        
        if(isTouching == true)
        {
            countdownText.text = "2";
        }
        else
        {
            countdownText.GetComponent<CanvasGroup>().alpha = 0f;
            StartCoroutine(breaker());
        }

        yield return new WaitForSecondsRealtime(1);

        if (isTouching == true)
        {
            countdownText.text = "1";
        }
        else
        {
            countdownText.GetComponent<CanvasGroup>().alpha = 0f;
            StartCoroutine(breaker());
        }

        yield return new WaitForSecondsRealtime(1);
        countdownText.text = "";
        
        if(isTouching == true)
        {
            GameisWonBro();
        }
    }

    public IEnumerator ContinuousBreaker()
    {
        StartCoroutine(ContinuousBreaker());
        yield break;
        // DONT USE - STACKOVERFLOW ERROR OCCURS
    }

    public List<GameObject> hints = new List<GameObject>();
    public int currentHintID = 1;

    public void ShowHint()
    {
        /*
        if(currentHintID < hints.Count)
        {
            hints[currentHintID].SetActive(true);
            currentHintID++;
        }

        
        if(currentHintID == 1)
        {
            hints[1].SetActive(true);
            currentHintID++;
        }
        */

        foreach(GameObject g in hints)
        {
            g.SetActive(true);
        }
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

        

        if (collision.tag == "TargetBall")
        {
            isTouching = false;

            countdownText.text = "";

            StartCoroutine(breaker());
        }
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

        isEnded = true;
        PlayerPrefs.SetInt(("level" + levelid), 1);
        WinScreen.SetActive(true);
    }

    public void CloseGame()
    {
        SceneManager.LoadScene("CutLevelSelector");
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
