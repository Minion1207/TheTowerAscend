using UnityEngine;

public class GainExpSoul : MonoBehaviour
{
    public float soulAmount;
    public float minExpAmount;
    public float maxExpAmount;
    public float expAmount;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            expAmount = Random.Range(minExpAmount, maxExpAmount);
            Debug.Log("PlayerObject");

            col.GetComponent<BaseStats>().SoulFragments += soulAmount;
            col.GetComponent<LevelSystem>().ExpAmount += expAmount;

            // Optional: Destroy the game object after collision
            Destroy(gameObject);
        }
    }
}