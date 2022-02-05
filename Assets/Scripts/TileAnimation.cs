using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAnimation : MonoBehaviour
{

    public float tilespeed;
    public float speedincrease;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(this.gameObject, 1); it destroys on collider
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
            tc.UpdateLoadingBar();
            //destroy animation object
            Destroy(this.gameObject);
        }
    }
}
