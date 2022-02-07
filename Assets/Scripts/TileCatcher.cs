using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileCatcher : MonoBehaviour
{
    public int procent = 0; //%

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

    //Animations
    public GameObject Instantiator;
    public GameObject AnimatedTile;

    //UI
    public Text procentText;
    public Text procentTextShadow;
    public Text secondProcentShadow;



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
        
    }

    public IEnumerator HundredProcentDelayChecker()
    {
        if(procent > 95)
        {
            GameWin();
        }

        yield return new WaitForSecondsRealtime(0.2f);

        StartCoroutine(HundredProcentDelayChecker());
    }
}
