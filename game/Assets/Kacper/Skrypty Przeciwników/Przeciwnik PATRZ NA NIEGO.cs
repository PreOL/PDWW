using UnityEngine;
using UnityEngine.AI;

public class SneakyStalker : MonoBehaviour
{
    public float viewAngle = 90f;            // Kąt widzenia gracza
    public float detectionRange = 10f;       // Maksymalna odległość wykrycia gracza
    public float moveSpeed = 3.5f;           // Prędkość poruszania się przeciwnika
    public float attackRange = 2f;           // Zasięg ataku
    public float attackCooldown = 2f;       // Czas między atakami

    private Transform player;                // Transform gracza
    private Transform playerCamera;          // Transform kamery gracza
    private NavMeshAgent agent;              // Agent do poruszania przeciwnikiem
    private Animator animator;               // Animator przeciwnika
    private float lastAttackTime = 0f;       // Czas ostatniego ataku

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        playerCamera = Camera.main.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (player == null) Debug.LogError("Nie znaleziono gracza w scenie!");
        if (playerCamera == null) Debug.LogError("Nie znaleziono kamery w scenie!");

        agent.speed = moveSpeed;
    }

    void Update()
    {
        if (player != null && playerCamera != null)
        {
            Vector3 directionToPlayer = player.position - transform.position;
            float distanceToPlayer = directionToPlayer.magnitude;

            if (distanceToPlayer <= detectionRange)
            {
                directionToPlayer.Normalize();
                float angle = Vector3.Angle(playerCamera.forward, -directionToPlayer);

                if (angle > viewAngle / 2f)
                {
                    agent.SetDestination(player.position);
                    animator.SetBool("IsRunning", true); // Biegnie za graczem

                    if (distanceToPlayer <= attackRange && Time.time > lastAttackTime + attackCooldown)
                    {
                        AttackPlayer();
                        lastAttackTime = Time.time;
                    }
                }
                else
                {
                    agent.ResetPath();
                    animator.SetBool("IsRunning", false); // Przestaje biec
                }
            }
            else
            {
                agent.ResetPath();
                animator.SetBool("IsRunning", false); // Przestaje biec
            }
        }
    }

    private void AttackPlayer()
    {
        agent.ResetPath(); // Przeciwnik przestaje się poruszać, aby zaatakować
        animator.SetBool("IsAttacking", true); // Uruchom animację ataku
        Invoke("EndAttack", 0.5f); // Zakończ animację ataku po 0.5 sekundy (czas trwania ataku)

        // Zadaj obrażenia graczowi
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(1); // Zadaj 1 punkt obrażeń graczowi
        }

        // 🚀 **Dodajemy trzęsienie kamery po ataku**
        CustomCameraShake cameraShake = playerCamera.GetComponentInParent<CustomCameraShake>(); // Znajdź skrypt CustomCameraShake na "Camera Holder"
        if (cameraShake != null)
        {
            StartCoroutine(cameraShake.ShakeCamera(0.3f, 0.1f)); // Trzęsienie kamery (czas trwania: 0.3 sekundy, intensywność: 0.1)
        }
    }

    private void EndAttack()
    {
        animator.SetBool("IsAttacking", false); // Zakończ animację ataku
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Vector3 forward = transform.forward;
        Quaternion leftRayRotation = Quaternion.AngleAxis(-viewAngle / 2f, Vector3.up);
        Quaternion rightRayRotation = Quaternion.AngleAxis(viewAngle / 2f, Vector3.up);
        Vector3 leftRayDirection = leftRayRotation * forward;
        Vector3 rightRayDirection = rightRayRotation * forward;

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, leftRayDirection * detectionRange);
        Gizmos.DrawRay(transform.position, rightRayDirection * detectionRange);
    }
}
