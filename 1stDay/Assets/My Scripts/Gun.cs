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
		if (Shoot.KeyDown)
		{
			this.fire ();
		}
	
	}

    void fire()
    {
		GameObject holder = (GameObject)Instantiate(Ammo, transform.position, transform.rotation);
        Bullet bullet = holder.GetComponent<Bullet>();
        bullet.Speed = BulletSpeed;
    }
}
