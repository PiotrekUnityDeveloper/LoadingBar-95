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
        if(gameid == 1)
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

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

}
