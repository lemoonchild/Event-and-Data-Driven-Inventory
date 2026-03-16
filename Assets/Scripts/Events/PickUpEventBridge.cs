using UnityEngine;

public class PickUpEventBridge : MonoBehaviour
{
    [Tooltip("El dato de este pickup específico")]
    public PickUpData data;

    public void OnPickedUp()
    {
        InventoryManager.Instance.AddItem(data);
    }
}