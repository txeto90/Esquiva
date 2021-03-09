using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radial : SpawnerType
{
    public override void shoot(Transform transform)
    {
        //get a reference to the player
        GameObject player = GameObject.Find("Player");

        if (player != null)
        {
            for (float i = 0; i < Mathf.PI * 2f; i += ((Mathf.PI * 2f) / 3f))
            {
                float angle = Mathf.Rad2Deg * i;
                GameObject bullet = (GameObject)Instantiate(SpawnerManager.Instance.bulletCanon, transform.position, Quaternion.Euler(angle, 90, 0), transform);
                bullet.transform.localScale = Vector3.one;
                bullet.GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);

            }
        }
    }
}
