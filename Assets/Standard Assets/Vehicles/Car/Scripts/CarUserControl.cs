using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private string HorizontalCtl = "";
        private string VerticalCtl = "";
        private string HandbrakeCtl = "";

        private float uber;

        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            uber = PlayerPrefs.GetFloat("Uber");
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

        void Start()
        {
            if (this.tag == "Player")
            {
                if (uber == 1)
                {
                    HorizontalCtl = "Horizontal_P1";
                    VerticalCtl = "Vertical_P1";
                    HandbrakeCtl = "Jump_P1";
                }
                else
                {
                    HorizontalCtl = "Horizontal_P2";
                    VerticalCtl = "Vertical_P2";
                    HandbrakeCtl = "Jump_P2";
                }
            }
            if (this.tag == "Player2")
            {
                if (uber == 1)
                {
                    HorizontalCtl = "Horizontal_P2";
                    VerticalCtl = "Vertical_P2";
                    HandbrakeCtl = "Jump_P2";
                }else
                {
                    HorizontalCtl = "Horizontal_P1";
                    VerticalCtl = "Vertical_P1";
                    HandbrakeCtl = "Jump_P1";
                }
            }
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis(HorizontalCtl);
            float v = CrossPlatformInputManager.GetAxis(VerticalCtl);            
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis(HandbrakeCtl);
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
