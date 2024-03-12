using UnityEngine;

public class MovementSM : StateMachine
{
    [SerializeField] public Rigidbody2D rigitbody;
    [SerializeField] public Animator animator;
    [SerializeField] public float movementSpeed;

    public Idle idleState;
    public Moving movingState;

    private void Awake()
    {
        idleState = new Idle(this);
        movingState = new Moving(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}
