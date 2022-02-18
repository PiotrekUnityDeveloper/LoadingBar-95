using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();

        /*

        if(PlayerPrefs.GetInt("FirstTime", 0) == 0)
        {
            StartCoroutine(FirstTimeCR());
        }
        else if(PlayerPrefs.GetInt("FirstTime", 0) == 1)
        {
            SceneManager.LoadScene("LB95Startup");
        }

        */

        StartCoroutine(FirstTimeCR());
    }

    public void SkipIntro()
    {
        SceneManager.LoadScene("LB95Startup");
    }

    public IEnumerator FirstTimeCR()
    {
        PlayerPrefs.SetInt("FirstTime", 1);
        yield return new WaitForSecondsRealtime(25.5f);
        SceneManager.LoadScene("LB95Startup");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
