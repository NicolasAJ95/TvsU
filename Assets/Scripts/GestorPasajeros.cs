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
	private bool esperando;
	private bool finCarrera;

	void Awake ()
	{
		pasajero = Random.Range (0, puntosPasajero.Length);
		Debug.Log (pasajero);
		puntosPasajero [pasajero].SetActive (true);
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Recogiendo ();
		TerminarCarrera ();
		if (montado) 
		{
			carrera = Random.Range (0, puntosDescarga.Length);
			puntosDescarga [carrera].SetActive (true);
		}
	}

	bool Arriva ()
	{
		
		if (finCarrera) 
		{
			esperando = false;
		}
		return esperando;
	}

	void Recogiendo (bool esperando)
	{
		esperando = puntosPasajero [pasajero].GetComponent<Recoger> ().esperando;
		montado=puntosPasajero [pasajero].GetComponent<Recoger> ().aBordo;
		if (!montado && esperando) {
			pasajero = Random.Range (0, puntosPasajero.Length);
			puntosPasajero [pasajero].SetActive (true);
		}
	}

	void TerminarCarrera()
	{
		finCarrera = puntosDescarga [carrera].GetComponent<Descargar> ().finCarrera;
	}
}
