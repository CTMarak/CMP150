using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public float BulletSpeed;
    public float AmmoLimit;
	public float AmmoUsed = 0;
    public Bullet Ammo;
    public Control Shoot;
	public Control Reload;
	public AudioClip bang;
	public AudioClip reload;
	public AudioClip eject;
	public AudioClip empty;

	void Update () 
    {
		if (Shoot.KeyDown)
		{
			if (AmmoUsed < AmmoLimit)
			{
				AmmoUsed += 1;
				this.audio.PlayOneShot(bang);
				this.fire ();
				this.audio.PlayOneShot(eject);
			}
			else
			{
				this.audio.PlayOneShot(empty);
			}
		}
		
		if (Reload.KeyDown)
		{
			this.audio.PlayOneShot(reload);
			AmmoUsed = 0;
		}
	
	}

    void fire()
    {
        Bullet bullet = (Bullet)Instantiate(Ammo, transform.position, transform.rotation);
        bullet.Speed = BulletSpeed;
    }
}
