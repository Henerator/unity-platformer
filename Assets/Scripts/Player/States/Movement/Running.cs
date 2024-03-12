using UnityEngine;

public class Running : Grounded
{
  public Running(MovementSM stateMachine) : base("Running", stateMachine) { }

  public override void Enter()
  {
    base.Enter();
    stateMachine.animator.SetBool(PlayerAnimationFlag.isRunning, true);
    UpdateVelocity();
  }

  public override void Exit()
  {
    base.Exit();
    stateMachine.animator.SetBool(PlayerAnimationFlag.isRunning, false);
  }

  public override void UpdateLogic()
  {
    base.UpdateLogic();

    if (!_sprintInput)
    {
      stateMachine.ChangeState(stateMachine.movingState);
      return;
    }

    if (Mathf.Abs(stateMachine.rigitbody.velocity.x) <= stateMachine.groundSettings.moveSpeed)
    {
      stateMachine.ChangeState(stateMachine.movingState);
    }
  }

  public override void UpdatePhysics()
  {
    base.UpdatePhysics();
    UpdateVelocity();
  }

  private void UpdateVelocity()
  {
    SetVelocityX(_moveInput.x * stateMachine.groundSettings.runSpeed);
  }
}
