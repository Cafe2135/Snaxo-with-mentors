using UnityEngine;
using UnityEngine.UI;
using TMPro; // Include this if you use TextMeshPro for labels

public class PantryButton : MonoBehaviour
{
    private IngredientData data;
    private PantryManager manager;
    
    public Image iconImage;
    public TextMeshProUGUI nameText; // Optional: for the food name

    // This is called by the PantryManager when the menu opens
    public void Setup(IngredientData newData, PantryManager newManager)
    {
        data = newData;
        manager = newManager;

        if (iconImage != null)
            iconImage.sprite = data.icon;
            
        if (nameText != null)
            nameText.text = data.ingredientName;
    }

    // Connect this to the Button component's OnClick event in the Inspector
    public void OnClick()
    {
        manager.GiveItemToPlayer(data);
    }
}