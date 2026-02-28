using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Settings")]
    public Transform[] points; 
    public float patrolSpeed = 2.5f;
    public float waitTime = 2f;

    private bool isWaiting = false; 
    private float waitTimer = 0f;  

    [Header("Detection Settings")]
    public Transform player;
    public float detectionRange = 10f;
    public float visionAngle = 60f; 
    public float followSpeed = 3.5f;

    private Animator animator;

    private NavMeshAgent agent;
    private int currentPointIndex = 0;
    private bool isChasing = false;

    void Start(){
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        GoToNextPoint();
    }

    void Update(){

        if (canSeePlayer()){
            isChasing = true; 
        }
        if (isChasing){
            followPlayer();
        }
        else {
            patrol();
        }
    }

    void patrol() {
        agent.speed = patrolSpeed;
        if (isWaiting) {
            SetAnimatorSpeed(0f); 
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f) {
                isWaiting = false;
                GoToNextPoint();
            }
            return;
        }
        SetAnimatorSpeed(1f); 
        if (!agent.pathPending && agent.remainingDistance < 0.5f) {
            isWaiting = true;
            waitTimer = waitTime; 
        }
    }

    void followPlayer() {
        agent.speed = followSpeed; 
        SetAnimatorSpeed(1f); 
        agent.SetDestination(player.position);
    }

    void SetAnimatorSpeed(float target) {
        float current = animator.GetFloat("Speed");
        animator.SetFloat("Speed", Mathf.Lerp(current, target, Time.deltaTime * 5f));
    }

    void GoToNextPoint() {
        if (points.Length == 0) return;

        agent.SetDestination(points[currentPointIndex].position);
        currentPointIndex = (currentPointIndex + 1) % points.Length;
    }

    bool canSeePlayer() {
        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer > detectionRange) return false;

        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);
        if (angleToPlayer > visionAngle / 2f) return false;

        if (Physics.Raycast(transform.position + Vector3.up, directionToPlayer.normalized, distanceToPlayer)){
            return true; 
        }

        return false;
    }
}
