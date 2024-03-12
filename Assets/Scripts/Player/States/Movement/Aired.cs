using UnityEngine;

public class Aired : BaseMovementState
{
  public Aired(string name, MovementSM stateMachine) : base(name, stateMachine) { }

  public override void Enter()
  {
    base.Enter();
    stateMachine.animator.SetBool(PlayerAnimationFlag.isAired, true);
  }

  public override void Exit()
  {
    base.Exit();
    stateMachine.animator.SetBool(PlayerAnimationFlag.isAired, false);
  }

  public override void UpdateLogic()
  {
    base.UpdateLogic();
    stateMachine.animator.SetFloat(PlayerAnimationFlag.velocityY, stateMachine.rigitbody.velocity.y);

    if (Mathf.Abs(stateMachine.rigitbody.velocity.y) > stateMachine.airSettings.maxVelocityY)
    {
      SetVelocityY(stateMachine.airSettings.maxVelocityY * Mathf.Sign(stateMachine.rigitbody.velocity.y));
    }

    if (_grounded)
    {
      BaseState<MovementSM> state = stateMachine.rigitbody.velocity.x == 0 ? stateMachine.idleState : stateMachine.movingState;
      stateMachine.ChangeState(state);
    }
  }

  public override void UpdatePhysics()
  {
    base.UpdatePhysics();
    SetVelocityX(_moveInput.x * stateMachine.airSettings.moveSpeed);
  }
}
