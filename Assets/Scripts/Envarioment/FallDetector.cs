using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("El jugador ha caído. Reiniciando escena...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
