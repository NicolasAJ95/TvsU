using UnityEngine;
using System.Collections;

public class GestorPasajeros : MonoBehaviour {

	[SerializeField]
	private GameObject[] puntosPasajero;
	[SerializeField]
	private GameObject[] puntosDescarga;

	private int pasajero;
	private int carrera;
	private bool montado;
	private bool activo;
	private bool finCarrera;

	// Use this for initialization
	void Start () 
	{
		pasajero = Random.Range (0, puntosPasajero.Length+1);
		puntosPasajero [pasajero].SetActive (true);
		activo = puntosPasajero [pasajero].GetComponent<Recoger> ().activo;
	}
	
	// Update is called once per frame
	void Update () 
	{
		activo = puntosPasajero [pasajero].GetComponent<Recoger> ().activo;
		montado=Recojido ();
		if (!montado && !activo) {
			pasajero = Random.Range (0, puntosPasajero.Length);
			puntosPasajero [pasajero].SetActive (true);
		}

		if (montado) 
		{
			carrera = Random.Range (0, puntosDescarga.Length);
			puntosDescarga [carrera].SetActive (true);
		}
	}

	bool Recojido ()
	{
		montado = puntosPasajero [pasajero].GetComponent<Recoger> ().aBordo;
		return montado;
	}

	bool Arriva ()
	{
		finCarrera = puntosDescarga [carrera].GetComponent<Descargar> ();
		activo = false;
		return activo;
	}
}
