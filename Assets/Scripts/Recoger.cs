using UnityEngine;
using System.Collections;

public class Recoger : MonoBehaviour {

	public bool aBordo;

	// Use this for initialization
	void Start () {
		aBordo = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c)
	{
		Debug.Log ("Algo entró");
		if (c.gameObject.CompareTag("Player")) 
		{
			Debug.Log ("Pasajero a bordo");
			aBordo = true;
		}
	}
}
