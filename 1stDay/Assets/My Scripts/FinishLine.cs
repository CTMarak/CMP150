using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CoinCounter.Win = true;
            Renderer[] PlayerRenderers = other.GetComponentsInChildren<Renderer>();
            foreach (Renderer playerRenderer in PlayerRenderers)
            {
                playerRenderer.enabled = false;
            }
        }
    }
}
