using UnityEngine;
[CreateAssetMenu(fileName = "WheatDesingSO", menuName = "ScriptableObjects/WheatDesingSO")]
public class WheatDesingSO : ScriptableObject
{
    [SerializeField] private float _increaseDecreaseMultiplier;
    [SerializeField] private float _resetboostDuration;
    public float IncreaseDecreaseMultiplier => _increaseDecreaseMultiplier;
    public float ResetBoostDuration => _resetboostDuration;


    
}
