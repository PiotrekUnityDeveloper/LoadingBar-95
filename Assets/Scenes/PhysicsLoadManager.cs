using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PhysicsLoadManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTestScene(int sceneID)
    {
        switch(sceneID)
        {
            case 1: //demo1 (deformationTest)
                SceneManager.LoadScene("Demo");
                break;
            case 2: //demo2 (softbodySpawnerTest)
                SceneManager.LoadScene("SoftBodyDemo");
                break;
            case 3: //demo3 (basic softbody)
                //to implement
                break;
        }
    }
}
