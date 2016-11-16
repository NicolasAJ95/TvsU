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
    [SerializeField]
    private Text scoreTextCarrera;
    [SerializeField]
    private float resta;
    [SerializeField]
    private Text mensaje;

    private Vector3 posInicio;
    private Vector3 posFin;
    private float score;
    private float scoreCarrera;
    
    private void Start()
    {
        scoreCarrera = 0;
        score = 0;
        scoreText.text = "Score "+score;
        scoreTextCarrera.text = "Score Carrera\n" + scoreCarrera;
        CarroPasajeros.Recoger += ActivarFinCarrera;
        int primerpasajero = Random.Range(0, 4);
        puntosRecoger[primerpasajero].gameObject.SetActive(true);
        posInicio = puntosRecoger[primerpasajero].gameObject.transform.position;
        int segundopasajero = Random.Range(0, 4);
        if (primerpasajero == segundopasajero)
            segundopasajero += 1;
        puntosRecoger[segundopasajero].gameObject.SetActive(true);
        posInicio = puntosRecoger[segundopasajero].gameObject.transform.position;
    }

    private void Update()
    {
        if (scoreCarrera != 0)
        {
            scoreCarrera -= resta * Time.deltaTime;
            scoreTextCarrera.text = "Score Carrera\n" + scoreCarrera.ToString("N0");
        }
    }

    public void ActivarFinCarrera()
    {
        if (CarroPasajeros.pasajero)
        {
            mensaje.text = "Recogiste un pasajero";
            for(int i = 0; i < puntosRecoger.Length; i++)
            {
                puntosRecoger[i].gameObject.SetActive(false);
            }
            int descarga = Random.Range(0, 4);
            puntosDescarga[descarga].gameObject.SetActive(true);
            posFin = puntosDescarga[descarga].gameObject.transform.position;
            ScoreCarrera();
            CarroPasajeros.pasajero = false;
        }
        else
        {
            mensaje.text = "Dejaste a un pasajero";
            for (int i = 0; i < puntosDescarga.Length; i++)
            {
                puntosDescarga[i].gameObject.SetActive(false);
            }
            int recogida = Random.Range(0, 4);
            puntosRecoger[recogida].gameObject.SetActive(true);
            score += scoreCarrera;
            scoreText.text = "Score " + score.ToString("N0");
            scoreCarrera = 0;
            scoreTextCarrera.text = "Score Carrera\n" + scoreCarrera.ToString("N0");
            posInicio = puntosRecoger[recogida].gameObject.transform.position;
            CarroPasajeros.pasajero = true;
        }
    }

    public void ScoreCarrera()
    {
        scoreCarrera = (posFin - posInicio).magnitude;
        scoreTextCarrera.text = "Score Carrera\n" + scoreCarrera.ToString("N0");
    }
}
