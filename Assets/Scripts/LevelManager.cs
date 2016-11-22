using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
    }

    public void Taxi(string name)
    {
        Debug.Log("Level load requested for: " + name);
        PlayerPrefs.SetFloat("Uber", 0f);
        SceneManager.LoadScene(name);
    }

    public void Uber(string name)
    {
        Debug.Log("Level load requested for: " + name);
        PlayerPrefs.SetFloat("Uber", 1f);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit request");
        Application.Quit();
    }

}
