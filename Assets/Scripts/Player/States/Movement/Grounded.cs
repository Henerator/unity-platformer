using UnityEngine.InputSystem;

public class Grounded : BaseMovementState
{
  public Grounded(string name, MovementSM stateMachine) : base(name, stateMachine) { }

  public override void Enter()
  {
    base.Enter();
    _grounded = true;
    stateMachine.animator.SetBool(PlayerAnimationFlag.isGrounded, true);
    SubscribeJumpEvent();
  }

  public override void Exit()
  {
    base.Exit();
    stateMachine.animator.SetBool(PlayerAnimationFlag.isGrounded, false);
    UnsubscribeJumpEvent();
  }

  public override void UpdateLogic()
  {
    base.UpdateLogic();

    if (!_grounded)
    {
      stateMachine.ChangeState(stateMachine.fallingState);
      return;
    }
  }

  private void OnJump(InputAction.CallbackContext context)
  {
    stateMachine.ChangeState(stateMachine.jumpingState);
  }

  private void SubscribeJumpEvent()
  {
    stateMachine.jumpInput.started += OnJump;
  }

  private void UnsubscribeJumpEvent()
  {
    stateMachine.jumpInput.started -= OnJump;
  }
}
