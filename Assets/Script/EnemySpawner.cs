using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("敵の設定")]
    public GameObject enemyPrefab;
    public Transform player;

    [Header("出現設定")]
    public int maxSpawnCount = 10;
    public float spawnDistance = 10f;
    public float spawnInterval = 3f;

    private int spawnedCount = 0;

    void Start()
    {
        if (spawnInterval <= 0f)
        {
            spawnInterval = 3f;
        }

        InvokeRepeating(nameof(SpawnEnemy), 2f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null || player == null)
        {
            return;
        }

        // 設定した出現数に達したら停止
        if (spawnedCount >= maxSpawnCount)
        {
            CancelInvoke(nameof(SpawnEnemy));
            return;
        }

        // プレイヤーを中心にランダムな方向を決める
        Vector3 direction = Random.insideUnitSphere;
        direction.y = 0f;

        if (direction.sqrMagnitude < 0.01f)
        {
            direction = Vector3.forward;
        }

        direction.Normalize();

        // プレイヤーから指定距離だけ離れた位置
        Vector3 spawnPosition =
            player.position + direction * spawnDistance;

        spawnPosition.y = 1f;

        // プレイヤーの方向を向かせる
        Vector3 lookDirection = player.position - spawnPosition;
        lookDirection.y = 0f;

        Quaternion enemyRotation = Quaternion.identity;

        if (lookDirection.sqrMagnitude > 0.01f)
        {
            enemyRotation = Quaternion.LookRotation(lookDirection);
        }

        // 敵を出現させる
        GameObject newEnemy = Instantiate(
            enemyPrefab,
            spawnPosition,
            enemyRotation
        );
        newEnemy.name = "SpawnedEnemy_" + spawnedCount;

        Debug.Log("生成：" + newEnemy.name);

        // 敵にプレイヤーを設定する
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();

        if (enemyScript != null)
        {
            enemyScript.player = player;
        }

        // 出現した数を記録
        spawnedCount++;

        // 上限に達したら、次の出現を停止
        if (spawnedCount >= maxSpawnCount)
        {
            CancelInvoke(nameof(SpawnEnemy));
        }
    }
}