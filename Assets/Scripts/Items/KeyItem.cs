using UnityEngine;

public class KeyItem : PickUpItem
{
    protected override void OnPickUp(GameObject player)
    {
        base.OnPickUp(player);
        // Aquí puedes agregar lógica específica para las llaves, como desbloquear puertas
        Debug.Log($"{gameObject.name} recogido por {player.name} y desbloquea una puerta.");

        // Por ejemplo, podrías llamar a un método en el jugador para desbloquear una puerta
        // player.GetComponent<PlayerController>().UnlockDoor();
    }
}
