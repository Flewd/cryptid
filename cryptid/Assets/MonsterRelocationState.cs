using UnityEngine;
using System.Collections;
using System;

public class MonsterRelocationState : IMonsterState
{
    MonsterController monsterController;

    bool willMoveForward = false;

    public MonsterRelocationState(MonsterController _monsterController, bool moveForward )
    {
        monsterController = _monsterController;
        willMoveForward = moveForward;
    }

    void IMonsterState.Start()
    {
        if (willMoveForward)
        {
            monsterController.monsterNavAgent.destination = MonsterHidingPointStorage.GetNextPointTowardsCenter(monsterController.transform.position).transform.position;
        }
        else
        {
            monsterController.monsterNavAgent.destination = MonsterHidingPointStorage.GetNextPointAwayFromCenter(monsterController.transform.position).transform.position;
        }
    }

    void IMonsterState.Update()
    {
        if (Vector3.Distance(monsterController.monsterNavAgent.destination, monsterController.transform.position) < 2.1f)
        {
            monsterController.SwitchState(new MonsterIdleState(monsterController));
        }

    }

    void IMonsterState.End()
    {

    }
}
