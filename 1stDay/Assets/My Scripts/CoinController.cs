using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        CoinCounter.CoinCount += 1;
        Destroy(this.gameObject);
    }
}
