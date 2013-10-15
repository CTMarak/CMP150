using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public GameObject ControlledObject;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("in ontriggerenter");
        if (other.tag == "Bullet")
        {
            Debug.Log("I am a bullet!");
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Die has been called!");
        ControlledObject.renderer.enabled = false;
    }
}
