using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void Update () {
        transform.Translate(transform.InverseTransformDirection(transform.forward) * Speed * Time.deltaTime);
	}

    public float Speed;
}
