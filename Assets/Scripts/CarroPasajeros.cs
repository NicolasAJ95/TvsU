using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

[RequireComponent(typeof(CarController))]
public class CarroPasajeros : MonoBehaviour {

    public delegate void InicioCarrera();
    public static event InicioCarrera Recoger;

    private CarController m_Car;
    public static bool pasajero;

    private void Awake()
    {
        // get the car controller
        m_Car = GetComponent<CarController>();
    }

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

    void OnTriggerStay(Collider c)
    {
        if (c.gameObject.CompareTag("Pasajero") && m_Car.CurrentSpeed<=2f)
        {
            pasajero = true;
            CallEvent();
            Debug.Log("El pasajero fue recogido");
        }
        if (c.gameObject.CompareTag("Descarga") && m_Car.CurrentSpeed<=2f)
        {
            pasajero = false;
            CallEvent();
            Debug.Log("El pasajero fue descargado");
        }
    }
}
