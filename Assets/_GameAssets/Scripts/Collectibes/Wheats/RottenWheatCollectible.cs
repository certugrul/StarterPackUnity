using UnityEngine;

public class RottenWheatCollectible : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _MovementSpeedDecreaseSpeed;
    [SerializeField] private float _resetBoostDuration;
    public void Collect()
    {
       _playerController.SetMovementSpeed(_MovementSpeedDecreaseSpeed, _resetBoostDuration);
        Destroy(gameObject);
    }
}
