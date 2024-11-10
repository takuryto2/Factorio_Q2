using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CrafterBehaviour : S_Buildings, ICrafting
{

    public Dictionary<ItemType, int> inventoryRessources {  get; set; }
    public List<SO_Crafts> allRecipe;
 

    public SO_Crafts _recipeSelected;

    bool isCoroutineRunning = false;
    protected override void Start()
    {
        allRecipe = _building.recipe;
        inventoryRessources = new Dictionary<ItemType, int>();
        base.Start();
        UpdateRecipeIngredients();
    }

    private bool TryLaunchCraft()
    {
        for (int i = 0; i < _recipeSelected.inputInt.Count; i++)
        {
            if (inventoryRessources[_recipeSelected.inputType[i]] < _recipeSelected.inputInt[i])
            {
                return false;
            }
        }
        if (!isCoroutineRunning) { BeginningCraft(_recipeSelected); return true; }
        return false;
        
    }

    public bool TryStoreRessource(ItemType ressourceType)
    {
        if (!inventoryRessources.ContainsKey(ressourceType))
        {
            return false;
        }
        inventoryRessources[ressourceType] += 1;
        TryLaunchCraft();
        
        return true;
    }


    public void BeginningCraft(SO_Crafts recipe)
    {
        for (int i = 0; i < _recipeSelected.inputInt.Count; i++)
        {
            inventoryRessources[_recipeSelected.inputType[i]]-=recipe.inputInt[i];
        }
        StartCoroutine(Crafting(recipe));
        return;
    }
    public IEnumerator Crafting(SO_Crafts recipe)
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(recipe.time / CooldownTime);
        isCoroutineRunning=false;
        EndCrafting(recipe);
        yield return null;
    }
    public List<ItemType> EndCrafting(SO_Crafts recipe)
    {
        for (int i = 0; i < _recipeSelected.outputInt.Count; i++)
        {
            _ressourcePrefabScript.SetRessourceValue(_recipeSelected.outputType[i], posToSpawnRessources);
        }
        TryLaunchCraft();
        return _recipeSelected.outputType;
    }
    public void UpdateRecipeIngredients()
    {
        inventoryRessources.Clear();
        for (int i = 0; i<_recipeSelected.inputType.Count; i++)
        {
            inventoryRessources.Add(_recipeSelected.inputType[i], 0);
        }
    }
}
