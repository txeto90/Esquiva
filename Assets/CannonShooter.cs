using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    
    [Tooltip("Frequency of this shooter")]
    public float frequency;

    void Start()
    {
        Shoot();
        // fire a bullet after x second
        InvokeRepeating("Shoot", 2f, 2f);
    }

    void Shoot()
    {

        // all the bullets spawnedbyt the random spawner shooter
        var bullets = BehaviourManager.Instance.GetRandomShooter().Shoot(transform);

        // Get to assign all bullets spawned from this shooter the same movement pattern
        var randomMovementPattern = BehaviourManager.Instance.GetRandomBulletMovement();

        // Get a random color and assign color to all bullets spawned by this shooter
        var colorForThisRound = new Color(Random.value, Random.value, Random.value, 1.0f);
        foreach (var bullet in bullets)
        {
            bullet.GetComponent<Bullet>().bulletMovement = randomMovementPattern;
            bullet.GetComponentInChildren<MeshRenderer>().material.color = colorForThisRound;
        }
    }
    
}
