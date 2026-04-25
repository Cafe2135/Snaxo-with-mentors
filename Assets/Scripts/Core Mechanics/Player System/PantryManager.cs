using UnityEngine;
using System.Collections.Generic;

public class PantryManager : MonoBehaviour, IInteractable
{
    [Header("UI References")]
    public GameObject pantryUI;       // The Panel in your Canvas
    public Transform buttonContainer; // The object with Grid Layout Group
    public GameObject buttonPrefab;   // A Button with the PantryButton script

    [Header("Data")]
    public List<IngredientData> allIngredients;

    private PlayerController interactingPlayer;

    void Start()
    {
        pantryUI.SetActive(false);
        PopulateMenu();
    }

    private void PopulateMenu()
    {
        foreach (IngredientData data in allIngredients)
        {
            GameObject btn = Instantiate(buttonPrefab, buttonContainer);
            // Setup the button (See the PantryButton script in previous response)
            btn.GetComponent<PantryButton>().Setup(data, this);
        }
    }

    public void Interact(PlayerController player)
    {
        interactingPlayer = player;
        pantryUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None; // Free mouse to click
        Cursor.visible = true;
    }

    public void GiveItemToPlayer(IngredientData data)
    {
        if (!interactingPlayer.IsHoldingItem())
        {
            GameObject newFood = Instantiate(data.prefab);
            interactingPlayer.PickUpItem(newFood, data);
        }
        
        CloseMenu();
    }

    public void CloseMenu()
    {
        pantryUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}