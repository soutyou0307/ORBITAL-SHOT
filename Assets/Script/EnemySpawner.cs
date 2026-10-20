using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;

    public float spawnDistance = 10f;
    public float spawnInterval = 3f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 2f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null || player == null)
        {
            return;
        }

        Vector3 direction = Random.insideUnitSphere;
        direction.y = 0f;

        if (direction.sqrMagnitude < 0.01f)
        {
            direction = Vector3.forward;
        }

        direction.Normalize();

        Vector3 spawnPosition =
            player.position + direction * spawnDistance;

        spawnPosition.y = 1f;

        // ÉvÉåÉCÉÑÅ[ÇÃï˚å¸Çå¸Ç©ÇπÇÈ
        Vector3 lookDirection = player.position - spawnPosition;
        lookDirection.y = 0f;

        Quaternion enemyRotation = Quaternion.identity;

        if (lookDirection.sqrMagnitude > 0.01f)
        {
            enemyRotation = Quaternion.LookRotation(lookDirection);
        }

        // ìGÇè¢ä´
        GameObject newEnemy = Instantiate(
            enemyPrefab,
            spawnPosition,
            enemyRotation
        );

        Enemy enemyScript = newEnemy.GetComponent<Enemy>();

        if (enemyScript != null)
        {
            enemyScript.player = player;
        }
    }
}