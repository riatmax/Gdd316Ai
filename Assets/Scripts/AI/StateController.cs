using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    public GameObject player;
    public AgentBaseState currentState;

    public readonly AttackState attState = new AttackState();
    public readonly PatrolState patState = new PatrolState();

    public GameObject[] waypoints;

    public NavMeshAgent agent;

    public MeshRenderer meshRenderer;

    private void Start()
    {
        TransitionToState(patState);
    }
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        agent = GetComponent<NavMeshAgent>();
    }
    public void TransitionToState(AgentBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    private void Update()
    {
        currentState.Update(this);
    }
}
