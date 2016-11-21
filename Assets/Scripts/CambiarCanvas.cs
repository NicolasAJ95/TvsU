using UnityEngine;
using System.Collections;

public class CambiarCanvas : MonoBehaviour {

    private float uber;
    private Canvas canvas;
    [SerializeField]
    private Camera[] camaras;

    void Awake()
    {
        uber = PlayerPrefs.GetFloat("Uber");
    }
	// Use this for initialization
	void Start ()
    {
        Debug.Log(uber);
        if (this.name == "Canvas_P1")
        {
            if (uber == 1f)
            {
                canvas = GetComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                canvas.worldCamera = camaras[0];
            }else
            {
                canvas = GetComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                canvas.worldCamera = camaras[1];
            }
        }
        if (this.name == "Canvas_P2")
        {
            if (uber == 1f)
            {
                canvas = GetComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                canvas.worldCamera = camaras[1];
            }
            else
            {
                canvas = GetComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                canvas.worldCamera = camaras[0];
            }
        }
	}
	
}
