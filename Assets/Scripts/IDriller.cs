using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDriller
{
    SO_Crafts currentRessource{ get; set; }
    bool TryFindRessources();

    void BeginHarvesting();
    IEnumerator Harvest();

    List<ItemType> EndHarvesting();

}
