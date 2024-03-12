using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jumping : Aired
{
  public Jumping(MovementSM stateMachine) : base("Jumping", stateMachine) { }

  public override void Enter()
  {
    // Debug.Log("Enter");
    base.Enter();
    SubscribeJumpEvent();
    SetVelocityY(stateMachine.airSettings.jumpSpeed);
  }

  public override void Exit()
  {
    // Debug.Log("Exit");
    base.Exit();
    UnsubscribeJumpEvent();
  }

  private void SubscribeJumpEvent()
  {
    // Debug.Log("Subscribe");
    stateMachine.jumpInput.canceled += ResetVelocityY;
  }

  private void UnsubscribeJumpEvent()
  {
    // Debug.Log("Unsubscribe");
    stateMachine.jumpInput.canceled -= ResetVelocityY;
  }

  private void ResetVelocityY(InputAction.CallbackContext context)
  {
    // Debug.Log("JUMP UP");
    SetVelocityY(0);
    UnsubscribeJumpEvent();
  }
}
