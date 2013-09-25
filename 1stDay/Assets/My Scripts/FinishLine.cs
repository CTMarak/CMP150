using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        Debug.Log("You Win!");
    }
}
