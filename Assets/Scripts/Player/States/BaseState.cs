public class BaseState<SM>
{
  public string name;
  protected SM stateMachine;

  public BaseState(string name, SM stateMachine)
  {
    this.name = name;
    this.stateMachine = stateMachine;
  }

  public virtual void Enter() { }
  public virtual void UpdateLogic() { }
  public virtual void UpdatePhysics() { }
  public virtual void Exit() { }
}
