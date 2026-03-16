using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [Header("UI Reference")]
    public Image iconImg; 
    public TextMeshProUGUI nameText;

    public void Setup(PickUpData data){
        nameText.text = data.pickUpName; 

        if (data.icon != null){
            iconImg.sprite = data.icon; 
            iconImg.enabled = true;
        } else {
            iconImg.enabled = false;
        }
    }

}