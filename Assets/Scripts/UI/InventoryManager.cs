using UnityEngine;
using System.Collections.Generic;
using TMPro; 

public class InventoryManager : MonoBehaviour
{
    // Singleton 
    public static InventoryManager Instance { get; private set; }

    [Header("UI Elements")]
    public Transform inventoryPanel; // Panel que contiene los slots
    public GameObject inventorySlotPrefab; // Prefab del slot

    [Header("Score UI")]
    public TextMeshProUGUI scoreText;  

    [Header("Score")]
    public int currentScore = 0; 

    // Lista de items recogidos
    private List<PickUpData> collectedItems = new List<PickUpData>();

    private void Awake() { // Si existe, se destruye, sino se registra como instancia oficial
        if (Instance != null && Instance != this){
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }

    private void Start()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore;
    }

    public void AddItem(PickUpData data){
        if (data.addsToInventory)
        {
            collectedItems.Add(data);
            SpawnSlot(data);
        } else {
            AddScore(data.scoreValue);
        }
    }

    private void SpawnSlot(PickUpData data){
        GameObject slot = Instantiate(inventorySlotPrefab, inventoryPanel); // Slot dentro de panel

        InventorySlot slotScript = slot.GetComponent<InventorySlot>(); // Config slot con datos del pickup
        slotScript.Setup(data);
    }

    private void AddScore(int amount){
        currentScore += amount;
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore;
    }
}
