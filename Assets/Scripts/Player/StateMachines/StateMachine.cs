using System;
using UnityEngine;

public class StateMachine<SM> : MonoBehaviour
{
    public DebugSettings debugSettings;

    BaseState<SM> currentState;

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

    public void ChangeState(BaseState<SM> newState)
    {
        Log($"[ENTER STATE] {newState.name}");

        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    protected virtual BaseState<SM> GetInitialState()
    {
        return null;
    }

    protected void Log(string message)
    {
        if (!debugSettings.enableLog) return;

        Debug.Log(message);
    }

    [Serializable]
    public class DebugSettings
    {
        public bool enableLog = false;
    }
}
