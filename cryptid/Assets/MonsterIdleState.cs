using UnityEngine;
using System.Collections;
using System;

public class MonsterIdleState : IMonsterState
{
    MonsterController monsterController;

    public MonsterIdleState(MonsterController _monsterController)
    {
        monsterController = _monsterController;
    }

    void IMonsterState.Start()
    {
        Debug.Log("im now idle");
    }

    void IMonsterState.Update()
    {

    }

    void IMonsterState.End()
    {

    }


}
