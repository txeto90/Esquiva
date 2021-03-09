using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed;     //bullet speed

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        Debug.Log(speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("GAME OVER");
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
