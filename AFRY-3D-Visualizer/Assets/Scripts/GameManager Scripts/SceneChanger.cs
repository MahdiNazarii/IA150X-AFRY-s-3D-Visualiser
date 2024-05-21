using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeSceneToMain()
    {
        SceneManager.LoadScene("main");
    }
    public void ChangeSceneToTest()
    {
        SceneManager.LoadScene("test");
    }

}
