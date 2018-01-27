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

    }

    public void SwitchState(IMonsterState newState)
    {
        CurrentState.End();
        CurrentState = newState;
        CurrentState.Start();
    }
}
