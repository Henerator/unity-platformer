using System;
using UnityEngine;

public class FacingRight : BaseState<FacingSM>
{
  public FacingRight(FacingSM stateMachine) : base("FacingRight", stateMachine) { }

  public override void Enter()
  {
    base.Enter();
    stateMachine.transform.rotation = new Quaternion(0, 0, 0, 0);
  }


  public override void UpdateLogic()
  {
    base.UpdateLogic();

    if (Mathf.Round(stateMachine.rigitbody.velocity.x) < 0)
    {
      stateMachine.ChangeState(stateMachine.facingLeftState);
    }
  }
}
