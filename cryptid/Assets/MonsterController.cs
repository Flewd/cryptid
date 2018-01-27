using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour {

    IMonsterState CurrentState;

    [System.NonSerialized]
    public NavMeshAgent monsterNavAgent;

	// Use this for initialization
	void Start () {
        monsterNavAgent = GetComponent<NavMeshAgent>();
        CurrentState = new MonsterRelocationState(this, true);
        CurrentState.Start();
    }
	
	// Update is called once per frame
	void Update () {
        CurrentState.Update();

        // debug input
        if (Input.GetKeyDown(KeyCode.P))
        {
            print("P Pressed");
            DoScare();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            print("O Pressed");
            DoLove();
        }
    }

    public void SwitchState(IMonsterState newState)
    {
        CurrentState.End();
        CurrentState = newState;
        CurrentState.Start();
    }

    public void DoScare()
    {

        MonsterIdleState idleState = CurrentState as MonsterIdleState;

        if (idleState != null)
        {
            print("Current state does equal IDLE");
            SwitchState(new MonsterRelocationState(this, false));
        }
    }

    public void DoLove()
    {
        MonsterIdleState idleState = CurrentState as MonsterIdleState;

        if (idleState != null)
        {
            print("Current state does equal IDLE");
            SwitchState(new MonsterRelocationState(this, true));
        }
    }
}
