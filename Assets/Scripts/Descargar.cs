using UnityEngine;
using System.Collections;

public class Descargar : MonoBehaviour {

	public bool finCarrera;
	// Use this for initialization
	void Start () {
		finCarrera = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.CompareTag ("Player")) 
		{
			Debug.Log ("La carrera a finalizado");
			finCarrera = true;
		}
	}
}
