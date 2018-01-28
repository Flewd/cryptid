using UnityEngine;
using System.Collections;
using System;

public class MonsterIdleState : IMonsterState
{
    MonsterController monsterController;

    enum ScareState {awaitingDialog, scared, loved};
    ScareState currentState = ScareState.awaitingDialog;

    GameObject player;

    public MonsterIdleState(MonsterController _monsterController)
    {
        monsterController = _monsterController;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void IMonsterState.Start()
    {
    }

    void IMonsterState.Update()
    {
        float angle = 40; // should be a little less than field of view
        if (Vector3.Angle(player.transform.forward, monsterController.transform.position - player.transform.position) < angle)
        {
            if (currentState != ScareState.awaitingDialog)
            {
                monsterController.StartCoroutine(waitThenExecuteReaction());
            }
        }

        // debug inputs should be replaced by microphone detection
        if (Input.GetKeyDown(KeyCode.P))
        {
            DoScare();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            DoLove();
        }

        monsterController.CheckDistanceToPlayer();
    }

    IEnumerator waitThenExecuteReaction()
    {
        yield return new WaitForSeconds(2);
        ExecuteReaction();
    }

    void IMonsterState.End()
    {
    }

    public void DoScare()
    {
        currentState = ScareState.scared;
    }

    public void DoLove()
    {
        currentState = ScareState.loved;
    }

    public void ExecuteReaction()
    {
        switch (currentState)
        {
            case ScareState.loved:
                monsterController.SwitchState(new MonsterRelocationState(monsterController, true));
                break;
            case ScareState.scared:
                monsterController.SwitchState(new MonsterRelocationState(monsterController, false));
                break;
        }
    }
}
