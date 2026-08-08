using UnityEngine;

public class PlayerAnimationsController : MonoBehaviour
{
    
    [SerializeField] private Animator _PlayerAnimator;
    private PlayerController _PlayerController;
    private StateController _StatesController;

    private void Awake()
    {
        _PlayerController = GetComponent<PlayerController>();
        _StatesController = GetComponent<StateController>();
    }
     private void Start()
    {
        
        _PlayerController.OnPlayerJump += PlayerController_OnPlayerJump;
    }
    private void Update()
    {
        SetPlayerAnimations();
    }
   
      private void PlayerController_OnPlayerJump()
    {
        _PlayerAnimator.SetBool(Consts.PlayerAnimations.IS_JUMPING, true);
        Invoke(nameof(ResetJumpingAnimation), 0.5f);

    }
    private void ResetJumpingAnimation()
    {
        _PlayerAnimator.SetBool(Consts.PlayerAnimations.IS_JUMPING, false);
    }
    private void SetPlayerAnimations()
    {
        var currentState = _StatesController.GetCurrentState();
        
        switch (currentState)
        {
            case PlayerState.Idle:
                _PlayerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING, false);
                _PlayerAnimator.SetBool(Consts.PlayerAnimations.IS_MOVING, false);
                break;
            case PlayerState.Move:
                _PlayerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING, false);
                _PlayerAnimator.SetBool(Consts.PlayerAnimations.IS_MOVING, true);
                break;
            case PlayerState.SlideIdle:
                _PlayerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING, true);
                _PlayerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING_ACTIVE, false);
                break;
            case PlayerState.Slide:
                _PlayerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING, true);
                _PlayerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING_ACTIVE, true);
                break;
        }
    }
  


}
