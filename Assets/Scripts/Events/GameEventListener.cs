using UnityEngine; 
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour 
{
    [Tooltip("El GameEventSO al que este listener está suscrito")]
    public GameEventSO gameEvent;

    [Tooltip("Lo que ocurre cuando el evento es levantado")]
    public UnityEvent response;

    private void OnEnable() {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable() {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(){
        response.Invoke();
    }
}