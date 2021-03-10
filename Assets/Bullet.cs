using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{

    [Tooltip("Default speed for bullet")]
    public float speed = 1000f;

    public IBulletMovement bulletMovement;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (bulletMovement != null)
        {
            bulletMovement.Update(transform, Time.deltaTime, speed);
        }
        else
        {
            Debug.LogError("Exist a bullet without a movement assigned. Please investigate this case as it shouldn't exist a bullet without movement.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("GAME OVER");
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
