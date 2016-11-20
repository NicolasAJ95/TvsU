using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

[RequireComponent(typeof(CarController))]
public class CarroPasajerosP2 : MonoBehaviour
{

    public delegate void InicioCarrera();
    public static event InicioCarrera RecogerP2;

    private CarController m_Car;
    public static bool pasajeroP2;

    private void Awake()
    {
        // get the car controller
        m_Car = GetComponent<CarController>();
    }

    private void Start()
    {
        pasajeroP2 = false;
    }

    private void CallEvent()
    {
        if (RecogerP2 != null)
        {
            RecogerP2();
        }
    }

    void OnTriggerStay(Collider c)
    {
        if (c.gameObject.CompareTag("Pasajero") && m_Car.CurrentSpeed <= 2f)
        {
            pasajeroP2 = true;
            CallEvent();
        }
        if (c.gameObject.CompareTag("Descarga") && m_Car.CurrentSpeed <= 2f)
        {
            pasajeroP2 = false;
            CallEvent();
        }
    }
}
