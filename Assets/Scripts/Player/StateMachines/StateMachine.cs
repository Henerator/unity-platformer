using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private bool enableLog = false;

    BaseState currentState;

    void Start()
    {
        currentState = GetInitialState();
        currentState?.Enter();
    }

    void Update()
    {
        currentState?.UpdateLogic();
    }

    void LateUpdate()
    {
        currentState?.UpdatePhysics();
    }

    public void ChangeState(BaseState newState)
    {
        Log($"[EXIT STATE]{currentState.name}");
        Log($"[ENTER STATE]{newState.name}");

        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    private void Log(string message)
    {
        Debug.Log(message);
    }
}
