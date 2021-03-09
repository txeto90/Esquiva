using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed;     //bullet speed
    public bool isReady;    //to know when the bullet direction is set

    private UnityEngine.Vector2 direction;  //the direction of the bullet

    void Awake()
    {
        isReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            //get the bullet current position
            UnityEngine.Vector2 position = transform.position;

            //compute the bullet's new position
            position += direction * speed * Time.deltaTime;

            //update the bullet's position
            transform.position = position;

            /*destroy object if the bullet is out
            UnityEngine.Vector2 min = Camera.main.ViewportToWorldPoint(new UnityEngine.Vector3(0, 0));
            UnityEngine.Vector2 max = Camera.main.ViewportToWorldPoint(new UnityEngine.Vector3(1, 1));
                        
            if((transform.position.x < min.x) || (transform.position.x < max.x) || (transform.position.y < min.y)
                || (transform.position.y < max.y))
            {
                Destroy(gameObject);
            }
            */
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("GAME OVER");
        }
    }
    public void SetDirection(UnityEngine.Vector2 dir)
    {
        direction = dir.normalized;

        isReady = true;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
