using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.InverseTransformDirection(transform.forward) * Speed * Time.deltaTime);
	}

    public float Speed;
}
