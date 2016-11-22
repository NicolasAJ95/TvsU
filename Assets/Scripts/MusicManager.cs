using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    static MusicManager instance = null;
    private string scena;
    private AudioSource sonido;

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
        scena = SceneManager.GetActiveScene().name;
        sonido = GetComponent<AudioSource>();
    }

    void Update()
    {
        scena = SceneManager.GetActiveScene().name;
        if (scena == "NivelPrueba")
        {
            sonido.volume = 0;
        }
        else
        {
            sonido.volume = 1;
        }
    }
}