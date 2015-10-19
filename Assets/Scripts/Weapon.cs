using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public InventorySystem inventory;

	public float fireRate;
	public GameObject bullet;
	public GameObject bulletSpawn;
	[SerializeField]
	private float fireCountdown;
	public Animator anim;

	public int currentAmmo;
	public int maxAmmo;

	void Start () {
		fireCountdown = 0;
		if (inventory.currentAmmo >= maxAmmo) {
			currentAmmo = maxAmmo;
		} else {
			currentAmmo = inventory.currentAmmo;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(fireCountdown>0){
			fireCountdown -= Time.deltaTime;
		}
	}

	public void Fire(){
		if (fireCountdown <= 0 && currentAmmo > 0) {
			if(!anim.GetBool ("Idle")){
				anim.Play("PistolShot", -1, 0f);
			}else{
				SetIdle (0);
				anim.SetTrigger ("Shot");
			}
			fireCountdown = fireRate;
		}
	}

	public void Reload(){
		if(currentAmmo < maxAmmo){
			if(inventory.currentAmmo > 0){
				int aux = maxAmmo - currentAmmo;
				if(aux > inventory.currentAmmo){
					currentAmmo += inventory.currentAmmo;
					inventory.currentAmmo = 0;
				}else{
					currentAmmo += aux;
					inventory.currentAmmo -= aux;
				}
			}
		}
	}

	public void InstantiateBullet(){
		Instantiate (bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
		currentAmmo --;
	}
	
	public void SetIdle(float state){
		bool aux;
		if(state == 0){
			aux = false;
		}else{
			aux = true;
		}
		anim.SetBool ("Idle", aux);
	}
}
