using UnityEngine;
using System.Collections;

public class LocalizarPunto : MonoBehaviour {

    [SerializeField]
    private GameObject[] objetivo;
    [SerializeField]
    private GameObject enemigo;

	void Update () {

        if (this.tag == "P1")
        {
            if (CarroPasajerosP2.pasajeroP2)
            {
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
