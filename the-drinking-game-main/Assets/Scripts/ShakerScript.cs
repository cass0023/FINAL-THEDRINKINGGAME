using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakerScript : MonoBehaviour
{
    public PlayerHand LHand;
    public PlayerHand RHand;
    public List<DrinkRecipe> drinkRecipes;
    public List<GameObject> shakerContents;
    
    public int drinkLevel = 0;
    public GameManager gameManager;
    public void Start()
    {

    }
    public void Update()
    {

    }

    public void CheckForIngredient(GameObject ingredient)
    {
        if (drinkRecipes[drinkLevel].recipeItem.Contains(ingredient)) //check if the ingredient matches the recipe
        {
            if (shakerContents.Contains(ingredient))
            {
                //figure out display
                Debug.Log("Already contains item");

            }
            else
            {
                shakerContents.Add(ingredient);
                CheckDrinkComplete();
            }
        }
        else
        {
            //lose life **ADD DISPLAY TO SCREEN
            gameManager.lossLife();
            //NOT WORKING ??
        }
    }
    private void CheckDrinkComplete()
    {
        if (shakerContents.Count == drinkRecipes[drinkLevel].recipeItem.Count)
        {
            //reset (empty shaker and drinkLevel++)
            drinkLevel++;
            shakerContents.Clear();

        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("shaker hit; " + collider.name);
    }

}
[Serializable]
public class DrinkRecipe
{
    public string name;
    public List<GameObject> recipeItem;

}