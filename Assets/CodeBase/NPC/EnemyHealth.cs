using UnityEngine;
namespace CodeBase.NPC
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int _health;
        
        public int Health
        {
            get
            {
                return _health;
            }

            set
            {
                if (_health > 0) _health = value;
                else
                {
                    Die();
                    _health = 0;
                }
            }
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void Die()
        {
            Debug.LogError("Im dying!");
            Destroy(this.gameObject);
        }
    }
}
