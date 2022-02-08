using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTileBehaviour : MonoBehaviour
{
    public bool isOrange;
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
        

        if(collision.tag == "LoadingBar" && collision.gameObject.name == "LoadingBar")
        {
            TileCatcher tc22 = GameObject.Find("LoadingBar").GetComponent<TileCatcher>();
            if (tc22.LatestColor == "blue")
            {
                tc22.UpdateLoadingBar();
            }
            else
            {
                tc22.UpdateOrangeLoadingBar();
            }

            Destroy(this.gameObject);
        }
        else if (collision.tag == "TileDestroyer")
        {
            this.gameObject.transform.position = new Vector2(9999999999999999, 99999999999999999);
            TileCatcher tc = GameObject.Find("LoadingBar").GetComponent<TileCatcher>();
            tc.Reducebyfiveprocent();
            Destroy(this.gameObject);
        }
    }
}
