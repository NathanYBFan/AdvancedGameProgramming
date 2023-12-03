using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") == true)
        {
            int damage = GameCharacterStats._Instance.GetDamageOutput();
            other.GetComponentInChildren<EntityHP>().TakeDamage(damage);
        }
    }
}
