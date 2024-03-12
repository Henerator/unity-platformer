using UnityEngine;

public class Moving : Grounded
{
  public Moving(MovementSM stateMachine) : base("Moving", stateMachine) { }

  public override void Enter()
  {
    base.Enter();
    stateMachine.animator.SetBool(PlayerAnimationFlag.isWalking, true);
    UpdateVelocity();
  }

  public override void Exit()
  {
    base.Exit();
    stateMachine.animator.SetBool(PlayerAnimationFlag.isWalking, false);
  }

  public override void UpdateLogic()
  {
    base.UpdateLogic();

    if (_sprintInput)
    {
      stateMachine.ChangeState(stateMachine.runningState);
      return;
    }

    if (Mathf.Abs(stateMachine.rigitbody.velocity.x) <= Mathf.Epsilon)
    {
      stateMachine.ChangeState(stateMachine.idleState);
    }
  }

  public override void UpdatePhysics()
  {
    base.UpdatePhysics();
    UpdateVelocity();
  }

  private void UpdateVelocity()
  {
    SetVelocityX(_moveInput.x * stateMachine.groundSettings.moveSpeed);
  }
}
