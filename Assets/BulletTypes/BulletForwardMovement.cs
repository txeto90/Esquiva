using UnityEngine;

public class BulletForwardMovement : IBulletMovement
{
    public void Update(Transform transform, float deltaTime, float speed)
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
