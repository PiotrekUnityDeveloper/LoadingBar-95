using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clippy : MonoBehaviour
{
    private Vector3 targetpos;

    public GameObject targetobj;
    public float movespeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetpos = targetobj.transform.position;
        targetpos.z = 0f;

        Vector3 objectPos = transform.position;
        targetpos.x = targetpos.x - objectPos.x;
        targetpos.y = targetpos.y - objectPos.y;

        float angle = Mathf.Atan2(targetpos.y, targetpos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        transform.position += transform.right * movespeed * Time.deltaTime;
    }
}
