using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public DrinkRecipe DrinkRecipe;
    public Sprite[] recipeSprites;
    public int recipeCount;
    public SpriteRenderer spriteRenderer;

    public GameObject recipe1;
    public GameObject recipe2;
    public GameObject recipe3;
    public GameObject recipe4;
    public GameObject recipe5;
    public GameObject recipe6;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (DrinkRecipe.recipeItem[0])
        {
            recipe1.SetActive(true);
        }
        else if (DrinkRecipe.recipeItem[1] == true)
        {
            recipe1.SetActive(false);
            recipe2.SetActive(true);
        }
        else if (DrinkRecipe.recipeItem[2] == true)
        {
            recipe2.SetActive(false); 
            recipe3.SetActive(true);
        }
        else if (DrinkRecipe.recipeItem[3] == true)
        {
            recipe3.SetActive(false);
            recipe4.SetActive(true);
        }
        else if (DrinkRecipe.recipeItem[4] == true)
        {
            recipe4.SetActive(false);
            recipe5.SetActive(true);
        }
        else if (DrinkRecipe.recipeItem[5] == true)
        {
            recipe5.SetActive(false); 
            recipe6.SetActive(true);
        }
    }
}
