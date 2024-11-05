using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CrafterBehaviour : S_Buildings, ICrafting
{

    public Dictionary<ItemType, int> inventoryRessources { get; set; }
 

    public SO_Crafts recipeSelected;

    bool isCoroutineRunning = false;
    protected override void Start()
    {
        inventoryRessources = new Dictionary<ItemType, int>();
        base.Start();
        for (int i = 0; i < recipeSelected.inputType.Count; i++)
        {
            inventoryRessources.Add(recipeSelected.inputType[i], 0);
        }


    }

    private bool TryLaunchCraft()
    {
        for (int i = 0; i < recipeSelected.inputInt.Count; i++)
        {
            if (inventoryRessources[recipeSelected.inputType[i]] < recipeSelected.inputInt[i])
            {
                return false;
            }
        }
        if (!isCoroutineRunning) { StartCoroutine(Crafting(recipeSelected)); return true; }
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
        for (int i = 0; i < recipeSelected.outputInt.Count; i++)
        {
            _ressourcePrefabScript.SetRessourceValue(recipeSelected.outputType[i], transform.position + Vector3.left + Vector3.up);
        }
        TryLaunchCraft();
        return recipeSelected.outputType;
    }
}
