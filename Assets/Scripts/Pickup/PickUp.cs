using UnityEngine;

public class PickUp : MonoBehaviour
{
    [Header("PickUp Data")]
    public PickUpData data; // Se agrega el SO

    [Header("Event to Raise")]
    public GameEventSO onPickedUp; // Se agrega el evento 

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Collect(); 
        }
    }
    
    private void Collect(){
        onPickedUp.Raise(); // Se levanta el evento
        gameObject.SetActive(false); // Desactiva el objeto para simular que ha sido recogido
    }
}
