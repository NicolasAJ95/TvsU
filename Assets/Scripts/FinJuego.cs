using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinJuego : MonoBehaviour {

    private float tiempo;
    [SerializeField]
    private Text tiempoP1;
    [SerializeField]
    private Text tiempoP2;

	// Use this for initialization
	void Start () {
        tiempo = 180;
        tiempoP1.text = "Tiempo Restante\n" + tiempo.ToString("N0");
        tiempoP2.text = "Tiempo Restante\n" + tiempo.ToString("N0");
    }
	
	// Update is called once per frame
	void Update () {
        tiempo -= 1 * Time.deltaTime;
        tiempoP1.text = "Tiempo Restante\n" + tiempo.ToString("N0");
        tiempoP2.text = "Tiempo Restante\n" + tiempo.ToString("N0");
        if (tiempo <= 0)
        {
            SceneManager.LoadScene("Ganador");
        }
    }
}
