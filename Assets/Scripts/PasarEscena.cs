using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PasarEscena : MonoBehaviour {

    private float tiempo;

	// Use this for initialization
	void Start () {
        tiempo = 5;
	}
	
	// Update is called once per frame
	void Update () {
        tiempo -= 1 * Time.deltaTime;
        if(tiempo<=0)
        {
            SceneManager.LoadScene("Seleccion");
        }
	}
}
