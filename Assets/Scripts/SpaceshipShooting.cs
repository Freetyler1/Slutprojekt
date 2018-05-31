using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipShooting : MonoBehaviour {

    public Vector3 bulletOffset = new Vector3(0, 0.7f, 0);

    public GameObject bulletPrefab;

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;

	// Update is called once per frame
	void Update () {
        cooldownTimer -= Time.deltaTime;

		if(Input.GetButton("Fire1") && cooldownTimer <= 0) {
            //Skjuta
            Debug.Log("Pang");
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * new Vector3(0, 0.7f, 0);

            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }
	}
}
