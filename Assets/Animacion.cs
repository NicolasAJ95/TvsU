using UnityEngine;
using System.Collections;

public class Animacion : MonoBehaviour {

    private bool car;

	// Use this for initialization
	void Start () {
        car = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Player"))
        {
            car = true;
        }
    }
}
