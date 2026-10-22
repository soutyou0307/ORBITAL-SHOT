
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public int damage = 10;
    public int maxHP = 100;
    private int currentHP;
    public int bulletDamage = 25;
    public float attackDistance = 1.5f;
    public float attackInterval = 1f;

    private float attackTimer = 0f;


    void Start()
    {
        currentHP = maxHP;
    }
    void Update()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        float distance = direction.magnitude;

        if (distance > attackDistance)
        {
            transform.position +=
                direction.normalized * speed * Time.deltaTime;
        }
        else
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0f)
            {
                PlayerHealth health =
                    player.GetComponent<PlayerHealth>();

                if (health != null)
                {
                    health.TakeDamage(damage);
                }

                attackTimer = attackInterval;
            }
        }
    }


    public void Die()
    {
        GameManager manager =
            FindAnyObjectByType<GameManager>();

        if (manager != null)
        {
            manager.AddKill();
        }

        Destroy(gameObject);
    }
    public void TakeDamage(int damageAmount)
    {
        currentHP -= damageAmount;
        currentHP = Mathf.Max(currentHP, 0);

        Debug.Log("ìGHPÅF" + currentHP + "/" + maxHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }
}