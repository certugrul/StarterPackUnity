using UnityEngine;

public class HolyWheatCollectible : MonoBehaviour, ICollectible
{
   [SerializeField] private PlayerController _playerController;
    [SerializeField] private WheatDesingSO _wheatDesingSO;
    public void Collect()
    {
       _playerController.SetJumpForce(_wheatDesingSO.IncreaseDecreaseMultiplier, _wheatDesingSO.ResetBoostDuration);
        Destroy(gameObject);
    }
}
