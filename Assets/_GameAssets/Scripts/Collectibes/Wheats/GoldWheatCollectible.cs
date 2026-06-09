using UnityEngine;

public class GoldWheatCollectible : MonoBehaviour , ICollectible
{
   [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _MovementSpeedIncreaseSpeed;
    [SerializeField] private float _resetBoostDuration;
    public void Collect()
    {
       _playerController.SetMovementSpeed(_MovementSpeedIncreaseSpeed, _resetBoostDuration);
        Destroy(gameObject);
       
    }
   
}
