using UnityEngine;

[CreateAssetMenu(fileName = "PickUpData", menuName = "Scriptable Objects/PickUpData")]
public class PickUpData : ScriptableObject
{
    [Header("PickUp Data")]
    public string pickUpName;
    public Sprite icon; 

    [Header("Configuration")]
    public bool addsToInventory;
    public int scoreValue;

}
