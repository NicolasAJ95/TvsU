using UnityEngine;
using System.Collections;

public class Transiciones : MonoBehaviour {

    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
    }

    void OnTriggerStay(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            animator.SetBool("car", true);
        }
        else
        {
            animator.SetBool("car", false);
        }
    }
}
