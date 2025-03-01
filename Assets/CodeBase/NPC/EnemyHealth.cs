using UnityEngine;
namespace CodeBase.NPC
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int _health;
        
        public int GetHealth() => _health;
        
        public void TakeDamage(int damage)
        {
            if(_health > 0)_health -= damage;
            else Die();
        }

        public void Die()
        {
            Debug.LogError("Im dying!");
            Destroy(this.gameObject);
        }
    }
}
