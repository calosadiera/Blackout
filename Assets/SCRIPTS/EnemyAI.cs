using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Pengaturan Deteksi")]
    public float detectionRadius = 5f;
    public float chaseSpeed = 3.5f;
    public float returnSpeed = 2f;

    [Header("Referensi")]
    public Transform player;

    private Vector2 spawnPosition;
    private Rigidbody2D rb;

    private enum EnemyState { Idle, Chase, Return }
    private EnemyState currentState = EnemyState.Idle;

    void Start()
    {
        spawnPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        switch (currentState)
        {
            case EnemyState.Idle:
                rb.linearVelocity = Vector2.zero;
                if (distanceToPlayer <= detectionRadius)
                    currentState = EnemyState.Chase;
                break;

            case EnemyState.Chase:
                ChasePlayer();
                if (distanceToPlayer > detectionRadius)
                    currentState = EnemyState.Return;
                break;

            case EnemyState.Return:
                ReturnToSpawn();
                if (distanceToPlayer <= detectionRadius)
                    currentState = EnemyState.Chase;
                break;
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * chaseSpeed;
    }

    void ReturnToSpawn()
    {
        Vector2 direction = ((Vector3)spawnPosition - transform.position).normalized;
        rb.linearVelocity = direction * returnSpeed;

        if (Vector2.Distance(transform.position, spawnPosition) < 0.1f)
        {
            rb.linearVelocity = Vector2.zero;
            currentState = EnemyState.Idle;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}