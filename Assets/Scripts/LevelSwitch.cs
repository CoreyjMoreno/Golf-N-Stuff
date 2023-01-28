using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{

    public void SwitchLevel(string SceneName)
    {
        Debug.Log("yoyoy");
        SceneManager.LoadScene(SceneName);
    }
    public void SwitchLevelIndex(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
