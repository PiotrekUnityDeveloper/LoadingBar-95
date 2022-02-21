using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefScKIT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadScene() //reloads current scene; reusable
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LeaveScene() //goes to menu scene (def: "LB95")
    {
        SceneManager.LoadScene("LB95");
    }


    public void LoadPhysicsLoaderLevel()
    {
        SceneManager.LoadScene("PhysicsLoader1");
    }
}
