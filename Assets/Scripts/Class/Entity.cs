using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Configuracion entidad")]
    [SerializeField] protected float moveSpeed = 5f;
    protected Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
