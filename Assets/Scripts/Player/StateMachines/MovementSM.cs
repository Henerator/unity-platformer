using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementSM : StateMachine<MovementSM>
{
    public ComponentSettings componentSettings;
    public GroundSettings groundSettings;
    public AirSettings airSettings;

    [HideInInspector] public Rigidbody2D rigitbody;
    [HideInInspector] public Animator animator;
    [HideInInspector] public PlayerInput playerInput;
    [HideInInspector] public Collider2D groundSensor;

    [HideInInspector] public BaseState<MovementSM> idleState;
    [HideInInspector] public BaseState<MovementSM> movingState;
    [HideInInspector] public BaseState<MovementSM> fallingState;
    [HideInInspector] public BaseState<MovementSM> jumpingState;

    [HideInInspector] public InputAction jumpInput;
    [HideInInspector] public InputAction moveInput;
    [HideInInspector] public InputAction sprintInput;

    private void Awake()
    {
        rigitbody = componentSettings.rigitbody;
        animator = componentSettings.animator;
        playerInput = componentSettings.playerInput;
        groundSensor = componentSettings.groundSensor;

        idleState = new Idle(this);
        movingState = new Moving(this);
        fallingState = new Falling(this);
        jumpingState = new Jumping(this);

        jumpInput = playerInput.actions.FindAction(InputActionName.Jump);
        moveInput = playerInput.actions.FindAction(InputActionName.Move);
        sprintInput = playerInput.actions.FindAction(InputActionName.Sprint);
    }

    protected override BaseState<MovementSM> GetInitialState()
    {
        return idleState;
    }

    [Serializable]
    public class ComponentSettings
    {
        public Rigidbody2D rigitbody;
        public Animator animator;
        public PlayerInput playerInput;
        public Collider2D groundSensor;
    }

    [Serializable]
    public class GroundSettings
    {
        public float moveSpeed = 7;
    }

    [Serializable]
    public class AirSettings
    {
        public float jumpSpeed = 24;
        public float moveSpeed = 6;
        public float maxVelocityY = 24;
    }
}
