using UnityEngine;

public class FacingLeft : BaseState<FacingSM>
{
  public FacingLeft(FacingSM stateMachine) : base("FacingLeft", stateMachine) { }

  public override void Enter()
  {
    base.Enter();
    stateMachine.transform.rotation = new Quaternion(0, -180, 0, 0);
  }

  public override void UpdateLogic()
  {
    base.UpdateLogic();

    if (Mathf.Round(stateMachine.rigitbody.velocity.x) > 0)
    {
      stateMachine.ChangeState(stateMachine.facingRightState);
    }
  }
}
