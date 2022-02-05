using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTileBehaviour : MonoBehaviour
{
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
        if(collision.tag == "LoadingBar")
        {
            Destroy(this.gameObject);
        }
        else if(collision.tag == "TileDestroyer")
        {
            Destroy(this.gameObject);
            //should just destroy
            Debug.Log("I should just destroy");
            //TileCatcher tc = GameObject.Find("LoadingBar").GetComponent<TileCatcher>();
            //tc.Reducebytenprocent();
        }
    }
}
