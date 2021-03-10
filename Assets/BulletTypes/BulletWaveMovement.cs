using UnityEngine;

public class BulletWaveMovement : IBulletMovement
{

    private Vector3 offset = new Vector3();

    public void Update(Transform transform, float deltaTime, float speed)
    {
        transform.position += transform.forward * Time.fixedDeltaTime * speed;
    }
}
