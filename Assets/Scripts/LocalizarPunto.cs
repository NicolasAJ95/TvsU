using UnityEngine;
using System.Collections;

public class LocalizarPunto : MonoBehaviour {

    [SerializeField]
    private GameObject[] objetivo;
    private GameObject enemigo;

	void Update () {

        if (this.tag == "P1")
        {
            if (CarroPasajerosP2.pasajeroP2)
            {
                enemigo = GameObject.FindGameObjectWithTag("Player2");
                transform.LookAt(enemigo.transform);
            }
            else
            {
                for (int i = 0; i < objetivo.Length; i++)
                {
                    if (objetivo[i].gameObject.activeInHierarchy == true)
                    {
                        transform.LookAt(objetivo[i].transform);
                    }
                }
            }
        }
        if (this.tag == "P2")
        {
            if (CarroPasajeros.pasajero)
            {
                enemigo = GameObject.FindGameObjectWithTag("Player");
                transform.LookAt(enemigo.transform);
            }
            else
            {
                for (int i = 0; i < objetivo.Length; i++)
                {
                    if (objetivo[i].gameObject.activeInHierarchy == true)
                    {
                        transform.LookAt(objetivo[i].transform);
                    }
                }
            }
        }
	}
}
