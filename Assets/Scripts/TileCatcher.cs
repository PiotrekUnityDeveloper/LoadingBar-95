using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileCatcher : MonoBehaviour
{
    public int procent = 0; //%

    public Slider bluepoints;
    public Slider orangepoints;

    [Header("Tiles")]

    //tile simulators
    public GameObject tile1;
    public GameObject tile2;
    public GameObject tile3;
    public GameObject tile4;
    public GameObject tile5;
    public GameObject tile6;
    public GameObject tile7;
    public GameObject tile8;
    public GameObject tile9;
    public GameObject tile10;
    public GameObject tile11;
    public GameObject tile12;
    public GameObject tile13;
    public GameObject tile14;
    public GameObject tile15;
    public GameObject tile16;
    public GameObject tile17;
    public GameObject tile18;
    public GameObject tile19;
    public GameObject tile20;

    //Graph Stuff
    public Image graphimg;

    //Graph Textures
    #region
    public Sprite blue0;
    public Sprite blue5;
    public Sprite blue10;
    public Sprite blue15;
    public Sprite blue20;
    public Sprite blue25;
    public Sprite blue30;
    public Sprite blue35;
    public Sprite blue40;
    public Sprite blue45;
    public Sprite blue50;
    public Sprite blue55;
    public Sprite blue60;
    public Sprite blue65;
    public Sprite blue70;
    public Sprite blue75;
    public Sprite blue80;
    public Sprite blue85;
    public Sprite blue90;
    public Sprite blue95;
    public Sprite blue100;
    #endregion


    //Animations
    public GameObject Instantiator;
    public GameObject AnimatedTile;

    //UI
    public Text procentText;
    public Text procentTextShadow;
    public Text secondProcentShadow;

    //final scoring
    private int BlueTiles;
    private int OrangeTiles;

    #region uistuff
    //final ui rendering stuff

    public Image finaltile1;
    public Image finaltile2;
    public Image finaltile3;
    public Image finaltile4;
    public Image finaltile5;
    public Image finaltile6;
    public Image finaltile7;
    public Image finaltile8;
    public Image finaltile9;
    public Image finaltile10;
    public Image finaltile11;
    public Image finaltile12;
    public Image finaltile13;
    public Image finaltile14;
    public Image finaltile15;
    public Image finaltile16;
    public Image finaltile17;
    public Image finaltile18;
    public Image finaltile19;
    public Image finaltile20;

    #endregion uistuff

    public Color bluecolor;
    public Color orangecolor;

    //windows
    public GameObject SummaryWindow;

    private void Awake()
    {
        bluecolor = Color.blue;
        orangecolor = new Color(255, 179, 0);

    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HundredProcentDelayChecker());

    }

    // Update is called once per frame
    void Update()
    {
        procentTextShadow.text = procentText.text;
        secondProcentShadow.text = procentText.text;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "NormalTile")
        {
            procent += 5;
            //Instantiate animation tile
            Instantiator.transform.position = new Vector2(collision.transform.position.x, Instantiator.transform.position.y);
            GameObject g = Instantiate(AnimatedTile, Instantiator.transform.position, Quaternion.identity);
            g.transform.parent = GameObject.Find("LoadingBar").gameObject.transform;

            procentText.text = (procent + "%");

            //switch %
            //after tileanimation destroys

            //print("collected one NORMAL TILE");

        }
        else if (collision.tag == "OrangeTile")
        {
            procent += 5;
            //Instantiate animation tile
            Instantiator.transform.position = new Vector2(collision.transform.position.x, Instantiator.transform.position.y);
            GameObject g = Instantiate(AnimatedTile, Instantiator.transform.position, Quaternion.identity);
            g.transform.parent = GameObject.Find("LoadingBar").gameObject.transform;
            g.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);

            procentText.text = (procent + "%");

            //switch %
            //after tileanimation destroys

            //print("collected one NORMAL TILE");

        }
    }

    public void UpdateLoadingBar() //EXTREMELY BAD CODING PRACTICE, SORRY IM JUST LAZY
    {

        switch (procent)
        {
            case 5:
                tile1.SetActive(true);
                break;
            case 10:
                tile1.SetActive(true);
                tile2.SetActive(true);
                break;
            case 15:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                break;
            case 20:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                break;
            case 25:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                break;
            case 30:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                break;
            case 35:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                break;
            case 40:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                break;
            case 45:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                break;
            case 50:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                break;
            case 55:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile11.SetActive(true);
                break;
            case 60:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile11.SetActive(true);
                tile12.SetActive(true);
                break;
            case 65:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile11.SetActive(true);
                tile12.SetActive(true);
                tile13.SetActive(true);
                break;
            case 70:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile11.SetActive(true);
                tile12.SetActive(true);
                tile13.SetActive(true);
                tile14.SetActive(true);
                break;
            case 75:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile11.SetActive(true);
                tile12.SetActive(true);
                tile13.SetActive(true);
                tile14.SetActive(true);
                tile15.SetActive(true);
                break;
            case 80:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile11.SetActive(true);
                tile12.SetActive(true);
                tile13.SetActive(true);
                tile14.SetActive(true);
                tile15.SetActive(true);
                tile16.SetActive(true);
                break;
            case 85:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile11.SetActive(true);
                tile12.SetActive(true);
                tile13.SetActive(true);
                tile14.SetActive(true);
                tile15.SetActive(true);
                tile16.SetActive(true);
                tile17.SetActive(true);
                break;
            case 90:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile11.SetActive(true);
                tile12.SetActive(true);
                tile13.SetActive(true);
                tile14.SetActive(true);
                tile15.SetActive(true);
                tile16.SetActive(true);
                tile17.SetActive(true);
                tile18.SetActive(true);
                break;
            case 95:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile11.SetActive(true);
                tile12.SetActive(true);
                tile13.SetActive(true);
                tile14.SetActive(true);
                tile15.SetActive(true);
                tile16.SetActive(true);
                tile17.SetActive(true);
                tile18.SetActive(true);
                tile19.SetActive(true);
                break;
            case 100:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile11.SetActive(true);
                tile12.SetActive(true);
                tile13.SetActive(true);
                tile14.SetActive(true);
                tile15.SetActive(true);
                tile16.SetActive(true);
                tile17.SetActive(true);
                tile18.SetActive(true);
                tile19.SetActive(true);
                tile20.SetActive(true);
                break;
        }
    }

    public void UpdateOrangeLoadingBar() //EXTREMELY BAD CODING PRACTICE, SORRY IM JUST LAZY
    {

        switch (procent)
        {
            case 5:
                tile1.SetActive(true);
                tile1.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);
                break;
            case 10:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile2.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);
                break;
            case 15:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile3.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);
                break;
            case 20:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile4.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);
                break;
            case 25:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile5.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);
                break;
            case 30:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile6.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);
                break;
            case 35:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile7.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);
                break;
            case 40:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile8.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);
                break;
            case 45:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile9.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);
                break;
            case 50:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile10.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);
                break;
            case 55:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile11.SetActive(true);
                tile11.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);
                break;
            case 60:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile11.SetActive(true);
                tile12.SetActive(true);
                tile12.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);
                break;
            case 65:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile11.SetActive(true);
                tile12.SetActive(true);
                tile13.SetActive(true);
                tile13.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);
                break;
            case 70:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile11.SetActive(true);
                tile12.SetActive(true);
                tile13.SetActive(true);
                tile14.SetActive(true);
                tile14.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);
                break;
            case 75:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile11.SetActive(true);
                tile12.SetActive(true);
                tile13.SetActive(true);
                tile14.SetActive(true);
                tile15.SetActive(true);
                tile15.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);
                break;
            case 80:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile11.SetActive(true);
                tile12.SetActive(true);
                tile13.SetActive(true);
                tile14.SetActive(true);
                tile15.SetActive(true);
                tile16.SetActive(true);
                tile16.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);
                break;
            case 85:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile11.SetActive(true);
                tile12.SetActive(true);
                tile13.SetActive(true);
                tile14.SetActive(true);
                tile15.SetActive(true);
                tile16.SetActive(true);
                tile17.SetActive(true);
                tile17.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);
                break;
            case 90:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile11.SetActive(true);
                tile12.SetActive(true);
                tile13.SetActive(true);
                tile14.SetActive(true);
                tile15.SetActive(true);
                tile16.SetActive(true);
                tile17.SetActive(true);
                tile18.SetActive(true);
                tile18.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);
                break;
            case 95:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile11.SetActive(true);
                tile12.SetActive(true);
                tile13.SetActive(true);
                tile14.SetActive(true);
                tile15.SetActive(true);
                tile16.SetActive(true);
                tile17.SetActive(true);
                tile18.SetActive(true);
                tile19.SetActive(true);
                tile19.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);
                break;
            case 100:
                tile1.SetActive(true);
                tile2.SetActive(true);
                tile3.SetActive(true);
                tile4.SetActive(true);
                tile5.SetActive(true);
                tile6.SetActive(true);
                tile7.SetActive(true);
                tile8.SetActive(true);
                tile9.SetActive(true);
                tile10.SetActive(true);
                tile11.SetActive(true);
                tile12.SetActive(true);
                tile13.SetActive(true);
                tile14.SetActive(true);
                tile15.SetActive(true);
                tile16.SetActive(true);
                tile17.SetActive(true);
                tile18.SetActive(true);
                tile19.SetActive(true);
                tile20.SetActive(true);
                tile20.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 179, 0);
                break;
        }
    }

    public void Reducebytenprocent()
    {
        if(procent > 5)
        {
            procent -= 10;

        }

        UpdateLoadingBar();

        if(procent > 95)
        {
            GameWin();
        }
    }

    public void Reducebyfiveprocent()
    {
        UpdateLoadingBar();
        if (procent > 5)
        {
            procent -= 5;
            UpdateLoadingBar();
        }

        UpdateLoadingBar();

        if (procent > 95)
        {
            GameWin();
        }

        UpdateLoadingBar();
        UpdateLoadingBar();
    }

    public GameObject draggo;
    

    public void GameWin()
    {

        TileSpawner ts = GameObject.Find("InstantiatedTileHolder").GetComponent<TileSpawner>();
        ts.DeleteExistingTiles();

        //GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        //gm.ShowGraphWindow();

        draggo = GameObject.FindGameObjectWithTag("DragObject");
        if(draggo.GetComponent<Rigidbody2D>() == null)
        {
            Rigidbody2D rg2d = draggo.AddComponent<Rigidbody2D>();
            draggo.GetComponent<Rigidbody2D>().gravityScale = -0.8f;
            draggo.GetComponent<Rigidbody2D>().freezeRotation = true;
            //BoxCollider2D bc2d = draggo.AddComponent<BoxCollider2D>(); ALREADY INCLUDED
            ProgressDrag pd = GameObject.Find("DragParent").GetComponent<ProgressDrag>();
            pd.candrag = false;
        }

        StartCoroutine(DelaySummaryWindow());
    }

    public IEnumerator DelaySummaryWindow()
    {
        yield return new WaitForSecondsRealtime(1f);
        SummaryWindow.SetActive(true); //alternatively add animator trigger here
        ScoreCounter();
    }

    public bool isGameWon = false;

    public IEnumerator HundredProcentDelayChecker()
    {
        
        if(procent > 95 && isGameWon == false)
        {
            GameWin();

            TileSpawner ts = GameObject.Find("InstantiatedTileHolder").GetComponent<TileSpawner>();
            ts.canspawn = false;
            isGameWon = true;
        }

        yield return new WaitForSecondsRealtime(0.2f);

        StartCoroutine(HundredProcentDelayChecker());
    }

    public void ScoreCounter()
    {
        if(tile1.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile1.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile1.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        if (tile2.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile2.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile2.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        if (tile3.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile3.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile3.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        if (tile4.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile4.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile4.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        if (tile5.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile5.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile5.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        if (tile5.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile5.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile5.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        if (tile6.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile6.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile6.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        if (tile7.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile7.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile7.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        if (tile8.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile8.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile8.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        if (tile9.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile9.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile9.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        if (tile10.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile10.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile10.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        if (tile11.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile11.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile11.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        if (tile12.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile12.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile12.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        if (tile13.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile13.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile13.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        if (tile14.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile14.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile14.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        if (tile15.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile15.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile15.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        if (tile16.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile16.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile16.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        if (tile17.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile17.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile17.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        if (tile18.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile18.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile18.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        if (tile19.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile19.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile19.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        if (tile20.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0)) //if its orange
        {
            finaltile20.GetComponent<Image>().color = orangecolor;
            OrangeTiles++;
        }
        else //if not then its blue
        {
            finaltile20.GetComponent<Image>().color = bluecolor;
            BlueTiles++;
        }

        bluepoints.value = BlueTiles * 5;
        orangepoints.value = OrangeTiles * 5;

        Debug.Log("There was " + BlueTiles + " Blue Tiles and " + OrangeTiles + " Orange Tiles so there was " + bluepoints.value + "% of bluepoints and " + orangepoints.value + "% of orangepoints");


        //change graph's texture here

        switch(bluepoints.value)
        {
            case 0:
                graphimg.GetComponent<Image>().sprite = blue0;
                break;
            case 5:
                graphimg.GetComponent<Image>().sprite = blue5;
                break;
            case 10:
                graphimg.GetComponent<Image>().sprite = blue10;
                break;
            case 15:
                graphimg.GetComponent<Image>().sprite = blue15;
                break;
            case 20:
                graphimg.GetComponent<Image>().sprite = blue20;
                break;
            case 25:
                graphimg.GetComponent<Image>().sprite = blue25;
                break;
            case 30:
                graphimg.GetComponent<Image>().sprite = blue30;
                break;
            case 35:
                graphimg.GetComponent<Image>().sprite = blue35;
                break;
            case 40:
                graphimg.GetComponent<Image>().sprite = blue40;
                break;
            case 45:
                graphimg.GetComponent<Image>().sprite = blue45;
                break;
            case 50:
                graphimg.GetComponent<Image>().sprite = blue50;
                break;
            case 55:
                graphimg.GetComponent<Image>().sprite = blue55;
                break;
            case 60:
                graphimg.GetComponent<Image>().sprite = blue60;
                break;
            case 65:
                graphimg.GetComponent<Image>().sprite = blue65;
                break;
            case 70:
                graphimg.GetComponent<Image>().sprite = blue70;
                break;
            case 75:
                graphimg.GetComponent<Image>().sprite = blue75;
                break;
            case 80:
                graphimg.GetComponent<Image>().sprite = blue80;
                break;
            case 85:
                graphimg.GetComponent<Image>().sprite = blue85;
                break;
            case 90:
                graphimg.GetComponent<Image>().sprite = blue90;
                break;
            case 95:
                graphimg.GetComponent<Image>().sprite = blue95;
                break;
            case 100:
                graphimg.GetComponent<Image>().sprite = blue100;
                break;

        }
    }
}
