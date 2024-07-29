using UnityEngine;
    
/// <summary>
/// State manager for control player states: run, stay.
/// </summary>
public class PlayerStateManager : MonoBehaviour
{
    private PlayerBaseState currentState;
    public PlayerStayState stayState;
    public PlayerRunState runState;

    [SerializeField] private PlayerMovement playerMovement;

    private void Awake()
    {
        stayState = new PlayerStayState(this);
        runState = new PlayerRunState(this, playerMovement);
    }

    void Start()
    {
        SwitchState(stayState);
    }

    void Update()
    {
        currentState.UpdateState();
    }

    public void SwitchState(PlayerBaseState state)
    {
        if (currentState != null)
        {
            currentState.ExitState();
        }
        currentState = state;
        state.EnterState();
    }
}