using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "NormalTile")
        {
            //Instantiate animation tile

            //switch %
            switch(procent)
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
            }
        }
    }
}
