using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : MonoBehaviour
{

    public GameObject bulletCanon;
    public float frequency;


    void Start()
    {
        //fire a bullet after 1 second
        InvokeRepeating("FireBullet", 2f, 2f);
    }


    void Update()
    {
        //Invoke("FireBullet", frequency);
    }

    void FireBullet()
    {
        //get a reference to the player
        GameObject player = GameObject.Find("Player");

        if (player != null)
        {
            for (float i = 0; i < Mathf.PI; i += (Mathf.PI / 4))
            {
                if (Random.value <= 0.5)
                {
                    continue;
                }
                //instatiate an enemy bullet
                GameObject bullet = (GameObject)Instantiate(bulletCanon);

                //set the bullet's initial position
                bullet.transform.position = transform.position;

                //computes the bullets direction towards the player
                //convertir PI de radiant a degree i posar en funcio vector2 en compte de i
                Vector2 direction = (Vector2)(Quaternion.Euler(0, 0, i) * Vector2.right); //player.transform.position - bullet.transform.position;

                //set the bullet's direction
                bullet.GetComponent<BulletMovement>().SetDirection(direction);
            }
        }
    }

}
