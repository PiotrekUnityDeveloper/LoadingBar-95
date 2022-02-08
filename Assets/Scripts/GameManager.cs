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

    //windows
    public GameObject graphwindow;
    public GameObject progresswindow;

    //level
    public int currentLevel;


    //progressing
    public int ProLevels;
    public int ExpertLevels;
    public int MasterLevels;

    //conditions
    public bool isPro;
    public bool isMaster;
    public bool isExpert;

    //progressing prefabs
    public GameObject progressinfoPrefab;
    public GameObject infoinstantiotor;
    public Animator prginfoanimator;
    public Text totalpointslabel;
    public Text incrementpointslabel;

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
     

    public List<string> progressstuff = new List<string>();

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

        

        if(isMaster)
        {
            progressstuff.Add("Master");
        }
        else if(isExpert)
        {
            progressstuff.Add("Expert");
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
        }
        else if (leveltype == 2) //EASY
        {
            randomstartingprogress = Random.Range(2800, 6900);
        }
        else if(leveltype == 3) //NORMAL
        {
            randomstartingprogress = Random.Range(7000, 14000);
        }
        else if (leveltype == 3) //HARD
        {
            randomstartingprogress = Random.Range(14000, 19900);
        }
        else if (leveltype == 3) //VERY HARD
        {
            randomstartingprogress = Random.Range(19900, 26000);
        }
        else if (leveltype == 3) //HARDCORE
        {
            randomstartingprogress = Random.Range(26000, 40000);
        }

        progressstuff.Add("Win95");

        GameObject instG = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
        instG.transform.parent = GameObject.Find("inst").transform;
        instG.GetComponent<Image>().sprite = ProgressPoints;
        //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
        //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
        incrementpointslabel = instG.transform.GetChild(0).GetComponent<Text>();
        instG.GetComponent<Animator>().SetTrigger("newPoint");
        print("randomized number is " + randomstartingprogress);
        for (int i = randomstartingprogress; i < randomstartingprogress; i++)
        {
            yield return new WaitForSecondsRealtime(0.01f);
            incrementpointslabel.text = ("Progress Score: " + i);
        }
        yield return new WaitForSecondsRealtime(1.4f);
        SessionPoints += randomstartingprogress;
        totalpointslabel.text = ("Total Points: " + SessionPoints);

        //yield return new WaitForSecondsRealtime(1.5f);

        progressstuff.Add("Complete");

        foreach (string s in progressstuff)
        {
            
            //if(s == "") //ALSO ADD THIS VALUE TO SESSION POINTSs
            if(s=="Pro")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                instG2.transform.parent = GameObject.Find("inst").transform;
                instG2.GetComponent<Image>().sprite = Pro;
                //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                instG2.GetComponent<Animator>().SetTrigger("newPoint");
                randomstartingprogress = Random.Range(5000, 7500);
                print("randomized number is " + randomstartingprogress);
                for (int i = randomstartingprogress; i < randomstartingprogress; i++)
                {
                    yield return new WaitForSecondsRealtime(0.01f);
                    incrementpointslabel.text = ("Pro Badge: " + i);
                }
                yield return new WaitForSecondsRealtime(1.45f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                Destroy(instG2);
            }

            if (s == "Perfect")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                instG2.transform.parent = GameObject.Find("inst").transform;
                instG2.GetComponent<Image>().sprite = Perfect;
                incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                instG2.GetComponent<Animator>().SetTrigger("newPoint");
                randomstartingprogress = Random.Range(1000, 3200);
                print("randomized number is " + randomstartingprogress);
                for (int i = randomstartingprogress; i < randomstartingprogress; i++)
                {
                    yield return new WaitForSecondsRealtime(0.01f);
                    incrementpointslabel.text = ("Perfectionist: " + i);
                }
                yield return new WaitForSecondsRealtime(1.45f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                Destroy(instG2);
            }

            if (s == "Win95")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                instG2.transform.parent = GameObject.Find("inst").transform;
                instG2.GetComponent<Image>().sprite = Win95;
                //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                instG2.GetComponent<Animator>().SetTrigger("newPoint");
                randomstartingprogress = Random.Range(1000, 3200);
                print("randomized number is " + randomstartingprogress);
                for (int i = randomstartingprogress; i < randomstartingprogress; i++)
                {
                    yield return new WaitForSecondsRealtime(0.01f);
                    incrementpointslabel.text = ("LoadingBar 95: " + i);
                }
                yield return new WaitForSecondsRealtime(1.45f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                Destroy(instG2);
            }

            if (s == "Complete")
            {
                GameObject instG2 = Instantiate(progressinfoPrefab, infoinstantiotor.transform.position, Quaternion.identity);
                instG2.transform.parent = GameObject.Find("inst").transform;
                instG2.GetComponent<Image>().sprite = Completed;
                //incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                //incrementpointslabel = GameObject.FindGameObjectWithTag("PointsIncreaser").GetComponent<Text>();
                //incrementpointslabel = GameObject.Find("incpoints").GetComponent<Text>();
                incrementpointslabel = instG2.transform.GetChild(0).GetComponent<Text>();
                instG2.GetComponent<Animator>().SetTrigger("newPoint");
                randomstartingprogress = 0;
                print("randomized number is " + randomstartingprogress);
                for (int i = randomstartingprogress; i < randomstartingprogress; i++)
                {
                    //yield return new WaitForSecondsRealtime(0.01f);
                    //incrementpointslabel.text = ("LoadingBar 95: " + i);
                }
                yield return new WaitForSecondsRealtime(1.45f);
                SessionPoints += randomstartingprogress;
                totalpointslabel.text = ("Total Points: " + SessionPoints);
                Destroy(instG2);
            }


        }

        progressstuff.Clear();

    }

    public IEnumerator levelup()
    {
        yield return new WaitForSecondsRealtime(1);
        levelslider.value += 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
