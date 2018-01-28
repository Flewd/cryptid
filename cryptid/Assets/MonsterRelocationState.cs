using UnityEngine;
using System.Collections;
using System;

public class MonsterRelocationState : IMonsterState
{
    MonsterController monsterController;

    bool willMoveForward = false;

    HidingPoint currentDestination;

    public MonsterRelocationState(MonsterController _monsterController, bool moveForward )
    {
        monsterController = _monsterController;
        willMoveForward = moveForward;
    }

    void IMonsterState.Start()
    {
        if (willMoveForward)
        {
            currentDestination = MonsterHidingPointStorage.GetNextPointTowardsCenter(monsterController.transform.position);
            monsterController.monsterNavAgent.destination = currentDestination.transform.position;
        }
        else
        {
            currentDestination = MonsterHidingPointStorage.GetNextPointTowardsCenter(monsterController.transform.position);
            monsterController.monsterNavAgent.destination = currentDestination.transform.position;
        }
        monsterController.monsterNavAgent.isStopped = false;
    }

    void IMonsterState.Update()
    {
        if (Vector3.Distance(monsterController.monsterNavAgent.destination, monsterController.transform.position) < 2.1f)
        {
            monsterController.SwitchState(new MonsterIdleState(monsterController));
        }
        if (currentDestination.name != "Final")
        {
            monsterController.CheckDistanceToPlayer();
        }
    }

    void IMonsterState.End()
    {
        monsterController.monsterNavAgent.Stop();
    }
}
