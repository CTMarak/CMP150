using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public float BulletSpeed;
    public float AmmoLimit;
	public float AmmoUsed = 0;
    public Bullet Ammo;
    public Control Shoot;
	public Control Reload;

	void Update () 
    {
		if (Shoot.KeyDown)
		{
			if (AmmoUsed < AmmoLimit)
			{
				AmmoUsed += 1;
				this.audio.Play();
				this.fire ();
			}
		}
		
		if (Reload.KeyDown)
		{
			AmmoUsed = 0;
		}
	
	}

    void fire()
    {
        Bullet bullet = (Bullet)Instantiate(Ammo, transform.position, transform.rotation);
        bullet.Speed = BulletSpeed;
    }
}
