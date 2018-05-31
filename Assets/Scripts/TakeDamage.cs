using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

    public int health = 1;

    public float invulnPeriod = 0; 
    float invulnTimer = 0;
    int correctlayer;

    SpriteRenderer spriteRend;

        void Start() {
        correctlayer = gameObject.layer;

        //Gör att "Spaceship" spelaren börjar blinka när den blir skadad genom att ta bort och sätta på "spriterenderen"
        //Fungerar inte för "enemies" utan endast för "Spaceship"
        spriteRend = GetComponent<SpriteRenderer>();

        if(spriteRend==null) {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

            if (spriteRend == null) {
              Debug.LogError("Object '" + gameObject.name + "'has no sprite renderer.");
            }
        }
    }

    void OnTriggerEnter2D() {
        health--;
        
        if(invulnTimer > 0) {
            invulnTimer = invulnPeriod;
            gameObject.layer = 10;
        }        
     }

    void Update() {

        if (invulnTimer > 0) {
            invulnTimer -= Time.deltaTime;

            if (invulnTimer <= 0) {
                gameObject.layer = correctlayer;

                if(spriteRend != null) {
                    spriteRend.enabled = true;
                }
             }
            else
            {
                  if(spriteRend != null) {
                    spriteRend.enabled = !spriteRend.enabled;
                }
            }
        }
        // Om jag har 0 liv kvar dör jag
        if (health <= 0) {
                Die();
            }
        }
    // Om jag har 0 liv förstörs objektet
    void Die() {
            Destroy(gameObject);

        }
   }
    
