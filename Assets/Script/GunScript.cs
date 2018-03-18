using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    public float damage = 10f;
    //public float range = 100f;

    public Camera fpsCam;

    public ParticleSystem mazzleFlash;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1");
            Shoot();
        }
	}

    void Shoot()
    {
        Debug.Log("EnterShoot");
        RaycastHit hit;
        mazzleFlash.Play();


        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            Debug.Log("Shoot:" + hit.transform.name);

            TargetScript target = hit.transform.GetComponent<TargetScript>();
            Debug.Log("Shooting traget:" + target.name);

            if (target != null)
            {
                Debug.Log("Damage:" + damage);
                target.TakeDamage(damage);
            }
        }
    }
}
