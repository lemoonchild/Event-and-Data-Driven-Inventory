using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    [Header("Detection Settings")]
    public Transform player;
    public float detectionRange = 10f;
    public float visionAngle = 60f;

    [Header("Chase Settings")]
    public float chaseSpeed = 4f;
    public float losePlayerRange = 15f; 

    [Header("Attack Settings")]
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;
    private float attackTimer = 0f;

    private Animator animator;
    private NavMeshAgent agent;

    enum State { Idle, Chase, Attack }
    private State currentState = State.Idle;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        attackTimer -= Time.deltaTime;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        switch (currentState) {
            case State.Idle:
                if (canSeePlayer()) currentState = State.Chase;
                break;

            case State.Chase:
                if (distanceToPlayer <= attackRange) currentState = State.Attack;
                if (distanceToPlayer > losePlayerRange) currentState = State.Idle;
                break;

            case State.Attack:
                if (distanceToPlayer > attackRange) currentState = State.Chase;
                break;
        }

        switch (currentState) {
            case State.Idle:   DoIdle();   break;
            case State.Chase:  DoChase();  break;
            case State.Attack: DoAttack(); break;
        }
    }

    void DoIdle() {
        agent.ResetPath();
        SetAnimatorSpeed(0f);
        animator.SetBool("isAttacking", false);
    }

    void DoChase() {
        agent.speed = chaseSpeed;
        agent.SetDestination(player.position);
        SetAnimatorSpeed(1f);
        animator.SetBool("isAttacking", false);
    }

    void DoAttack() {
        agent.ResetPath();
        SetAnimatorSpeed(0f);

        if (attackTimer <= 0f) {
            animator.SetTrigger("attack"); 
            attackTimer = attackCooldown;
        }
    }

    void SetAnimatorSpeed(float target) {
        float current = animator.GetFloat("Speed");
        animator.SetFloat("Speed", Mathf.Lerp(current, target, Time.deltaTime * 5f));
    }

    bool canSeePlayer() {
        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer > detectionRange) return false;

        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);
        if (angleToPlayer > visionAngle / 2f) return false;

        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, directionToPlayer.normalized, out hit, distanceToPlayer)) {
            if (hit.transform == player) return true;
        }

        return false;
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}