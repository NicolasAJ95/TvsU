using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

[RequireComponent(typeof(CarController))]
public class CarroPasajeros : MonoBehaviour {

    public delegate void InicioCarrera();
    public static event InicioCarrera Recoger;

    public static float saludP1;
    public static bool choqueP1;
    private CarController m_Car;
    public static bool pasajero;
    [SerializeField]
    private CarController m_CarEnemi;
    private AudioSource choque;

    private void Awake()
    {
        // get the car controller
        m_Car = GetComponent<CarController>();
        choque = GetComponent<AudioSource>();
    }

    private void Start()
    {
        saludP1 = 4;
        pasajero = false;
        choqueP1 = false;
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
        }
        if (c.gameObject.CompareTag("Descarga") && m_Car.CurrentSpeed<=2f)
        {
            pasajero = false;
            CallEvent();
        }
    }

    void OnCollisionEnter(Collision c)
    {
        choque.Play();
        if (c.gameObject.CompareTag("Player2") && pasajero == true && m_CarEnemi.CurrentSpeed >= 10f)
        {
            saludP1 -= 1;
            choqueP1 = true;
            CallEvent();
        }
    }
}
