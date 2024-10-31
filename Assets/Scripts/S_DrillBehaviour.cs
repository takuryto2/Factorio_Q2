using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class S_DrillBehaviour : S_Buildings, IDriller
{
    SO_Crafts _ressources;
    public SO_Crafts currentRessource { get { return _ressources; } set { _ressources = value; } }
//    [SerializeField] GameObject junk;

    protected override void Start()
    {
        base.Start();
        if (TryFindRessources())
        {
            BeginHarvesting();
        }
    }
    public bool TryFindRessources()
    {
       List<Collider>colliders = Physics
            .OverlapBox(transform.position, (new Vector3(transform.localScale.x, transform.localScale.y * 2, transform.localScale.z)))
            .ToList();
        Collider ressourceFound = null;
        colliders=colliders
            .Where(collider => collider.TryGetComponent<S_RessourceSource>(out S_RessourceSource source))
            .ToList();
        if(colliders.Count > 0)
        {
            ressourceFound=colliders.First();
        }
        if(ressourceFound == null) { Debug.Log("No ressources nearby."); return false; }
        currentRessource=ressourceFound.GetComponent<S_RessourceSource>().ressourceToMine;
        Debug.Log("ressource found");
        return true;
    }
    public void BeginHarvesting()
    {
        StartCoroutine(Harvest());
        return;
    }
    public IEnumerator Harvest()
    {
        while (true)
        {
            yield return new WaitForSeconds(CooldownTime*currentRessource.time);
            break;
        }
        Debug.Log("Harvest done");
        EndHarvesting();
    }
    public List<ItemType> EndHarvesting()
    {
        StartCoroutine(Harvest());

 //       Instantiate(junk, junk.transform.position, Quaternion.identity);
        return currentRessource.outputType;
        
    }


}
