using UnityEngine.InputSystem;

public class Jumping : Aired
{
  public Jumping(MovementSM stateMachine) : base("Jumping", stateMachine) { }

  public override void Enter()
  {
    base.Enter();
    SubscribeJumpEvent();
    SetVelocityY(stateMachine.airSettings.jumpSpeed);
  }

  public override void Exit()
  {
    base.Exit();
    UnsubscribeJumpEvent();
  }

  private void SubscribeJumpEvent()
  {
    stateMachine.jumpInput.canceled += ResetVelocityY;
  }

  private void UnsubscribeJumpEvent()
  {
    stateMachine.jumpInput.canceled -= ResetVelocityY;
  }

  private void ResetVelocityY(InputAction.CallbackContext context)
  {
    SetVelocityY(0);
    UnsubscribeJumpEvent();
  }
}
