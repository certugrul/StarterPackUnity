using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int _maxHealth=3;
    private int _currentHealth;

    private void Start()
    {
        _currentHealth=_maxHealth;
        
    }
    public void Damage(int damage)
    {
        if (_currentHealth > 0)
        {
            _currentHealth-=damage;
            //UI ANIMATE DAMAGE TODO
            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
            }

        }
    }
    public void Heal(int healAmount)
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth=Mathf.Min(_currentHealth + healAmount, _maxHealth);
        }
    }

}
