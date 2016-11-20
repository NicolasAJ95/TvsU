using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

[RequireComponent(typeof(CarController))]
public class CarroPasajerosP2 : MonoBehaviour
{

    public delegate void InicioCarrera();
    public static event InicioCarrera RecogerP2;

    public static float saludP2;
    public static bool choqueP2;
    private CarController m_Car;
    public static bool pasajeroP2;
    [SerializeField]
    private CarController m_CarEnemi;

    private void Awake()
    {
        // get the car controller
        m_Car = GetComponent<CarController>();
    }

    private void Start()
    {
        saludP2 = 4;
        pasajeroP2 = false;
        choqueP2 = false;
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

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Player") && pasajeroP2 == true && m_CarEnemi.CurrentSpeed >= 10f)
        {
            saludP2 -= 1;
            choqueP2 = true;
            CallEvent();
        }
    }
}
