using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

[RequireComponent(typeof(CarController))]
public class CarroPasajerosP2 : MonoBehaviour
{

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
        if (c.gameObject.CompareTag("PasajeroP2") && m_Car.CurrentSpeed <= 2f)
        {
            pasajero = true;
            CallEvent();
        }
        if (c.gameObject.CompareTag("DescargaP2") && m_Car.CurrentSpeed <= 2f)
        {
            pasajero = false;
            CallEvent();
        }
    }
}
