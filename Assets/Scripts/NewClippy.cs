using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewClippy : MonoBehaviour
{
    public float pushvalue;

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
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "DragObject")
        {
            // Calculate direction vector
            Vector3 dir = collision.gameObject.transform.position - this.gameObject.transform.position;
            // Normalize resultant vector to unit Vector
            dir = dir.normalized;

            collision.gameObject.transform.position += dir * Time.deltaTime * pushvalue;

            ProgressDrag pd = collision.gameObject.GetComponent<ProgressDrag>();

            if(pd.isDragging == true)
            {
                pd.isDragging = false;
                StartCoroutine(RelaunchDrag());
                collision.gameObject.transform.position += dir * Time.deltaTime * pushvalue * 3.2f;
            }
        }
    }

    public IEnumerator RelaunchDrag()
    {
        yield return new WaitForSecondsRealtime(0.19f);
        ProgressDrag pd2 = GameObject.Find("DragParent").GetComponent<ProgressDrag>();
        pd2.isDragging = true;
    }
}
