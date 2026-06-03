using UnityEngine;

public class StateController : MonoBehaviour
{
    private PlayerState _currentState = PlayerState.Idle;


    private void Start()
    {
        ChangeState(PlayerState.Idle);
    }

    public void ChangeState(PlayerState newPlayerState)
    {
        if (_currentState == newPlayerState) return;

        _currentState = newPlayerState;
    }

    public PlayerState GetCurrentState()
    {
        return _currentState;
    }
}
