using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : AgentBaseState
{
    public override void EnterState(StateController agent)
    {
        agent.meshRenderer.material.color = Color.red;
    }

    public override void ExitState(StateController agent)
    {
        
    }

    public override void Update(StateController agent)
    {
        agent.agent.SetDestination(agent.player.transform.position);
        if (Mathf.Abs(agent.player.transform.position.x - agent.transform.position.x) > 5 &&
            Mathf.Abs(agent.player.transform.position.z - agent.transform.position.z) > 5) {
            agent.TransitionToState(agent.patState);
        }
    }
}
