using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //ingame
    public GameObject CMDWindow;
    // public GameObject HelpWindow;
    public GameObject StopWindow;
    public GameObject PowerWindow;

    //inlobby (os-menu)

    public GameObject CMDWindowLobby;
    public GameObject PlayWindowLobby;
    public GameObject HelpWindowLobby;
    public GameObject PowerWindowLobby;

    public GameObject backgroundpanel;

    //TASKBAR
    public GameObject StartMenuObject;

    public void toggleStartMenu()
    {
        StartMenuObject.SetActive(!StartMenuObject.active);
    }

    public void ToggleStartMenuinGame()
    {
        StartMenuObject.SetActive(!StartMenuObject.active);

        if(StartMenuObject.active = true)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public GameObject backgroundimg;

    public Sprite back1;
    public Sprite back2;
    public Sprite back3;
    public Sprite back4;



    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "LB95")
        {
            switch (PlayerPrefs.GetInt("95backID", 1))
            {
                case 1:
                    backgroundimg.GetComponent<Image>().sprite = back1;
                    break;
                case 2:
                    backgroundimg.GetComponent<Image>().sprite = back2;
                    break;
                case 3:
                    backgroundimg.GetComponent<Image>().sprite = back3;
                    break;
                case 4:
                    backgroundimg.GetComponent<Image>().sprite = back4;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleCMDinGame(bool ison)
    {
        CMDWindow.SetActive(ison);

        if(CMDWindow.active == true)
        {
            Time.timeScale = 0f;
        }
        else { Time.timeScale = 1;}
    }

    public void ToggleShutDownDialog(bool ison)
    {
        PowerWindow.SetActive(ison);

        if(PowerWindow.active == true)
        {
            Time.timeScale = 0f;
        }
        else { Time.timeScale = 1; }
    }

    public void ToggleStopWindowinGame(bool ison)
    {
        StopWindow.SetActive(ison);

        if(StopWindow.active == true)
        {
            Time.timeScale = 0;

        }else { Time.timeScale = 1;}
    }

    //IN LOBBY

    public void ToggleCMDinLobby(bool ison)
    {
        CMDWindowLobby.SetActive(ison);
    }

    public void ToggleShutDownWindowinLobby(bool ison)
    {
        PowerWindowLobby.SetActive(ison);
    }

    public void TogglePlayWindow(bool ison)
    {
        PlayWindowLobby.SetActive(ison);
        //backgroundpanel.GetComponent<Animator>().SetTrigger("onfade"); //it should play on load
    }

    public void ToggleHelpWindow(bool ison)
    {
        HelpWindowLobby.SetActive(ison);
    }

    public void StopGame()
    {
        SceneManager.LoadScene("LB95");
    }
    

    //actions in menu

    public void StartGame(int gameid)
    {
        if(gameid == 1) //2-6 are normal games with different difficulties
        {
            SceneManager.LoadSceneAsync("LB95Relax");
        }
        else if (gameid == 7)
        {
            SceneManager.LoadSceneAsync("Solitaire1");
        }
        else if (gameid == 8)
        {
            SceneManager.LoadSceneAsync("ProgressolitaireRemade");
        }
        else if (gameid == 9)
        {
            SceneManager.LoadSceneAsync("MEM");
        }
        else if (gameid == 10)
        {
            SceneManager.LoadSceneAsync("Mahjong");
        }
        else if (gameid == 11)
        {
            SceneManager.LoadSceneAsync("PlayScene");
        }
        else if (gameid == 12)
        {
            print("loading puzzle scene...");
            SceneManager.LoadSceneAsync("Puzzler");
        }
        else if (gameid == 13)
        {
            SceneManager.LoadSceneAsync("ModeScene");
        }
        else if (gameid == 14)
        {
            SceneManager.LoadSceneAsync("CutLevelSelector");
        }
        else if (gameid == 15)
        {
            SceneManager.LoadSceneAsync("PhysicsLoader1");
        }
        else if (gameid == 16)
        {
            SceneManager.LoadSceneAsync("Xonix");
        }
        else if (gameid == 17)
        {
            SceneManager.LoadSceneAsync("RopeLevels");
        }

        //add other gamemodes later
    }

    //GLOBAL

    public Toggle radioshutdown;

    public void PowerPC()
    {
        if(radioshutdown.isOn == true)
        {
            //shutdown the pc 
            //Application.Quit(); load shutdown scene first
        }
        else
        {
            //restart
            //load os selection scene here
        }
    }

    public List<GameObject> GamemodePages = new List<GameObject>();

    public int pageID = 1;

    public void TurnPage(bool forward)
    {
        if(forward == true)
        {
            foreach(GameObject g in GamemodePages)
            {
                g.SetActive(false);
            }


            Debug.Log("page id is: " + pageID + " || pages count is: " + GamemodePages.Count.ToString());

            if (pageID > GamemodePages.Count) // smth not right here 
            {
                pageID = 1;
                GamemodePages[(pageID + 1)].SetActive(true);
            }
            else
            {
                GamemodePages[(pageID + 1)].SetActive(true);
            }

            Debug.Log("page id is: " + pageID + " || pages count is: " + GamemodePages.Count.ToString());

            pageID += 1;
        }
        else if(forward == false)
        {
            foreach (GameObject g in GamemodePages)
            {
                g.SetActive(false);
            }

            if (pageID < 1)
            {
                pageID = GamemodePages.Count;
                GamemodePages[(pageID - 1)].SetActive(true);
            }
            else
            {
                GamemodePages[(pageID - 1)].SetActive(true);
            }

            pageID -= 1;

            Debug.Log("page id is: " + pageID + " || pages count is: " + GamemodePages.Count.ToString());
        }

       
    }

    public void GoToPage(int page)
    {
        foreach (GameObject g in GamemodePages)
        {
            g.SetActive(false);
        }

        GamemodePages[page].SetActive(true);
    }

    
    /*

    public GameObject PageOne;
    public GameObject PageTwo; //i know i could just make a list

    public void PageSwitcher(int pageid)
    {
        switch(pageid)
        {
            case 1:
                PageOne.SetActive(true);
                PageTwo.SetActive(false);
                break;
            case 2:
                PageOne.SetActive(false);
                PageTwo.SetActive(true);
                break;
        }
    }

    public void PageFlip(bool forward)
    {
        if(forward == true)
        {
            
        }
    }

    */

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

}
