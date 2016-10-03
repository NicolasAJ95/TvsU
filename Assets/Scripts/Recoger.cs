using UnityEngine;
using System.Collections;

public class Recoger : MonoBehaviour {

	public bool aBordo;
	public bool activo;

	// Use this for initialization
	void Start () 
	{
		aBordo = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.activeInHierarchy) 
		{
			activo = true;
		}
	}

	void OnTriggerEnter(Collider c)
	{
		Debug.Log ("Algo entró");
		if (c.gameObject.CompareTag("Player")) 
		{
			Debug.Log ("Pasajero a bordo");
			aBordo = true;
			activo = false;
			gameObject.SetActive (false);
		}
	}
}
