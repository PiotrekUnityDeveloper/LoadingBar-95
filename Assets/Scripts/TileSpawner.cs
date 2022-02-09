using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public float difficultyHeight;

    public float subbounds;

    public float difficultyMaxMultiplier;
    public float difficultyMinMultiplier;

    //spawning tiles
    public float maxtiledelay;
    public float mintiledelay;

    public GameObject NormalTilePrefab;
    public GameObject OrangeTilePrefab;

    //utility
    private List<GameObject> activetiles = new List<GameObject>();
    private List<GameObject> activeclippys = new List<GameObject>();

    //conditions
    public bool canspawn = true;
    public bool canspawnclippys = true;

    [Header("clippy spawning stuff")]

    public GameObject clippyPrefab;
    public float minClippyDelay;
    public float maxClippyDelay;

    // Start is called before the first frame update
    void Start()
    {
        UpdateDifficultyMultiplier();
        StartCoroutine(TileSpawnerDelayer());
        StartCoroutine(ClippySpawner());
    }

    public void UpdateDifficultyMultiplier()
    {
        float difficultyMaxMultiplier = difficultyHeight + subbounds;
        float difficultyMinMultiplier = difficultyHeight - subbounds;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.transform.position = new Vector2(this.transform.position.x, difficultyHeight);

        //int i = Random.Range(1, 2);
        //print("random number from 1 to 2:  " + i);

        UpdateDifficultyMultiplier();

        this.gameObject.transform.position = new Vector2(Random.Range(3.88f, 8.39f), difficultyHeight);
    }

    public IEnumerator TileSpawnerDelayer()
    {
        yield return new WaitForSeconds(Random.Range(mintiledelay, maxtiledelay));
        if(canspawn == true)
        {
            int e = Random.Range(1, 3);

            if(e == 1)
            {
                GameObject instantiatedobj = Instantiate(NormalTilePrefab, this.transform.transform.position, Quaternion.identity);
                activetiles.Add(instantiatedobj);
                instantiatedobj.transform.parent = GameObject.Find("TileLister").transform;
            }
            else if(e == 2)
            {
                GameObject instantiatedobj = Instantiate(OrangeTilePrefab, this.transform.transform.position, Quaternion.identity);
                activetiles.Add(instantiatedobj);
                instantiatedobj.transform.parent = GameObject.Find("TileLister").transform;
            }


            
        }
        
        StartCoroutine(TileSpawnerDelayer());
    }

    public IEnumerator ClippySpawner()
    {
        yield return new WaitForSecondsRealtime(Random.Range(minClippyDelay, maxClippyDelay));

        if(canspawnclippys == true)
        {
            GameObject clippy = Instantiate(clippyPrefab, new Vector2(Random.Range(4.7f, 7.5f), Random.Range(-4.27f, 4.31f)), Quaternion.identity);
            activeclippys.Add(clippy);
            clippy.transform.parent = GameObject.Find("ClippyLister").transform;
        }

        StartCoroutine(ClippySpawner());
    }

    public void DeleteExistingTiles()
    {
        foreach(GameObject g in activetiles)
        {
            Destroy(g);
        }
    }

    public void DeleteExistingClippys()
    {
        foreach(GameObject g2 in activeclippys)
        {
            Destroy(g2);
        }
    }
}
