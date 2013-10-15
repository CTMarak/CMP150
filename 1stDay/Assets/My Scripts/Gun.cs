using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public float BulletSpeed;
    public float FireRate;
    public Bullet Ammo;
    public Control Shoot;

	void Update () 
    {
		if (Shoot.KeyDown)
		{
			this.fire ();
		}
	
	}

    void fire()
    {
        Bullet bullet = (Bullet)Instantiate(Ammo, transform.position, transform.rotation);
        bullet.Speed = BulletSpeed;
    }
}
