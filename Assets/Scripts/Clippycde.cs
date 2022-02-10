using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clippycde : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void destroymyself()
    {
        GameManager gmm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gmm.clippysdestroyed += 1;
        Destroy(this.gameObject);
    }
}
