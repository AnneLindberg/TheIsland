using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AIType
{
    Passive,
    Scared,
    Aggressive
}

public enum AIState
{
    Idle,
    Wandering,
    Attacking,
    Fleeing
}

public class NPC : MonoBehaviour
{
    [Header("AI")]
    public AIType aiType;
    private AIState aiState;
    public float detectDistance;
    public float safeDistance;

    [Header("Stats")]
    public int health;
    public float walkSpeed;
    public float runSpeed;
    public ItemData[] dropOnDeath;

    [Header("Wandering")]
    public float minWanderDistance;
    public float maxWanderDistance;
    public float minWanderWaitTime;
    public float maxWanderWaitTime;

    [Header("Combat")]
    public int damage;
    public float attackRate;
    private float lastAttackTime;
    public float attackDistance;

    private float playerDistance;

    // components
    private NavMeshAgent agent;
    private Animator animator;
    private SkinnedMeshRenderer[] meshRenderers;

    void Awake()
    {
        // get components
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(PlayerController.instance.transform.position);
    }

    private void Start()
    {
        agent.SetDestination(new Vector3(81, 32, 80));
    }
}
