using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Image windowGraph;

    public float startingX;
    public float startingY;

    public float startingIncrementX;
    public float startingIncrementY;

    public Text finalList;

    //windows
    public GameObject graphwindow;
    public GameObject progresswindow;
    public GameObject badgestatswindow;
    public GameObject overallprogresswindow;
    public GameObject backgroundswindow;
    public GameObject rewardwindow;
    public GameObject tempchallengeswindow; //aka OBJECTIVES idk

    //window interactable stuff
    public GameObject win2button;

    //level
    public int currentLevel;




    //progressing
    public int ProLevels = 10;
    public int ExpertLevels = 20;
    public int MasterLevels = 50;
    public int GrandMasterLevels = 100;
    public int WarriorLevels = 250;

    [Header("CHAOTIC SECTION")]
    public bool isChaos;

    //conditions
    [Tooltip("PRO BADGE BOOST - from 5000 to 7500")]
    public bool isPro;
    [Tooltip("EXPERT BADGE BOOST - from 7500 to 10000")]
    public bool isExpert;
    [Tooltip("MASTER BADGE BOOST - from 10000 to 12500")]
    public bool isMaster;
    [Tooltip("GRANDMASTER BADGE BOOST - from 12500 to 17500")]
    public bool isGrandMaster;
    [Tooltip("WARRIOR BADGE BOOST - from 17500 to 25000")]
    public bool isWarrior;

    //progressing prefabs
    public GameObject progressinfoPrefab;
    public GameObject infoinstantiotor;
    public Animator prginfoanimator;
    public Text totalpointslabel;
    public Text incrementpointslabel;
    public Animator labelanimmmmmmmmmmmmmmmmmator;

    public Text realscoreincreasinglabel;

    //sliders
    public Slider levelslider;

    //vals
    public float progresspointsmultiplier;
    public int leveltype;
    public int SessionPoints;
    int randomstartingprogress;

    public GameObject completeobjectprefab;

    public GameObject completechaosprefab;

    //other vals
    public int clippysdestroyed;

    [Header("Textures for point badges")]

    //textures
    public Sprite ProgressPoints;

    public Sprite Perfect;
    public Sprite Pro;
    public Sprite Win95;
    public Sprite Completed;

    public Sprite Relax;
    public Sprite Easy;
    public Sprite Medium;
    public Sprite Hard;
    public Sprite VeryHard;
    public Sprite Hardcore;

    public Sprite Yinyang;
    public Sprite Minusonehundred;
    public Sprite Symetric;

    public Sprite TempChallenge;

    public Sprite Mahjong;

    public Sprite AFK;
    public Sprite ClippyCancel;

    public Sprite Levelup;
    public Sprite Minesweeper;

    public Sprite MEMGame;

    public Sprite less100;
    public Sprite less200;

    public Sprite SolitaireJR;

    //now
    public Sprite Stripes1; //blue first
    public Sprite Stripes2; //orange first

    public Sprite ThickStriper1; //blue first
    public Sprite ThickStripes2; //orange first

    //even more
    public Sprite Solitaire;

    //other
    [Header("Other Stuff")]

    public Text progresstxt;
     

    public List<string> progressstuff = new List<string>();


    //bonuses

    public int catchedcats;
    public int catchedbonus;

    //SOUND EFFECTS (too lazy to make a class for it lol)
    //[Header("SOUND EFFECTS")]
    //public AudioSource collect;    MOVED TO TILECATCHER
    //public AudioSource pointadd;    MOVED TO TILECATCHER
    //public AudioSource ballcollision; 

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
    }

    public void launchprogressing()
    {
        StartCoroutine(startprogressing());
    }

    public IEnumerator startprogressing()
    {
        currentLevel = PlayerPrefs.GetInt("95level", 0);

        graphwindow.SetActive(false);
        progresswindow.SetActive(true);

        StartCoroutine(levelup());
        SessionPoints = 0;
        yield return new WaitForSecondsRealtime(1.8f);


        currentLevel += 1;
        PlayerPrefs.SetInt("95level", currentLevel);

        if(PlayerPrefs.GetInt("MemoryGame", 0) == 1)
        {
            progressstuff.Add("Memory");
        }
        
        
        if(isPro)
        {
            levelslider.maxValue = ProLevels;
            //progressstuff.Add("Pro");
        }
        else if(isExpert)
        {
            levelslider.maxValue = ExpertLevels;
            //progressstuff.Add("Expert");
        }
        else if(isMaster)
        {
            levelslider.maxValue = MasterLevels;
            //progressstuff.Add("Master");
        }
        else if (isGrandMaster)
        {
            levelslider.maxValue = MasterLevels;
            //progressstuff.Add("GrandMaster");
        }
        else if (isWarrior)
        {
            levelslider.maxValue = MasterLevels;
            //progressstuff.Add("Warrior");
        }

        if(PlayerPrefs.GetInt("SolitaireBonus", 0) > 0)
        {
            progressstuff.Add("SolitaireBonus");
        }

        if (PlayerPrefs.GetInt("SimpleSolitaireBonus", 0) > 0)
        {
            progressstuff.Add("SimpleSolitaireBonus");
        }


        if (isChaos == true)
        {
            progressstuff.Add("Chaos");
        }

        if(clippysdestroyed > 0)
        {
            progressstuff.Add("Clippy_Points");
        }

        levelslider.value = currentLevel;
        

        if(ProLevels == levelslider.value)
        {
            isPro = true;
        }

        if (ExpertLevels == levelslider.value)
        {
            isExpert = true;
        }

        if (MasterLevels == levelslider.value)
        {
            isMaster = true;
        }

        if (GrandMasterLevels == levelslider.value)
        {
            isGrandMaster = true;
        }

        if (WarriorLevels == levelslider.value)
        {
            isWarrior = true;
        }

        if(PlayerPrefs.GetInt("p1c1", 0) == 5000)
        {
            progressstuff.Add("TempC");
        }

        if (PlayerPrefs.GetInt("p1c2", 0) == 5000)
        {
            progressstuff.Add("TempC");
        }
        if (PlayerPrefs.GetInt("p1c3", 0) == 5000)
        {
            progressstuff.Add("TempC");
        }

        if (PlayerPrefs.GetInt("p2c1", 0) == 5000)
        {
            progressstuff.Add("TempC");
        }

        if (PlayerPrefs.GetInt("p2c2", 0) == 5000)
        {
            progressstuff.Add("TempC");
        }

        if (PlayerPrefs.GetInt("p2c3", 0) == 5000)
        {
            progressstuff.Add("TempC");
        }

        if(PlayerPrefs.GetInt("LessThan100") == 1)
        {
            progressstuff.Add("Less100");
        }

        if (PlayerPrefs.GetInt("LessThan200") == 1)
        {
            progressstuff.Add("Less200");
        }

        PlayerPrefs.DeleteKey("LessThan200");
        PlayerPrefs.DeleteKey("LessThan100");

        PlayerPrefs.DeleteKey("p1c1");
        PlayerPrefs.DeleteKey("p1c2");
        PlayerPrefs.DeleteKey("p1c3");
        PlayerPrefs.DeleteKey("p2c1");
        PlayerPrefs.DeleteKey("p2c2");
        PlayerPrefs.DeleteKey("p2c3");


        if (isWarrior)
        {
            progressstuff.Add("Warrior");
            //progressstuff.Add("GrandMaster");
            //progressstuff.Add("Master");
            //progressstuff.Add("Expert");
            //progressstuff.Add("Pro");
        }
        else if(isGrandMaster)
        {
            progressstuff.Add("GrandMaster");
            //progressstuff.Add("Master");
            //progressstuff.Add("Expert");
            //progressstuff.Add("Pro");
        }
        else if (isMaster)
        {
            progressstuff.Add("Master");
            //progressstuff.Add("Expert");
            //progressstuff.Add("Pro");
        }
        else if(isExpert)
        {
            progressstuff.Add("Expert");
            //progressstuff.Add("Pro");
        }
        else if(isPro)
        {
            progressstuff.Add("Pro");
        }

        //DEFAULT PROGRESS POINTS (CHANGEABLE)

        ProgressDrag pddd3 = GameObject.Find("DragParent").GetComponent<ProgressDrag>();

        if (pddd3.fingerpoints < 1)
        {
            //p2c2progress.value = p2c2progress.maxValue;
            progressstuff.Add("AFK");
        }





        //randomstartingprogress = Random.Range(1500, 10000);

        //randomstartingprogress = Mathf.Round(randomstartingprogress); THIS IS AN INT

        if (leveltype == 1) //RELAX
        {
            randomstartingprogress = Random.Range(1500, 2800);
            progressstuff.Add("Relax");
        }
        else if (leveltype == 2) //EASY
        {
            randomstartingprogress = Random.Range(2800, 6900);
            progressstuff.Add("Easy");
        }
        else if(leveltype == 3) //NORMAL
        {
            randomstartingprogress = Random.Range(7000, 14000);
            progressstuff.Add("Normal");
        }
        else if (leveltype == 4) //HARD
        {
            randomstartingprogress = Random.Range(14000, 19900);
            progressstuff.Add("Hard");
        }
        else if (leveltype == 5) //VERY HARD
        {
            randomstartingprogress = Random.Range(19900, 26000);
            progressstuff.Add("VeryHard");
        }
        else if (leveltype == 6) //HARDCORE
        {
            randomstartingprogress = Random.Range(26000, 40000);
            progressstuff.Add("Hardcore");
        }

        if(PlayerPrefs.GetInt("Mahjong", 0) > 0)
        {
            progressstuff.Add("MahjongGame");
        }

        if(PlayerPrefs.GetInt("Minesweeper", 0) == 1)
        {
            progressstuff.Add("Minesweeper");
        }

        PlayerPrefs.DeleteKey("Mahjong");

        progressstuff.Add("Progress Points");
        progressstuff.Add("Win95");
        progressstuff.Add("Levelup");

        GameObject instG = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
        instG.transform.parent = GameObject.Find("inst").transform;
        instG.GetComponent<Image>().sprite = ProgressPoints;
        //progresstxt = instG.transform.GetChild(0).GetComponent<Text>();
        //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
        //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
        //incrementpointslabel = instG.transform.GetChild(0).GetComponent<Text>();
        instG.GetComponent<Animator>().SetTrigger("newPoint");
        print("randomized number is " + randomstartingprogress);
        labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
        for (int i = 0; i < randomstartingprogress; i+=200)
        {
            yield return new WaitForSecondsRealtime(0.0000001f);
            //incrementpointslabel.text = ("Progress Score: " + i);
            realscoreincreasinglabel.text = ("Progress Score: " + i);
        }

        if (instG != null)
        {
            instG.GetComponent<Animator>().SetTrigger("delPoint");
        }
        yield return new WaitForSecondsRealtime(0.5f);
        SessionPoints += randomstartingprogress;
        totalpointslabel.text = ("Total Points: " + SessionPoints);
        
        labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");

        //yield return new WaitForSecondsRealtime(1.5f);

        progressstuff.Add("Complete Game");

        foreach (string s in progressstuff)
        {
            yield return new WaitForSecondsRealtime(0.8f);

            //if(s == "") //ADD THIS VALUE TO SESSION POINTSs
            if (s=="Pro")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = Pro;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = Random.Range(5000, 7500);
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i+=10)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Pro Badge: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if(instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }
                
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "Minesweeper")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = Minesweeper;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = Random.Range(500, 5000);
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 10)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Minesweeper Warrior!: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "MahjongGame")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = Mahjong;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = PlayerPrefs.GetInt("Mahjong", 0);
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 100)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Your Mahjong Game: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "Clippy_Points")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = ClippyCancel;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    //randomstartingprogress = Random.Range(5000, 7500);
                    randomstartingprogress = 20 * clippysdestroyed;
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 10)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Cancelled Clippys: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "Stripes1")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = Stripes1;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = Random.Range(5000, 7500);
                    //randomstartingprogress = 20 * clippysdestroyed;
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 10)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("B-Y Stripes: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "Memory")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = MEMGame;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = Random.Range(5000, 7500) + 2500;
                    //randomstartingprogress = 20 * clippysdestroyed;
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 10)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Your Last Memory Game: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "Stripes2")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = Stripes2;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = Random.Range(5000, 7500);
                    //randomstartingprogress = 20 * clippysdestroyed;
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 10)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Y-B Stripes: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            //SolitaireBonus

            if (s == "SolitaireBonus")
            {
                GameObject instG2 = Instantiate(completeobjectprefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = Solitaire;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = PlayerPrefs.GetInt("SolitaireBonus", 0);
                    //randomstartingprogress = 20 * clippysdestroyed;
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 1000)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Solitaire Bonus: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");

                PlayerPrefs.DeleteKey("SolitaireBonus");
                Destroy(instG2);
            }

            if (s == "SimpleSolitaireBonus")
            {
                GameObject instG2 = Instantiate(completeobjectprefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = SolitaireJR;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = PlayerPrefs.GetInt("SimpleSolitaireBonus", 0);
                    //randomstartingprogress = 20 * clippysdestroyed;
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 1000)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("SolitaireJR Bonus: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");

                PlayerPrefs.DeleteKey("SimpleSolitaireBonus");
                Destroy(instG2);
            }

            if (s == "Less100")
            {
                GameObject instG2 = Instantiate(completeobjectprefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = less100;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = Random.Range(9000, 12050);
                    //randomstartingprogress = 20 * clippysdestroyed;
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 1000)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Less than 100 moves: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");

                //PlayerPrefs.DeleteKey("SimpleSolitaireBonus");
                Destroy(instG2);
            }

            if (s == "Less200")
            {
                GameObject instG2 = Instantiate(completeobjectprefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = less200;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = Random.Range(5500, 6750);
                    //randomstartingprogress = 20 * clippysdestroyed;
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 1000)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Less than 200 moves: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");

                //PlayerPrefs.DeleteKey("SimpleSolitaireBonus");
                Destroy(instG2);
            }

            if (s == "Chaos")
            {
                GameObject instG2 = Instantiate(completechaosprefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    //instG2.transform.parent = GameObject.Find("inst").transform;
                    //instG2.GetComponent<Image>().sprite = ClippyCancel;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = Random.Range(50000, 75000);
                    //randomstartingprogress = 20 * clippysdestroyed;
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 1000)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("TRUE CHAOS!!!!: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "AFK")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = AFK;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    
                    if(leveltype < 4)
                    {
                        randomstartingprogress = 250;
                    }
                    else if (leveltype > 3 && leveltype < 6)
                    {
                        randomstartingprogress = Random.Range(15000, 21000);
                    }
                    else if(leveltype == 6)
                    {
                        randomstartingprogress = Random.Range(50000, 90000);
                    }
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 200)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Pro Badge: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "TempC")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = TempChallenge;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = 5000;
                }
                print("TempC number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 10) //CHANGE 50 TO 10 ITS THE TRANSITION IS TOO FAST
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Temporary Challenge: " + i);
                }
                yield return new WaitForSecondsRealtime(0.8f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "Expert")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = ExpertBadge;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = Random.Range(7500, 10000);
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 50)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Expert Badge: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "Symetric")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = Symetric;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = Random.Range(9000, 9900);
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 50)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Symetric Progress: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "Master")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = MasterBadge;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = Random.Range(10000, 12500);
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 100)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Master Badge: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "GrandMaster")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = GrandMasterBadge;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = Random.Range(12500, 17500);
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 150)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("GrandMaster Badge: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "Warrior")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = WarriorBadge;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = Random.Range(10000, 12500);
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 100)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Warrior Badge: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "Relax")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = Relax;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = Random.Range(5, 100);
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 1)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Relax Difficulty: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "Easy")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = Easy;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = Random.Range(200, 900);
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 5)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Easy Difficulty: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "Normal")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = Medium;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = Random.Range(1000, 5500);
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 10)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Normal Difficulty: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "Hard")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = Hard;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = Random.Range(6000, 9999);
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 50)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Hard Difficulty: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "VeryHard")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = VeryHard;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = Random.Range(10000, 15000);
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 100)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Very Hard Difficulty: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "Hardcore")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = Hardcore;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = Random.Range(17500, 25000);
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 250)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("HARDCORE! Difficulty: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "Levelup")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = Levelup;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                    randomstartingprogress = Random.Range(250, 2800);
                }
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 5)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Level up!: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }

                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "Perfect")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = Perfect;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                }
                randomstartingprogress = Random.Range(1000, 3200);
                //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i+=5)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Perfectionist: " + i);
                    realscoreincreasinglabel.text = ("Perfectionist!: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "Yin&Yang")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = Yinyang;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                }
                randomstartingprogress = Random.Range(1800, 3200);
                //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 10)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Perfectionist: " + i);
                    realscoreincreasinglabel.text = ("Yin&Yang: " + i);
                }
                yield return new WaitForSecondsRealtime(1f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "Invert")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = Minusonehundred;
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                }
                randomstartingprogress = Random.Range(4000, 6750);
                //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                for (int i = 0; i < randomstartingprogress; i += 10)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Perfectionist: " + i);
                    realscoreincreasinglabel.text = ("Yin&Yang: " + i);
                }
                yield return new WaitForSecondsRealtime(0.9f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }

            if (s == "Win95")
            {
                yield return new WaitForSecondsRealtime(0.4f);
                GameObject instG4 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if(instG4 != null)
                {
                    instG4.transform.parent = GameObject.Find("inst").transform;
                    instG4.GetComponent<Image>().sprite = Win95;
                    //progresstxt = instG.transform.GetChild(0).GetComponent<Text>();
                    //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                    //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                    //incrementpointslabel = instG.transform.GetChild(0).GetComponent<Text>();
                    instG4.GetComponent<Animator>().SetTrigger("newPoint");
                }
                
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                randomstartingprogress = Random.Range(450, 9000);
                for (int i = 0; i < randomstartingprogress; i+=20)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("LoadingBar 95: " + i);
                    realscoreincreasinglabel.text = ("LoadingBar 95: " + i);
                }

                if (instG4 != null)
                {
                    instG4.GetComponent<Animator>().SetTrigger("delPoint");
                }
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                yield return new WaitForSecondsRealtime(1f);
                if (instG4 != null)
                {
                    instG4.GetComponent<Animator>().SetTrigger("delPoint");
                }
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                
                Destroy(instG4);
            }

            if (s == "Complete Game")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                if (instG2 != null)
                {
                    instG2.transform.parent = GameObject.Find("inst").transform;
                    instG2.GetComponent<Image>().sprite = Completed;
                }
                //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                //progresstxt = instG2.transform.GetChild(0).GetComponent<Text>();

                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("newPoint");
                }
                randomstartingprogress = 0;
                print("randomized number is " + randomstartingprogress);
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("label1");
                realscoreincreasinglabel.text = ("Well done!");
                yield return new WaitForSecondsRealtime(1.45f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if (instG2 != null)
                {
                    instG2.GetComponent<Animator>().SetTrigger("delPoint");
                }
                labelanimmmmmmmmmmmmmmmmmator.SetTrigger("close");
                Destroy(instG2);
            }


        }

        foreach(string s in progressstuff)
        {
            if(s != null)
            {
                finalList.text += ($"\n" + "-> " + s);
            }
            
        }

        progressstuff.Clear();

        yield return new WaitForSecondsRealtime(1.1f);

        win2button.SetActive(true);

    }

    //window 3 animators
    public Animator win3animator;

    //labels
    public Text currentbadge;
    public Text nextbadge;
    public Text totalaquired;
    public Text badgesleft;
    public Text nextbadgein;

    public Text currentbonus;
    public Text nextbonus;

    //images
    public Image oldb;
    public Image newb;

    /*
     [Tooltip("PRO BADGE BOOST - from 5000 to 7500")]
    public bool isPro;
    [Tooltip("EXPERT BADGE BOOST - from 7500 to 10000")]
    public bool isExpert;
    [Tooltip("MASTER BADGE BOOST - from 10000 to 12500")]
    public bool isMaster;
    [Tooltip("GRANDMASTER BADGE BOOST - from 12500 to 17500")]
    public bool isGrandMaster;
    [Tooltip("PRO BADGE BOOST - from 17500 to 25000")]
    public bool isWarrior; */


    //sprites
    public Sprite ProBadge;
    public Sprite ExpertBadge;
    public Sprite MasterBadge;
    public Sprite GrandMasterBadge;
    public Sprite WarriorBadge;

    public void openbadgestats()
    {
        StartCoroutine(window3buttoncooldown());
        graphwindow.SetActive(false);
        progresswindow.SetActive(false);
        badgestatswindow.SetActive(true);
        win3animator.SetTrigger("open");

        oldb.gameObject.SetActive(true);
        newb.gameObject.SetActive(true);

        if (isWarrior == true)
        {
            currentbadge.text = "Warrior";
            nextbadge.text = "None";
            totalaquired.text = "5";
            badgesleft.text = "0";
            nextbadgein.text = "NaN";
            currentbonus.text = "17500-25000 points";
            nextbonus.text = "NaN";
            oldb.gameObject.SetActive(false);
            newb.sprite = WarriorBadge;
        }
        else if (isGrandMaster == true)
        {
            currentbadge.text = "GrandMaster";
            nextbadge.text = "Warrior";
            totalaquired.text = "4";
            badgesleft.text = "1";
            nextbadgein.text = (WarriorLevels - currentLevel).ToString();
            currentbonus.text = "12500-17500 points";
            nextbonus.text = "17500-25000 points";
            oldb.sprite = GrandMasterBadge;
            newb.sprite = WarriorBadge;
        }
        else if (isMaster == true)
        {
            currentbadge.text = "Master";
            nextbadge.text = "GrandMaster";
            totalaquired.text = "3";
            badgesleft.text = "2";
            nextbadgein.text = (GrandMasterLevels - currentLevel).ToString();
            currentbonus.text = "10000-12500 points";
            nextbonus.text = "12500-17500 points";
            oldb.sprite = MasterBadge;
            newb.sprite = GrandMasterBadge;
        }
        else if(isExpert == true)
        {
            currentbadge.text = "Expert";
            nextbadge.text = "Master";
            totalaquired.text = "2";
            badgesleft.text = "3";
            nextbadgein.text = (MasterLevels - currentLevel).ToString();
            currentbonus.text = "7500-10000 points";
            nextbonus.text = "10000-12500 points";
            oldb.sprite = ExpertBadge;
            newb.sprite = MasterBadge;
        }
        else if(isPro == true)
        {
            currentbadge.text = "Pro";
            nextbadge.text = "Expert";
            totalaquired.text = "1";
            badgesleft.text = "4";
            nextbadgein.text = (ExpertLevels - currentLevel).ToString();
            currentbonus.text = "5000-7500 points";
            nextbonus.text = "7500-10000 points";
            oldb.sprite = ProBadge;
            newb.sprite = ExpertBadge;
        }
        else
        {
            currentbadge.text = "None";
            nextbadge.text = "Pro";
            totalaquired.text = "0";
            badgesleft.text = "5";
            nextbadgein.text = (ProLevels - currentLevel).ToString();
            currentbonus.text = "0 points";
            nextbonus.text = "5000-7500 points";
            oldb.gameObject.SetActive(false);
            newb.sprite = ProBadge;
        }

        

    }

    public GameObject thirdButton;

    public IEnumerator window3buttoncooldown()
    {
        thirdButton.SetActive(false);
        yield return new WaitForSecondsRealtime(1.9f);
        thirdButton.SetActive(true);
    }

    public void showfouthwindow()
    {
        badgestatswindow.SetActive(false);
        overallprogresswindow.SetActive(true);
        StartCoroutine(overallprogressbarwindow());
    }

    //win4elements
    public Image nextOS;
    public Slider ovprogressslider;

    //checkpoints
    private int soundvalue = 50000;
    private int screenvalue = 120000;
    private int RAMvalue = 180000;
    private int graphcardvalue = 260000;
    private int processorvalue = 400000;

    //infowindows
    public GameObject soundupgradeWindow;
    public GameObject screenupgradeWindow;
    public GameObject RAMupgradeWindow;
    public GameObject graphicsupgradeWidnow;
    public GameObject processorupgradeWidnow;

    //OStextures
    public Sprite LB95;

    //buttons
    public GameObject win4button;

    public Text progresstextinfo;


    public IEnumerator overallprogressbarwindow()
    {
        StartCoroutine(emergencybuttonactivator());

        ovprogressslider.value = PlayerPrefs.GetFloat("savedprogress", 0);

        if(ovprogressslider.value > (ovprogressslider.maxValue - 1000))
        {
            ovprogressslider.value = 0;
        }

        if(SessionPoints > (ovprogressslider.maxValue - ovprogressslider.value))
        {
            for (int i = 0; i < ovprogressslider.value - 20; i += 20)
            {
                yield return new WaitForSecondsRealtime(0.00001f);
                ovprogressslider.value += 5;

                if (i == soundvalue)
                {
                    soundupgradeWindow.SetActive(true);
                    soundupgradeWindow.GetComponent<Animator>().SetTrigger("showme");
                }
                else if (i == screenvalue)
                {
                    screenupgradeWindow.SetActive(true);
                    screenupgradeWindow.GetComponent<Animator>().SetTrigger("showme");
                }
                else if (i == RAMvalue)
                {
                    RAMupgradeWindow.SetActive(true);
                    RAMupgradeWindow.GetComponent<Animator>().SetTrigger("showme");
                }
                else if (i == graphcardvalue)
                {
                    graphicsupgradeWidnow.SetActive(true);
                    graphicsupgradeWidnow.GetComponent<Animator>().SetTrigger("showme");
                }
                else if (i == processorvalue)
                {
                    processorupgradeWidnow.SetActive(true);
                    processorupgradeWidnow.GetComponent<Animator>().SetTrigger("showme");
                }
            }
        }
        else
        {
            /*
            print(SessionPoints + " tyle jest punktow");

            for (int i = SessionPoints; i > 5; i -= 5)
            {
                yield return new WaitForSecondsRealtime(0.00001f);
                ovprogressslider.value += 5;

                if (i == soundvalue)
                {
                    soundupgradeWindow.SetActive(true);
                    print("warots i = " + i + "   " + "warotsc progresbara= " + ovprogressslider.value);
                    soundupgradeWindow.GetComponent<Animator>().SetTrigger("showme");
                }
                else if (i == screenvalue)
                {
                    screenupgradeWindow.SetActive(true);
                    screenupgradeWindow.GetComponent<Animator>().SetTrigger("showme");
                }
                else if (i == RAMvalue)
                {
                    RAMupgradeWindow.SetActive(true);
                    RAMupgradeWindow.GetComponent<Animator>().SetTrigger("showme");
                }
                else if (i == graphcardvalue)
                {
                    graphicsupgradeWidnow.SetActive(true);
                    graphicsupgradeWidnow.GetComponent<Animator>().SetTrigger("showme");
                }
                else if (i == processorvalue)
                {
                    processorupgradeWidnow.SetActive(true);
                    processorupgradeWidnow.GetComponent<Animator>().SetTrigger("showme");
                }
            }
            */

            for(int i = 0; i < SessionPoints; i+=20)
            {
                yield return new WaitForSeconds(0.000001f);
                ovprogressslider.value += 20;
                progresstextinfo.text = (i.ToString());

                if (i == soundvalue)
                {
                    soundupgradeWindow.SetActive(true);
                    print("warots i = " + i + "   " + "warotsc progresbara= " + ovprogressslider.value);
                    soundupgradeWindow.GetComponent<Animator>().SetTrigger("showme");
                }
                else if (i == screenvalue)
                {
                    screenupgradeWindow.SetActive(true);
                    screenupgradeWindow.GetComponent<Animator>().SetTrigger("showme");
                }
                else if (i == RAMvalue)
                {
                    RAMupgradeWindow.SetActive(true);
                    RAMupgradeWindow.GetComponent<Animator>().SetTrigger("showme");
                }
                else if (i == graphcardvalue)
                {
                    graphicsupgradeWidnow.SetActive(true);
                    graphicsupgradeWidnow.GetComponent<Animator>().SetTrigger("showme");
                }
                else if (i == processorvalue)
                {
                    processorupgradeWidnow.SetActive(true);
                    processorupgradeWidnow.GetComponent<Animator>().SetTrigger("showme");
                }
            }
        }

        if (PlayerPrefs.GetFloat("savedprogress", 0) < processorvalue)
        {
            //do nothing
            if(ovprogressslider.value > processorvalue)
            {
                processorupgradeWidnow.SetActive(true);
                //processorupgradeWidnow.GetComponent<Animator>().SetTrigger("showme");
            }
        }
        else if (PlayerPrefs.GetFloat("savedprogress", 0) > graphcardvalue)
        {
            if (ovprogressslider.value > processorvalue)
            {
                processorupgradeWidnow.SetActive(true);
                //processorupgradeWidnow.GetComponent<Animator>().SetTrigger("showme");
            }

            if(ovprogressslider.value > graphcardvalue)
            {
                graphicsupgradeWidnow.SetActive(true);
            }
        }
        else if (PlayerPrefs.GetFloat("savedprogress", 0) > RAMvalue)
        {
            if (ovprogressslider.value > processorvalue)
            {
                processorupgradeWidnow.SetActive(true);
                //processorupgradeWidnow.GetComponent<Animator>().SetTrigger("showme");
            }

            if (ovprogressslider.value > graphcardvalue)
            {
                graphicsupgradeWidnow.SetActive(true);
            }

            if (ovprogressslider.value > RAMvalue)
            {
                RAMupgradeWindow.SetActive(true);
            }
        }
        else if (PlayerPrefs.GetFloat("savedprogress", 0) > screenvalue)
        {
            if (ovprogressslider.value > processorvalue)
            {
                processorupgradeWidnow.SetActive(true);
                //processorupgradeWidnow.GetComponent<Animator>().SetTrigger("showme");
            }

            if (ovprogressslider.value > graphcardvalue)
            {
                graphicsupgradeWidnow.SetActive(true);
            }

            if (ovprogressslider.value > RAMvalue)
            {
                RAMupgradeWindow.SetActive(true);
            }

            if (ovprogressslider.value > screenvalue)
            {
                screenupgradeWindow.SetActive(true);
            }
        }
        else if (PlayerPrefs.GetFloat("savedprogress", 0) > soundvalue)
        {
            if (ovprogressslider.value > processorvalue)
            {
                processorupgradeWidnow.SetActive(true);
                //processorupgradeWidnow.GetComponent<Animator>().SetTrigger("showme");
            }

            if (ovprogressslider.value > graphcardvalue)
            {
                graphicsupgradeWidnow.SetActive(true);
            }

            if (ovprogressslider.value > RAMvalue)
            {
                RAMupgradeWindow.SetActive(true);
            }

            if (ovprogressslider.value > screenvalue)
            {
                screenupgradeWindow.SetActive(true);
            }

            if (ovprogressslider.value > soundvalue)
            {
                soundupgradeWindow.SetActive(true);
            }
        }
        else
        {
            //nothign ehre
        }



        PlayerPrefs.SetFloat("savedprogress", ovprogressslider.value);
        yield return new WaitForSecondsRealtime(2f);

        win4button.SetActive(true);
    }

    public IEnumerator emergencybuttonactivator()
    {
        yield return new WaitForSecondsRealtime(9.4f);
        win4button.SetActive(true);
    }

    public void hidesoundwindow()
    {
        soundupgradeWindow.SetActive(false);
    }

    public void hidescreenwindow()
    {
        screenupgradeWindow.SetActive(false);
    }

    public void hideramwindow()
    {
        RAMupgradeWindow.SetActive(false);
    }

    public void hidegraphiccardwindow()
    {
        graphicsupgradeWidnow.SetActive(false);
    }

    public void hideprocessorwindow()
    {
        processorupgradeWidnow.SetActive(false);
    }

    public void showfifthwindow()
    {
        overallprogresswindow.SetActive(false);
        backgroundswindow.SetActive(true);

        StartCoroutine(LoadBackgrounds());
    }

    public Text backcounter;
    public Slider background2;
    public Slider background3;
    public Slider background4;

    private int levelsfor2 = 10;
    private int levelsfor3 = 20;
    private int levelsfor4 = 30;

    public Button back2btn;
    public Button back3btn;
    public Button back4btn;

    public Sprite back1txt;
    public Sprite back2txt;
    public Sprite back3txt;
    public Sprite back4txt;

    public GameObject winDOW5btn;

    public IEnumerator LoadBackgrounds()
    {
        background2.value = PlayerPrefs.GetFloat("back2val", 0);
        background3.value = PlayerPrefs.GetFloat("back3val", 0);
        background4.value = PlayerPrefs.GetFloat("back4val", 0);

        if (PlayerPrefs.GetInt("back2", 0) == 1)
        {
            back2btn.gameObject.SetActive(true);
            background2.gameObject.SetActive(false);
            backcounter.text = "2/4";
        }

        if (PlayerPrefs.GetInt("back3", 0) == 1)
        {
            back3btn.gameObject.SetActive(true);
            background3.gameObject.SetActive(false);
            backcounter.text = "3/4";
            
        }

        if (PlayerPrefs.GetInt("back4", 0) == 1)
        {
            back4btn.gameObject.SetActive(true);
            background4.gameObject.SetActive(false);
            backcounter.text = "4/4";
            
        }

        

        //background2.maxValue = levelsfor2;
        //background3.maxValue = levelsfor3;
        //background4.maxValue = levelsfor4;

        yield return new WaitForSecondsRealtime(1.4f);


        //background2.value = levelsfor2 - currentLevel;
        //background3.value = levelsfor3 - currentLevel;
        //background4.value = levelsfor4 - currentLevel;

        //background2.value = PlayerPrefs.GetFloat("back2val", 0);
        //background3.value = PlayerPrefs.GetFloat("back3val", 0);
        //background4.value = PlayerPrefs.GetFloat("back4val", 0);

        if(background2.value != background2.maxValue)
        {
            background2.value += 1;
        }

        if(background3.value != background3.maxValue)
        {
            background3.value += 1;
        }

        if(background4.value != background4.maxValue)
        {
            background4.value += 1;
        }
        
        

        if (background2.value == background2.maxValue)
        {
            PlayerPrefs.SetInt("back2", 1);
            back2btn.gameObject.SetActive(true);
            background2.gameObject.SetActive(false);
            PlayerPrefs.SetFloat("back2val", background4.value);
        }
        else
        {
            PlayerPrefs.SetInt("back2", 0);
            PlayerPrefs.SetFloat("back2val", background4.value);
        }

        if(background3.value == background3.maxValue)
        {
            PlayerPrefs.SetInt("back3", 1);
            back2btn.gameObject.SetActive(true);
            background3.gameObject.SetActive(false);
            PlayerPrefs.SetFloat("back3val", background4.value);
        }
        else
        {
            PlayerPrefs.SetInt("back3", 0);
            PlayerPrefs.SetFloat("back3val", background4.value);
        }

        if(background4.value == background4.maxValue)
        {
            PlayerPrefs.SetInt("back4", 1);
            back2btn.gameObject.SetActive(true);
            background4.gameObject.SetActive(false);
            PlayerPrefs.SetFloat("back4val", background4.value);
        }
        else
        {
            PlayerPrefs.SetInt("back4", 0);
            PlayerPrefs.SetFloat("back4val", background4.value);
        }

        PlayerPrefs.SetFloat("back2val", background4.value);
        PlayerPrefs.SetFloat("back3val", background4.value);
        PlayerPrefs.SetFloat("back4val", background4.value);

        yield return new WaitForSecondsRealtime(1f);

        winDOW5btn.SetActive(true);
    }

    public Image backgroundholder;

    public void SetLocalBackground(int backgroundid)
    {
        if(backgroundid == 1)
        {
            backgroundholder.sprite = back1txt;
        }
        else if(backgroundid == 2)
        {
            backgroundholder.sprite = back2txt;
        }
        else if (backgroundid == 3)
        {
            backgroundholder.sprite = back3txt;
        }
        else if (backgroundid == 4)
        {
            backgroundholder.sprite = back4txt;
        }

        PlayerPrefs.SetInt("95backID", backgroundid);
    }

    //sixthwindow values and stuff
    public Slider dayprogressslider;

    //next button (that belongs to window6)
    public void OnMouseUpAsButton()
    {
       
    }

    public Button sixthnextbtn;

    //reference
    public int day = (int)System.DateTime.Now.Day;


    public void SHOWSIXTHSCREENWINDOW()
    {
        backgroundswindow.SetActive(false);
        rewardwindow.SetActive(true);
        StartCoroutine(showrewardwindow());
    }

    public IEnumerator showrewardwindow()
    {
        dayprogressslider.value = PlayerPrefs.GetFloat("dayprogress", 0);
        dayprogressslider.maxValue = 7; //thats how many days are required to get the final prize
        ///NOTE: I CANT CHECK IF THE PLAYER IS OPENING THE APP IN 7 DAYS IN A ROW
        ///CUZ THIS SYSTEM USES SYSTEM'S LOCAL TIME SO THATS IMPOSSIBLE (i want this game to be fully playable in offline mode)
        ///================
        ///toally not beacuse im lazy
        day = (int)System.DateTime.Now.Day;
        //Debug.Log("todays date (DOW) is: " dt.DayOfWeek);
        print("today is the: " + day.ToString());

        if(PlayerPrefs.GetString("weekday", "monday") == day.ToString()) //is the todays date equal to "yesterdays" date? [IF YES THEN DONT ADD A DAY TO PROGRESSBAR]
        {
            //do nothing or just tell the player that he already got the reward
        }
        else
        {
            PlayerPrefs.SetString("weekday", day.ToString());

            print("changed weekday var to: " + PlayerPrefs.GetString("weekday", "monday")); //should be a new var
            //increase the progressbar by 1
            yield return new WaitForSecondsRealtime(1f);
            dayprogressslider.value += 1;
        }

        PlayerPrefs.SetFloat("dayprogress", dayprogressslider.value);
        
        yield return new WaitForSecondsRealtime(0.9f);


        sixthnextbtn.gameObject.SetActive(true);
    }

    public GameObject pack1;
    public GameObject pack2;

    //stuff from pack1
    public Slider p1c1progress;
    public Slider p1c2progress;
    public Slider p1c3progress;

    public GameObject p1c1image;
    public GameObject p1c2image;
    public GameObject p1c3image;

    //stuff from pack2
    public Slider p2c1progress;
    public Slider p2c2progress;
    public Slider p2c3progress;

    //public GameObject p2c1image;
    //public GameObject p2c2image;
    // public GameObject p2c3image;

    public GameObject seventhnextbutton;

    public void ShowChallengesWindow()
    {
        rewardwindow.SetActive(false);
        tempchallengeswindow.SetActive(true);
        StartCoroutine(ChallengesWindow());
    }

    public IEnumerator ChallengesWindow()
    {
        //randomize objectives pack
        int i = Random.Range(1, 3);

        if (i == 1)
        {
            pack1.SetActive(true);
            p1c1progress.value = 0;
            p1c2progress.value = 0;
            p1c3progress.value = 0;
        }
        else if(i == 2)
        {
            pack2.SetActive(true);
            p2c1progress.value = 0;
            p2c2progress.value = 0;
            p2c3progress.value = 0;
        }

        yield return new WaitForSeconds(1.2f);

        if (i == 1)
        {
            if(SessionPoints >= 100000)
            {
                for(int ii = 0; ii < 100000; ii+=1000)
                {
                    yield return new WaitForSecondsRealtime(0.0001f);
                    p1c1progress.value += 1000;
                }
                //completion effect

                PlayerPrefs.SetInt("p1c1", 5000);
                p1c1image.SetActive(true);
            }
            else if(SessionPoints < 100000)
            {
                for(int ii = 0; ii < SessionPoints; ii+=1000)
                {
                    yield return new WaitForSecondsRealtime(0.0001f);
                    p1c1progress.value += 1000;
                }
            }

            yield return new WaitForSecondsRealtime(1f);
            ProgressDrag pdd = GameObject.Find("DragParent").GetComponent<ProgressDrag>();

            if(pdd.ballpoints >= 1000)
            {
                for(int jj = 0; jj < 1000; jj+=1000)
                {
                    yield return new WaitForSecondsRealtime(0.0001f);
                    p1c2progress.value += 1000;
                }
                //completion effect
                PlayerPrefs.SetInt("p1c2", 5000);
                p1c2image.SetActive(true);
            }
            else if(pdd.ballpoints < 1000)
            {
                for (int jj = 0; jj < 1000; jj += 1000)
                {
                    yield return new WaitForSecondsRealtime(0.0001f);
                    p1c2progress.value += 1000;
                }
            }

            yield return new WaitForSecondsRealtime(1f);

            if(catchedcats >= 5)
            {
                for (int nnn = 0; nnn < 5; nnn++)
                {

                    yield return new WaitForSecondsRealtime(0.35f);
                    p1c3progress.value += 1;
                }
                //completion effect
                PlayerPrefs.SetInt("p1c3", 5000);
                p1c3image.SetActive(true);
            }
            else
            {
                for (int nnn = 0; nnn < catchedcats; nnn++)
                {

                    yield return new WaitForSecondsRealtime(0.35f);
                    p1c3progress.value += 1;
                }
            }

            yield return new WaitForSecondsRealtime(1.5f);

            seventhnextbutton.SetActive(true);
        }
        else if (i == 2)
        {
            if(SessionPoints <= 2000)
            {
                for(int ii = 0; ii < SessionPoints; ii++)
                {
                    yield return new WaitForSecondsRealtime(0.0001f);
                    p2c1progress.value += 1;
                    
                }

                //completion effect
                PlayerPrefs.SetInt("p2c1", 5000);
                p1c1image.SetActive(true);
            }
            else
            {
                for (int ii = 0; ii < 2000; ii++)
                {
                    yield return new WaitForSecondsRealtime(0.0001f);
                    p2c1progress.value += 1;

                }

                p2c1progress.value = p2c1progress.maxValue;
            }

            yield return new WaitForSecondsRealtime(1f);

            ProgressDrag pddd = GameObject.Find("DragParent").GetComponent<ProgressDrag>();

            if(pddd.fingerpoints < 2)
            {
                p2c2progress.value = p2c2progress.maxValue;
                PlayerPrefs.SetInt("p2c2", 5000);
                p1c2image.SetActive(true);
            }
            else if(pddd.fingerpoints > 1)
            {
                p2c2progress.value = 0;
            }

            yield return new WaitForSecondsRealtime(1f);

            if(clippysdestroyed == 0)
            {
                p2c3progress.value = 1;
                PlayerPrefs.SetInt("p2c3", 5000);
                p1c3image.SetActive(true);
            }
            else
            {
                p2c3progress.value = 0;
            }
        }

        yield return new WaitForSecondsRealtime(1.01f);

        seventhnextbutton.SetActive(true);
    }

    public IEnumerator levelup()
    {
        yield return new WaitForSecondsRealtime(1);
        levelslider.value += 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("95level", 1);
        ///asddPlayserPrefs.DelseteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGraphWindow()
    {
        //windowGraph.gameObject.SetActive(true);
        //StartCoroutine(clipincreaser());
    }

    public IEnumerator clipincreaser()
    {
        yield return new WaitForSecondsRealtime(0.01f);
        /*
        //windowGraph.pixelsPerUnit += 0.1f;
        windowGraph.gameObject.transform.localScale += new Vector3(windowGraph.gameObject.transform.localScale.x + startingX, windowGraph.gameObject.transform.localScale.y + startingY, windowGraph.gameObject.transform.localScale.z);

        startingX += startingIncrementX;
        startingY += startingIncrementY;

        
        if(windowGraph.gameObject.GetComponent<RectTransform>().localScale.x > 5.98f)
        {
            //stop the loop pls
            //hope itll work :o
        }
        else
        {
            StartCoroutine(clipincreaser());
        }
        */
    }

    public GameObject LoadingWindow;

    public void ActivateWin95LOADER()
    {
        StartCoroutine(Load95Menu());
    }

    public AudioSource clicksound;

    public void ClickSound()
    {
        clicksound.Play();
    }

    public IEnumerator Load95Menu()
    {
        //loadsceneasync
        tempchallengeswindow.SetActive(false);
        LoadingWindow.SetActive(true);
        yield return new WaitForSecondsRealtime(Random.Range(0.1f, 2.1f));
        SceneManager.LoadSceneAsync("LB95");
        
    }
}
