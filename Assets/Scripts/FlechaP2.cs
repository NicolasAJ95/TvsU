using UnityEngine;
using System.Collections;

public class FlechaP2 : MonoBehaviour
{

    [SerializeField]
    private GameObject[] objetivo;

    void Update()
    {
        for (int i = 0; i < objetivo.Length; i++)
        {
            if (objetivo[i].gameObject.activeInHierarchy == true)
            {
                transform.LookAt(objetivo[i].transform);
            }
        }
    }
}