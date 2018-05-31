using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    public float maxSpeed = 5f;
    public float rotSpeed = 180f; 

    float shipBoundaryRadius = 0.7f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

        }


        //Rotation av skepp

        // Ta tag i våra rotations quaternioner
        Quaternion rot = transform.rotation;

        // Ta tag om Z euler vinkeln
        float z = rot.eulerAngles.z;

        //Ändra Z axeln beroende på Input
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

        // Återskapa Quaternion
        rot = Quaternion.Euler(0, 0, z);

        //Mata in Quaternion i vår rotation 
        transform.rotation = rot;

        //Rörelse av skepp
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0) ;

        pos += rot * velocity;

        //Hålla kvar spelaren inom kamerans räckhåll
             if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize) {
            pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        }

              if (pos.y - shipBoundaryRadius < - Camera.main.orthographicSize)  {
            pos.y = - Camera.main.orthographicSize + shipBoundaryRadius;
        }


        float screenRatio =(float) Screen.width / (float) Screen.height;
        float width0rtho = Camera.main.orthographicSize * screenRatio;

             if (pos.x + shipBoundaryRadius > width0rtho) {
            pos.x = width0rtho - shipBoundaryRadius;
        }

             if (pos.x - shipBoundaryRadius < -width0rtho)  {
            pos.x = -width0rtho + shipBoundaryRadius;
        }
        transform.position = pos;

    }
}