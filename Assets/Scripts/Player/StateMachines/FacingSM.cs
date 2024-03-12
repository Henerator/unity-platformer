using UnityEngine;

public class FacingSM : StateMachine<FacingSM>
{
    [SerializeField] public Rigidbody2D rigitbody;

    public BaseState<FacingSM> facingLeftState;
    public BaseState<FacingSM> facingRightState;

    private void Awake()
    {
        facingLeftState = new FacingLeft(this);
        facingRightState = new FacingRight(this);
    }

    protected override BaseState<FacingSM> GetInitialState()
    {
        return facingRightState;
    }
}
