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

    //utility
    private List<GameObject> activetiles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        UpdateDifficultyMultiplier();
        StartCoroutine(TileSpawnerDelayer());
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
        GameObject instantiatedobj = Instantiate(NormalTilePrefab, this.transform.transform.position, Quaternion.identity);
        activetiles.Add(instantiatedobj);
        instantiatedobj.transform.parent = GameObject.Find("TileLister").transform;
        StartCoroutine(TileSpawnerDelayer());
    }

    public void DeleteExistingTiles()
    {
        foreach(GameObject g in activetiles)
        {
            Destroy(g);
        }
    }
}
