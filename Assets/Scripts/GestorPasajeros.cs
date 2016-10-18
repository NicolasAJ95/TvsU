using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GestorPasajeros : MonoBehaviour {

    [SerializeField]
    private GameObject[] puntosRecoger;
    [SerializeField]
    private GameObject[] puntosDescarga;
    [SerializeField]
    private Text scoreText;

    private Vector3 posInicio;
    private Vector3 posFin;
    private float score;
    
    private void Start()
    {
        score = 0;
        scoreText.text = "Score "+score;
        CarroPasajeros.Recoger += ActivarFinCarrera;
        int primerpasajero = Random.Range(0, 4);
        puntosRecoger[primerpasajero].gameObject.SetActive(true);
        posInicio = puntosRecoger[primerpasajero].gameObject.transform.position;
    }

    public void ActivarFinCarrera()
    {
        if (CarroPasajeros.pasajero)
        {
            for(int i = 0; i < puntosRecoger.Length; i++)
            {
                puntosRecoger[i].gameObject.SetActive(false);
            }
            int descarga = Random.Range(0, 4);
            puntosDescarga[descarga].gameObject.SetActive(true);
            posFin = puntosDescarga[descarga].gameObject.transform.position;
            Score();
            CarroPasajeros.pasajero = false;
        }
        else
        {
            for(int i = 0; i < puntosDescarga.Length; i++)
            {
                puntosDescarga[i].gameObject.SetActive(false);
            }
            int recogida = Random.Range(0, 4);
            puntosRecoger[recogida].gameObject.SetActive(true);
            posInicio = puntosRecoger[recogida].gameObject.transform.position;
            CarroPasajeros.pasajero = true;
        }
    }

    public void Score()
    {
        score = (posFin - posInicio).magnitude;
        scoreText.text = "Score " + score.ToString("N0");
    }
}
