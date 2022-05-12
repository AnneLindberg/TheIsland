using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftingRecipeUI : MonoBehaviour
{
    public CraftingRecipe recipe;
    public Image backgroundImage;
    public Image icon;
    public TextMeshProUGUI itemName;
    public Image[] resourceCosts;

    public Color canCraftColor;
    public Color cannotCraftColor;
    private bool canCraft;

    void OnEnable()
    {
        UpdateCanCraft();
    }

    // updates the UI to display whether or not we can craft the recipe
    public void UpdateCanCraft()
    {
        canCraft = true;

        //Har vi tingene til at crafte?
        for (int i = 0; i < recipe.cost.Length; i++)
        {
            if (!Inventory.instance.HasItems(recipe.cost[i].item, recipe.cost[i].quantity))
            {
                canCraft = false;
                break;
            }
        }


        Debug.Log(canCraft);
        Debug.Log(canCraftColor);
        Debug.Log(cannotCraftColor); 

        //sætter farven til grøn eller rød
        backgroundImage.color = canCraft ? canCraftColor : cannotCraftColor;
    }

    //sets UI elements 
    void Start()
    {
        icon.sprite = recipe.itemToCraft.icon;
        itemName.text = recipe.itemToCraft.displayName;

        //finder resources vi skal bruge 
        for (int i = 0; i < resourceCosts.Length; i++)
        {
            if (i < recipe.cost.Length)
            {
                resourceCosts[i].gameObject.SetActive(true);
                resourceCosts[i].sprite = recipe.cost[i].item.icon;
                resourceCosts[i].transform.GetComponentInChildren<TextMeshProUGUI>().text = recipe.cost[i].quantity.ToString();
            }
            else
                resourceCosts[i].gameObject.SetActive(false);
        }
    }

    public void OnClickButton()
    {
        if (canCraft)
        {
            CraftingWindow.instance.Craft(recipe);
        }
    }
}