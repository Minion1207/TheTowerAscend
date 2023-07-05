using UnityEngine;

public class BaseDamageAttack : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.SendMessage("TakeDam", damage);
        }
    }
}