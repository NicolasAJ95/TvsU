using UnityEngine;
using System.Collections;

public class GestorGanador : MonoBehaviour {

    [SerializeField]
    private GameObject[] imagenes;

    private float uber;
    private float scoreP1;
    private float scoreP2;

    void Awake()
    {
        scoreP1 = PlayerPrefs.GetFloat("ScoreP1");
        scoreP2 = PlayerPrefs.GetFloat("ScoreP2");
        Debug.Log(scoreP1);
        Debug.Log(scoreP2);
    }

    // Use this for initialization
    void Start () {
	    if(scoreP1>scoreP2)
        {
            imagenes[0].SetActive(true);
        }
        else
        {
            imagenes[1].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
