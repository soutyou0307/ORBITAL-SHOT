using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 5f;
    private bool hasHit = false;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (hasHit) return;

        Enemy enemy =
            collision.collider.GetComponentInParent<Enemy>();

        if (enemy != null)
        {
            hasHit = true;

            enemy.TakeDamage(enemy.bulletDamage);

            Destroy(gameObject);
        }
    }
}