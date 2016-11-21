using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GestorPasajeros : MonoBehaviour {

    [SerializeField]
    private GameObject[] puntosRecoger;
    [SerializeField]
    private GameObject[] puntosDescarga;
    [SerializeField]
    private Sprite[] vida;

    [Header("Canvas Player1")]
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text scoreTextCarrera;
    [SerializeField]
    private float resta;
    [SerializeField]
    private Text mensaje;
    [SerializeField]
    private Image SaludP1;

    [Header("Canvas Player2")]
    [SerializeField]
    private Text scoreText2;
    [SerializeField]
    private Text scoreTextCarrera2;
    [SerializeField]
    private float resta2;
    [SerializeField]
    private Text mensaje2;
    [SerializeField]
    private Image SaludP2;

    private Vector3 posInicio;
    private Vector3 posFin;
    private float score;
    private float scoreCarrera;

    private float score2;
    private float scoreCarrera2;


    private void Start()
    {
        scoreCarrera = 0;
        score = 0;
        scoreText.text = "Score "+score;
        scoreTextCarrera.text = "Score Carrera\n" + scoreCarrera;

        scoreCarrera2 = 0;
        score2 = 0;
        scoreText2.text = "Score " + score2;
        scoreTextCarrera2.text = "Score Carrera\n" + scoreCarrera2;

        CarroPasajeros.Recoger += ActivarFinCarrera;
        CarroPasajerosP2.RecogerP2 += ActivarFinCarreraP2;
        int primerpasajero = Random.Range(0, 4);
        puntosRecoger[primerpasajero].gameObject.SetActive(true);
        posInicio = puntosRecoger[primerpasajero].gameObject.transform.position;
    }

    private void Update()
    {
        if (scoreCarrera > 0)
        {
            scoreCarrera -= resta * Time.deltaTime;
            scoreTextCarrera.text = "Score Carrera\n" + scoreCarrera.ToString("N0");
        }

        if (scoreCarrera2 > 0)
        {
            scoreCarrera2 -= resta * Time.deltaTime;
            scoreTextCarrera2.text = "Score Carrera\n" + scoreCarrera2.ToString("N0");
        }
    }

    public void ActivarFinCarrera()
    {
        if (CarroPasajeros.pasajero)
        {
            mensaje.text = "Recogiste un pasajero";
            for (int i = 0; i < puntosRecoger.Length; i++)
            {
                puntosRecoger[i].gameObject.SetActive(false);
            }
            int descarga = Random.Range(0, 4);
            puntosDescarga[descarga].gameObject.SetActive(true);
            posFin = puntosDescarga[descarga].gameObject.transform.position;
            ScoreCarrera();
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
            PlayerPrefs.SetFloat("ScoreP1", score);
            scoreCarrera = 0;
            scoreTextCarrera.text = "Score Carrera\n" + scoreCarrera.ToString("N0");
            posInicio = puntosRecoger[recogida].gameObject.transform.position;
        }

        if(CarroPasajeros.choqueP1)
        {
            if (CarroPasajeros.saludP1 == 4)
            {
                SaludP1.sprite = vida[3];
            }
            if (CarroPasajeros.saludP1 == 3)
            {
                SaludP1.sprite = vida[2];
            }
            if (CarroPasajeros.saludP1 == 2)
            {
                SaludP1.sprite = vida[1];
            }
            if (CarroPasajeros.saludP1 == 1)
            {
                SaludP1.sprite = vida[0];
            }
            if(CarroPasajeros.saludP1<=0)
            {
                ResetPasajerosP1();
            }
        }
    }

    public void ActivarFinCarreraP2()
    {
        if (CarroPasajerosP2.pasajeroP2)
        {
            mensaje2.text = "Recogiste un pasajero";
            for (int i = 0; i < puntosRecoger.Length; i++)
            {
                puntosRecoger[i].gameObject.SetActive(false);
            }
            int descarga = Random.Range(0, 4);
            puntosDescarga[descarga].gameObject.SetActive(true);
            posFin = puntosDescarga[descarga].gameObject.transform.position;
            ScoreCarreraP2();
        }
        else
        {
            mensaje2.text = "Dejaste a un pasajero";
            for (int i = 0; i < puntosDescarga.Length; i++)
            {
                puntosDescarga[i].gameObject.SetActive(false);
            }
            int recogida = Random.Range(0, 4);
            puntosRecoger[recogida].gameObject.SetActive(true);
            score2 += scoreCarrera2;
            scoreText2.text = "Score " + score2.ToString("N0");
            PlayerPrefs.SetFloat("ScoreP2", score2);
            scoreCarrera2 = 0;
            scoreTextCarrera2.text = "Score Carrera\n" + scoreCarrera2.ToString("N0");
            posInicio = puntosRecoger[recogida].gameObject.transform.position;
        }

        if (CarroPasajerosP2.choqueP2)
        {
            if (CarroPasajerosP2.saludP2 == 4)
            {
                SaludP2.sprite = vida[3];
            }
            if (CarroPasajerosP2.saludP2 == 3)
            {
                SaludP2.sprite = vida[2];
            }
            if (CarroPasajerosP2.saludP2 == 2)
            {
                SaludP2.sprite = vida[1];
            }
            if (CarroPasajerosP2.saludP2 == 1)
            {
                SaludP2.sprite = vida[0];
            }
            if (CarroPasajerosP2.saludP2 <= 0)
            {
                ResetPasajerosP2();
            }
        }
    }

    public void ScoreCarrera()
    {
        scoreCarrera = (posFin - posInicio).magnitude;
        Debug.Log(scoreCarrera);
        scoreTextCarrera.text = "Score Carrera\n" + scoreCarrera.ToString("N0");
    }

    public void ScoreCarreraP2()
    {
        scoreCarrera2 = (posFin - posInicio).magnitude;
        Debug.Log(scoreCarrera2);
        scoreTextCarrera2.text = "Score Carrera\n" + scoreCarrera2.ToString("N0");
    }

    public void ResetPasajerosP1()
    {
        for (int i = 0; i < puntosDescarga.Length; i++)
        {
            puntosDescarga[i].gameObject.SetActive(false);
        }
        scoreCarrera = 0;
        scoreTextCarrera.text = "Score Carrera\n" + scoreCarrera;

        int primerpasajero = Random.Range(0, 4);
        puntosRecoger[primerpasajero].gameObject.SetActive(true);
        posInicio = puntosRecoger[primerpasajero].gameObject.transform.position;

        mensaje.text = "Perdiste tu pasajero, debes buscar otro";
        mensaje2.text = "El jugador 1 perdió su pasajero, puedes recoger uno";

        SaludP1.sprite = vida[3];
    }

    public void ResetPasajerosP2()
    {
        for (int i = 0; i < puntosDescarga.Length; i++)
        {
            puntosDescarga[i].gameObject.SetActive(false);
        }

        scoreCarrera2 = 0;
        scoreTextCarrera2.text = "Score Carrera\n" + scoreCarrera2;

        int primerpasajero = Random.Range(0, 4);
        puntosRecoger[primerpasajero].gameObject.SetActive(true);
        posInicio = puntosRecoger[primerpasajero].gameObject.transform.position;

        mensaje.text = "El jugador 2 perdió su pasajero, puedes recoger uno";
        mensaje2.text = "Perdiste tu pasajero, debes buscar otro";

        SaludP2.sprite = vida[3];
    }
}
