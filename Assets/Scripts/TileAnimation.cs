using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAnimation : MonoBehaviour
{

    public float tilespeed;
    public float speedincrease;

    //other
    public bool isTileOrange;

    public AudioSource pointadd;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(this.gameObject, 1); it destroys on collider
        pointadd = GameObject.Find("PlusPoint").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2(this.gameObject.transform.position.x + tilespeed, this.gameObject.transform.position.y);

        tilespeed += speedincrease;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "AnimationEnd")
        {
            TileCatcher tc = GameObject.Find("LoadingBar").GetComponent<TileCatcher>();
            if(this.gameObject.GetComponent<SpriteRenderer>().color == new Color(255, 179, 0))
            {
                isTileOrange = true;
                tc.UpdateOrangeLoadingBar();
            }
            else
            {
                isTileOrange = false;
                tc.UpdateLoadingBar();
            }

            pointadd.Play();

            
            //destroy animation object
            Destroy(this.gameObject);
        }
    }
}
