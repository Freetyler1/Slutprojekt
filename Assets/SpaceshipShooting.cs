using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceshipshooting: MonoBehaviour {

    public Vector3 bulletOffset = new Vector3(0, 0.7f, 0);

    public GameObject bulletPrefab;

    public float fireDelay = 0.25f;

    int bulletLayer;

    float cooldownTimer = 0;

    private void Start()
    {
        bulletLayer = gameObject.layer;
    }
    
    void Update () {
        cooldownTimer -= Time.deltaTime;

		if(Input.GetButton("Fire1") && cooldownTimer <= 0) {
            //Skjuta
            Debug.Log("Pang");
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGo.layer = bulletLayer;
        }
	}
}
