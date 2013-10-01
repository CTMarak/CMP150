using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        //other.gameObject.SetActive(false);
        //Debug.Log("You Win!");
        //other.gameObject.transform.position.x -= 2f;
        CoinCounter.Win = true;
        other.gameObject.renderer.enabled = false;
    }
}
