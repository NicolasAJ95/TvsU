using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class LucesTraseras : MonoBehaviour
    {
        [SerializeField]
        private Material[] material;

        public CarController car; // reference to the car controller, must be dragged in inspector
        
        private Renderer m_Renderer;


        private void Start()
        {
            m_Renderer = GetComponent<Renderer>();
            m_Renderer.material = material[1];
        }


        private void Update()
        {
            if (car.BrakeInput > 0f)
            {
                m_Renderer.material = material[0];
            }else
            {
                m_Renderer.material = material[1];
            }
        }
    }
}
