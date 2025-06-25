using UnityEngine;

public class KeyItem : PickUpItem
{
    protected override void OnPickUp(GameObject player)
    {
        base.OnPickUp(player);
        // Aqu� puedes agregar l�gica espec�fica para las llaves, como desbloquear puertas
        Debug.Log($"{gameObject.name} recogido por {player.name} y desbloquea una puerta.");

        // Por ejemplo, podr�as llamar a un m�todo en el jugador para desbloquear una puerta
        // player.GetComponent<PlayerController>().UnlockDoor();
    }
}
