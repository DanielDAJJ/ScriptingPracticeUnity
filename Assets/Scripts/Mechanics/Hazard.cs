using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private int damage = 25;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entity entity = collision.GetComponent<Entity>();
        if(entity != null)
        {
            entity.ReciveDamage(damage);
        }
    }
}
