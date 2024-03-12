using UnityEngine;

public class Moving : BaseState
{
  private float _horizontalInput;
  private MovementSM _sm;

  public Moving(StateMachine stateMachine) : base("Moving", stateMachine)
  {
    _sm = (MovementSM)stateMachine;
  }

  public override void Enter()
  {
    base.Enter();
    _horizontalInput = 0;
    _sm.animator.SetBool("isWalking", true);
  }

  public override void Exit()
  {
    base.Exit();
    _sm.animator.SetBool("isWalking", false);
  }

  public override void UpdateLogic()
  {
    base.UpdateLogic();
    _horizontalInput = Input.GetAxis("Horizontal");

    if (Mathf.Abs(_horizontalInput) <= Mathf.Epsilon)
    {
      _sm.ChangeState(_sm.idleState);
    }
  }

  public override void UpdatePhysics()
  {
    base.UpdatePhysics();

    Vector2 velocity = _sm.rigitbody.velocity;
    velocity.x = _horizontalInput * _sm.movementSpeed;
    _sm.rigitbody.velocity = velocity;
  }
}
