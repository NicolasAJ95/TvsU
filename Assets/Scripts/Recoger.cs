using UnityEngine;
using System.Collections;

public class Recoger : MonoBehaviour {

	public bool aBordo;
	public bool esperando;

	// Use this for initialization
	void Start () 
	{
		aBordo = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.activeInHierarchy) 
		{
			esperando = true;
		}
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.CompareTag("Player")) 
		{
			Debug.Log ("Pasajero a bordo");
			aBordo = true;
			esperando = false;
			gameObject.SetActive (false);
		}
	}
}
