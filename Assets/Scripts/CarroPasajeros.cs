using UnityEngine;
using System.Collections;

public class CarroPasajeros : MonoBehaviour {

    public delegate void InicioCarrera();
    public static event InicioCarrera Recoger;

    public static bool pasajero;

    private void Start()
    {
        pasajero = false;
    }

    private void CallEvent()
    {
        if (Recoger != null)
        {
            Recoger();
        }
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Pasajero"))
        {
            pasajero = true;
            CallEvent();
            Debug.Log("El pasajero fue recogido");
        }
        if (c.gameObject.CompareTag("Descarga"))
        {
            pasajero = false;
            CallEvent();
            Debug.Log("El pasajero fue descargado");
        }
    }
}
