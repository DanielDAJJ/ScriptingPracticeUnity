using System;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [Header("Efecto al recoger")]
    public AudioClip pickupSound;
    public GameObject pickupEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnPickUp(other.gameObject);
        }
    }

    protected virtual void OnPickUp(GameObject player)
    {
        Debug.Log($"{gameObject.name} recogido por {player.name}");
        if(pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        }
        if (pickupEffect != null)
        {
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
