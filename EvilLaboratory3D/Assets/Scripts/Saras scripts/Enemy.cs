using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    PlayerMovement player;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        player = FindFirstObjectByType<PlayerMovement>();
    }

    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}