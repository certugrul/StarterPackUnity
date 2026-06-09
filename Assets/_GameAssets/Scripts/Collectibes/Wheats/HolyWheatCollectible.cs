using UnityEngine;

public class HolyWheatCollectible : MonoBehaviour
{
   [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _forceIncreaseSpeed;
    [SerializeField] private float _resetBoostDuration;
    public void Collect()
    {
       _playerController.SetJumpForce(_forceIncreaseSpeed, _resetBoostDuration);
        Destroy(gameObject);
    }
}
