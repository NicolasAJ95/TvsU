using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{

    static MusicManager instance = null;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            print("Objeto duplicado eliminado.");
        }
        else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}