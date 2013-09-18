using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        Debug.Log("You Win!");
    }
}
