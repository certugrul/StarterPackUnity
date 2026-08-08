using UnityEngine;

public class GoldWheatCollectible : MonoBehaviour , ICollectible
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private WheatDesingSO _wheatDesingSO;
   
    
    public void Collect()
    {
       _playerController.SetMovementSpeed(_wheatDesingSO.IncreaseDecreaseMultiplier, _wheatDesingSO.ResetBoostDuration);
        Destroy(gameObject);
       
    }
   
}
