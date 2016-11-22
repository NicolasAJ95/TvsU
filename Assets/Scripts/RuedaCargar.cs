using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RuedaCargar : MonoBehaviour {
	
    void Start()
    {
       SceneManager.LoadSceneAsync("NivelPrueba");
    }
	// Update is called once per frame
	void Update () {
        GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -30 * Time.deltaTime));
	}
}
