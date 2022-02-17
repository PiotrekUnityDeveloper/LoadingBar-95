using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRedirector : MonoBehaviour
{
    public string SceneName;
    public float Delay;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Redirect());
    }

    public IEnumerator Redirect()
    {
        yield return new WaitForSecondsRealtime(Delay);
        SceneManager.LoadScene(SceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
