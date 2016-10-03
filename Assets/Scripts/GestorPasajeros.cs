using UnityEngine;
using System.Collections;

public class GestorPasajeros : MonoBehaviour {

	[SerializeField]
	private GameObject[] puntosPasajero;

	private int pasajero;
	private bool montado;

	// Use this for initialization
	void Start () {
		montado = true;
		pasajero = Random.Range (0, puntosPasajero.Length);
		puntosPasajero [pasajero].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		//montado=recojido ();
		if (!montado) {
			pasajero = Random.Range (0, puntosPasajero.Length);
			puntosPasajero [pasajero].SetActive (true);
		}
	}

	/*bool recojido ()
	{
		montado = puntosPasajero [pasajero].
		return montado;
	}*/
}
