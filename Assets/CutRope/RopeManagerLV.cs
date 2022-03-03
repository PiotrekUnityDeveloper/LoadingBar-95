using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RopeManagerLV : MonoBehaviour
{
    public List<GameObject> Hints = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartRopeLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToSelector()
    {
        SceneManager.LoadScene("RopeLevels");
    }

    public void ShowRopeHint()
    {
        foreach(GameObject go in Hints)
        {
            go.SetActive(true);
        }
    }
}
