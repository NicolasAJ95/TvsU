using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        public string HorizontalCtl = "Horizontal_P1";
        public string VerticalCtl = "Vertical_P1";
        public string HandbrakeCtl = "Jump_P1";

        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
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
