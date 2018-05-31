using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public Vector3 bulletOffset = new Vector3(0, 0.7f, 0);

    public GameObject bulletPrefab;
    int bulletLayer;

    public float fireDelay = 0.5f;
    float cooldownTimer = 0;

    Transform player;


    {
        bulletLayer = gameObject.layer;
    }

      void Update() {

        if (player == null)
        {
            GameObject go = GameObject.FindWithTag("Player");

            if (go != null)
            {
                player = go.transform;

            }

        }


        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0 && player !=null && Vector3.Distance(transform.position, player.position) < 3) 
        {
            //Skjuta
            Debug.Log("Pang");
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGo.layer = bulletLayer;
        }
    }
}
