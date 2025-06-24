using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private int damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!IsAlive) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            Entity player = collision.gameObject.GetComponent<Entity>();
            if (player != null && player.IsAlive)
            {
                player.ReciveDamage(damage);
                Debug.Log($"{gameObject.name} inflige {damage} de daño a {player.gameObject.name}");
            }
        }
    }
}
