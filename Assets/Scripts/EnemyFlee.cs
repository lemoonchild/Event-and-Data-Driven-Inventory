using UnityEngine;
using UnityEngine.AI;

public class EnemyFlee : MonoBehaviour
{
    [Header("Detection Settings")]
    public Transform player;
    public float detectionRange = 6f;

    [Header("Flee Settings")]
    public float fleeSpeed = 4f;
    public float fleeDistance = 10f; 

    [Header("Animations")]
    private Animator animator;
    private NavMeshAgent agent;
    private bool isFleeing = false;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange) {
            isFleeing = true;
        }

        if (isFleeing) {
            Flee();
        } else {
            Idle();
        }
    }

    void Flee() {
        agent.speed = fleeSpeed;

        if (!agent.pathPending && agent.remainingDistance < 0.5f) {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer > detectionRange) {
                isFleeing = false; 
            } else {
                SetFleeDestination();
            }
            return;
        }

        SetAnimatorSpeed(1f);
    }

    void SetFleeDestination() {
        Vector3 fleeDirection = (transform.position - player.position).normalized;
        Vector3 fleeTarget = transform.position + fleeDirection * fleeDistance;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(fleeTarget, out hit, fleeDistance, NavMesh.AllAreas)) {
            agent.SetDestination(hit.position);
        }
    }

    void Idle() {
        SetAnimatorSpeed(0f);
    }

    void SetAnimatorSpeed(float target) {
        float current = animator.GetFloat("Speed");
        animator.SetFloat("Speed", Mathf.Lerp(current, target, Time.deltaTime * 5f));
    }
}