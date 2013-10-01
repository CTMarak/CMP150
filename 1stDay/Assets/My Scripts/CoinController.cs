using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

    public int CoinValue = 1;

    void OnTriggerEnter(Collider other)
    {
        audio.Play();
        CoinCounter.CoinCount += CoinValue;
        this.renderer.enabled = false;
        this.collider.enabled = false;
        Destroy(this.gameObject,1);
    }
}
