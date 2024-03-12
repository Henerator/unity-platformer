using UnityEngine;

public class Idle : Grounded
{
  public Idle(MovementSM stateMachine) : base("Idle", stateMachine) { }

  public override void Enter()
  {
    base.Enter();
    stateMachine.animator.SetBool(PlayerAnimationFlag.isIdled, true);
  }

  public override void Exit()
  {
    base.Exit();
    stateMachine.animator.SetBool(PlayerAnimationFlag.isIdled, false);
  }

  public override void UpdateLogic()
  {
    base.UpdateLogic();

    if (Mathf.Abs(_moveInput.x) > Mathf.Epsilon)
    {
      stateMachine.ChangeState(stateMachine.movingState);
    }
  }
}
