using UnityEngine;

public class Idle : BaseState
{
  private float _horizontalInput;
  private MovementSM _sm;

  public Idle(StateMachine stateMachine) : base("Idle", stateMachine)
  {
    _sm = (MovementSM)stateMachine;
  }

  public override void Enter()
  {
    base.Enter();
    _horizontalInput = 0;
  }

  public override void UpdateLogic()
  {
    base.UpdateLogic();
    _horizontalInput = Input.GetAxis("Horizontal");

    if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
    {
      _sm.ChangeState(_sm.movingState);
    }
  }
}
