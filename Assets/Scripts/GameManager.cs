using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //window interactable stuff
    public GameObject win2button;

    //level
    public int currentLevel;

    
    

    //progressing
    public int ProLevels;
    public int ExpertLevels;
    public int MasterLevels;
    public int GrandMasterLevels;
    public int WarriorLevels;

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

    public Sprite Levelup;

    public Text progresstxt;
     

    public List<string> progressstuff = new List<string>();

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
    }

    public void launchprogressing()
    {
        StartCoroutine(startprogressing());
    }

    public IEnumerator startprogressing()
    {
        graphwindow.SetActive(false);
        progresswindow.SetActive(true);

        StartCoroutine(levelup());
        SessionPoints = 0;
        yield return new WaitForSecondsRealtime(1.8f);


        currentLevel += 1;
        PlayerPrefs.SetInt("95level", currentLevel);

        /*
        if(isPro)
        {
            levelslider.maxValue = ProLevels;
            progressstuff.Add("Pro");
        }
        else if(isExpert)
        {
            levelslider.maxValue = ExpertLevels;
            progressstuff.Add("Expert");
        }
        else if(isMaster)
        {
            levelslider.maxValue = MasterLevels;
            progressstuff.Add("Master");
        }
        else if (isGrandMaster)
        {
            levelslider.maxValue = MasterLevels;
            progressstuff.Add("GrandMaster");
        }
        else if (isWarrior)
        {
            levelslider.maxValue = MasterLevels;
            progressstuff.Add("Warrior");
        }
        */

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

        if(isWarrior)
        {
            progressstuff.Add("Warrior");
            progressstuff.Add("GrandMaster");
            progressstuff.Add("Master");
            progressstuff.Add("Expert");
            progressstuff.Add("Pro");
        }
        else if(isGrandMaster)
        {
            progressstuff.Add("GrandMaster");
            progressstuff.Add("Master");
            progressstuff.Add("Expert");
            progressstuff.Add("Pro");
        }
        else if (isMaster)
        {
            progressstuff.Add("Master");
            progressstuff.Add("Expert");
            progressstuff.Add("Pro");
        }
        else if(isExpert)
        {
            progressstuff.Add("Expert");
            progressstuff.Add("Pro");
        }
        else if(isPro)
        {
            progressstuff.Add("Pro");
        }

        //DEFAULT PROGRESS POINTS (CHANGEABLE)

        
        //randomstartingprogress = Random.Range(1500, 10000);

        //randomstartingprogress = Mathf.Round(randomstartingprogress); THIS IS AN INT

        if(leveltype == 1) //RELAX
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
        for (int i = 0; i < randomstartingprogress; i+=5)
        {
            yield return new WaitForSecondsRealtime(0.0000001f);
            //incrementpointslabel.text = ("Progress Score: " + i);
            realscoreincreasinglabel.text = ("Progress Score: " + i);
        }

        if (instG != null)
        {
            instG.GetComponent<Animator>().SetTrigger("delPoint");
        }
        yield return new WaitForSecondsRealtime(1.4f);
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
                for (int i = 0; i < randomstartingprogress; i+=5)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Pro Badge: " + i);
                }
                yield return new WaitForSecondsRealtime(1.45f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                if(instG2 != null)
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
                for (int i = 0; i < randomstartingprogress; i += 10)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Expert Badge: " + i);
                }
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
                for (int i = 0; i < randomstartingprogress; i += 20)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Master Badge: " + i);
                }
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
                for (int i = 0; i < randomstartingprogress; i += 20)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("GrandMaster Badge: " + i);
                }
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
                for (int i = 0; i < randomstartingprogress; i += 20)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Warrior Badge: " + i);
                }
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
                for (int i = 0; i < randomstartingprogress; i += 10)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Hard Difficulty: " + i);
                }
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
                for (int i = 0; i < randomstartingprogress; i += 10)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("Very Hard Difficulty: " + i);
                }
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
                for (int i = 0; i < randomstartingprogress; i += 20)
                {
                    yield return new WaitForSecondsRealtime(0.0000001f);
                    //progresstxt.text = ("Pro Badge: " + i);
                    realscoreincreasinglabel.text = ("HARDCORE! Difficulty: " + i);
                }
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
                    realscoreincreasinglabel.text = ("Progress Score: " + i);
                }
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
                for (int i = 0; i < randomstartingprogress; i+=10)
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
                yield return new WaitForSecondsRealtime(1.45f);
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
        ovprogressslider.value = PlayerPrefs.GetFloat("savedprogress", 0);

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

    public IEnumerator LoadBackgrounds()
    {
        if(PlayerPrefs.GetInt("back2", 0) == 1)
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

        background2.maxValue = levelsfor2;
        background3.maxValue = levelsfor3;
        background4.maxValue = levelsfor4;

        yield return new WaitForSecondsRealtime(1.4f);
        

        background2.value = levelsfor2 - currentLevel;
        background3.value = levelsfor3 - currentLevel;
        background4.value = levelsfor4 - currentLevel;

        if(background2.value == background2.maxValue)
        {
            PlayerPrefs.SetInt("back2", 1);
            back2btn.gameObject.SetActive(true);
            background2.gameObject.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("back2", 0);
        }

        if(background3.value == background3.maxValue)
        {
            PlayerPrefs.SetInt("back3", 1);
            back2btn.gameObject.SetActive(true);
            background3.gameObject.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("back3", 0);
        }

        if(background4.value == background4.maxValue)
        {
            PlayerPrefs.SetInt("back4", 1);
            back2btn.gameObject.SetActive(true);
            background4.gameObject.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("back4", 0);
        }
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
}
