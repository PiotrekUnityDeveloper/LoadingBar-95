using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delaylayerchange());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator delaylayerchange()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder -= 1;
        StartCoroutine(delaylayerchange());
    }
}
