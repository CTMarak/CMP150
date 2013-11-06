using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public GameObject ControlledObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Die();
			this.audio.Play();
        }
    }

    void Die()
    {
//        ControlledObject.renderer.enabled = false;
		Destroy(ControlledObject);
    }
}
