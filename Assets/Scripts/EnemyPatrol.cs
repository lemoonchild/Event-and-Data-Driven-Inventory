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
    public float danceRange = 4f; 

    private Animator animator;

    private NavMeshAgent agent;
    private int currentPointIndex = 0;
    private bool isDancing = false; 

    void Start(){
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        GoToNextPoint();
    }

    void Update(){
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= danceRange  && canSeePlayer()) {
            isDancing = true;
        } else {
            isDancing = false;
        }

        if (isDancing) {
            Dance();
        } else {
            patrol();
        }
    }

    void Dance() {
        agent.ResetPath(); 
        agent.velocity = Vector3.zero;
        SetAnimatorSpeed(0f);
        animator.SetBool("isDancing", true);
    }

    void patrol() {
        animator.SetBool("isDancing", false); 
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
        
        Debug.Log("Distancia: " + distanceToPlayer + " | DetectionRange: " + detectionRange);
        if (distanceToPlayer > detectionRange) return false;
        
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);
        Debug.Log("Angulo: " + angleToPlayer + " | VisionAngle/2: " + (visionAngle / 2f));
        if (angleToPlayer > visionAngle / 2f) return false;

        Debug.DrawRay(transform.position + Vector3.up, directionToPlayer.normalized * distanceToPlayer, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, directionToPlayer.normalized, out hit, distanceToPlayer)){
            if (hit.transform == player) {
                return true; 
            }
        }
        return false;
    }
}