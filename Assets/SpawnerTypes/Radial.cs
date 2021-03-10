using System.Collections.Generic;
using UnityEngine;

public class Radial : IBulletSpawner
{
    public List<GameObject> Shoot(Transform t)
    {
        // get a reference to the player
        GameObject player = GameObject.Find("Player");

        if (player != null)
        {
            var bulletsSpawned = new List<GameObject>();
            const float PI2 = Mathf.PI * 2f;
            for (float i = 0; i < PI2; i += PI2 / 3f)
            {
                float angle = Mathf.Rad2Deg * i;
                var bullet = GameFactory.Instance.InstantiateObject(PrefabManager.Instance.GetRandomBullet(), t.position, Quaternion.Euler(angle, 90, 0), t);
                bulletsSpawned.Add(bullet);
            }
            return bulletsSpawned;
        }
        return null;
    }
}
