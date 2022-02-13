using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointsmovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.000001f);
    }
}
