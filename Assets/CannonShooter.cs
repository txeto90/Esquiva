using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : MonoBehaviour
{

    
    
    public float frequency;


    void Start()
    {
        //fire a bullet after 1 second
        InvokeRepeating("FireBullet", 2f, 2f);
    }

    void FireBullet()
    {
        var spawners = SpawnerManager.Instance.spawners;

        spawners[Random.Range(0, spawners.Count)].GetComponent<SpawnerType>().shoot(transform);
        //spawners[1].GetComponent<SpawnerType>().shoot(transform);

    }


}
