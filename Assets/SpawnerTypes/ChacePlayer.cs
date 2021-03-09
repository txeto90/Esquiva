using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChacePlayer : SpawnerType
{
    public override void shoot(Transform t)
    {
        //get a reference to the player
        GameObject player = GameObject.Find("Player");

        if (player != null)
        {
            var angle = Vector3.Angle(t.position, player.transform.position);
            var r = Quaternion.LookRotation(player.transform.position - t.transform.position);
            GameObject bullet = (GameObject)Instantiate(SpawnerManager.Instance.bulletCanon, t.position, r, t);
            Debug.Log("caca");
        }
        else
        {
            Debug.Log("caca");
        }
    }
}
