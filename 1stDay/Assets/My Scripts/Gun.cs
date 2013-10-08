using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public float BulletSpeed;
    public float FireRate;
    public Bullet Ammo;
    public Control Shoot;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void fire()
    {
        Bullet bullet = ((GameObject)Instantiate(Ammo, transform.position, transform.rotation)).GetComponent<Bullet>();
        bullet.Speed = BulletSpeed;
    }
}
