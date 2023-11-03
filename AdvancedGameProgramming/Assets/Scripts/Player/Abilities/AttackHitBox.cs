using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") == true)
        {
            GameCharacterStats gameCharacterStats = GameObject.Find("PlayerController").GetComponent<GameCharacterStats>();
            int damage = gameCharacterStats.GetDamageOutput();
            other.GetComponentInChildren<EntityHP>().TakeDamage(damage);
        }
    }
}
