using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : IBulletSpawner
{
    public List<GameObject> Shoot(Transform t)
    {
        //get a reference to the player
        GameObject player = GameObject.Find("Player");

        if (player != null)
        {
            var angle = Vector3.Angle(t.position, player.transform.position);
            var rotation = Quaternion.LookRotation(player.transform.position - t.transform.position);
            var bullet = GameFactory.Instance.InstantiateObject(PrefabManager.Instance.GetRandomBullet(), t.position, rotation, t);
            return new List<GameObject>() { bullet };
        }
        else
        {
            Debug.LogWarning("Player not found for ChacePlayer. This shooter will not spawn any bullet");
        }
        return null;
    }
}
