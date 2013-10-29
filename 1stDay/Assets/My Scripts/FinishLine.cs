using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
			if(enemies.Length == 0)
			{
	            Renderer[] PlayerRenderers = other.GetComponentsInChildren<Renderer>();
	            foreach (Renderer playerRenderer in PlayerRenderers)
	            {
	                playerRenderer.enabled = false;
	            }
	            CoinCounter.Win = true;
			}
			else
			{
				foreach (var enemy in enemies)
				{
					Debug.Log(enemy.name);
				}
			}
        }
    }
}
