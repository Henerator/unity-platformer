using UnityEngine;

public class BaseMovementState : BaseState<MovementSM>
{
  protected bool _grounded;
  protected Vector2 _moveInput;
  protected bool _sprintInput;

  public BaseMovementState(string name, MovementSM stateMachine) : base(name, stateMachine) { }

  public override void UpdateLogic()
  {
    base.UpdateLogic();
    _moveInput = stateMachine.moveInput.ReadValue<Vector2>();
    _sprintInput = stateMachine.sprintInput.ReadValue<float>() == 1.0f;

    Debug.Log(_sprintInput);
  }

  public override void UpdatePhysics()
  {
    base.UpdatePhysics();
    _grounded = stateMachine.rigitbody.velocity.y < 0.01f && stateMachine.groundSensor.IsTouchingLayers(Layers.Ground);
  }

  protected void SetVelocityY(float value)
  {
    stateMachine.rigitbody.velocity = new Vector2(stateMachine.rigitbody.velocity.x, value);
  }

  protected void SetVelocityX(float value)
  {
    stateMachine.rigitbody.velocity = new Vector2(value, stateMachine.rigitbody.velocity.y);
  }
}
