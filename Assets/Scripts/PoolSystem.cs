using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
public class PoolSystem : MonoBehaviour
{
    public static PoolSystem instance;
    [SerializeField] int preAllocationCount;
    Stack<GameObject> ressourcePool=new Stack<GameObject>();
    [SerializeField] GameObject ressourcePrefab;
    [SerializeField] List<SO_MeshRessources> meshList;
    [SerializeField] List<SO_RessourceType> typesList;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {

        for (int i = 0; i < preAllocationCount; i++) 
        {
            GameObject newRessource=(Instantiate(ressourcePrefab));
            newRessource.GetComponent<S_RessourceBehaviour>().pool = this;
            Release(newRessource);

        }
    }
    //puts GameObject in the pool
    public void Release(GameObject ressource)
    {
        ressourcePool.Push(ressource);
        ressource.SetActive(false);
        ressource.GetComponentInChildren<MeshFilter>().mesh = null;
    }

    //takes the object out of the pool and return it
    public GameObject Get(ItemType type, Vector3 posToSpawn)
    {
        GameObject ressourceToGet;
        if (ressourcePool.Count > 0)
        {
            ressourceToGet = ressourcePool.Pop();
            
        }
        else 
        {
            ressourceToGet = (Instantiate(ressourcePrefab));
            ressourceToGet.GetComponent<S_RessourceBehaviour>().pool = this;
        }
        ressourceToGet.SetActive(true);
        ressourceToGet.GetComponent<S_RessourceBehaviour>().SetRessourceValue(type,posToSpawn);
        GameObject visual= ressourceToGet.transform.GetChild(0).gameObject;
        foreach (SO_RessourceType item in typesList) 
        {
            if (item.acceptedType.Contains(type))
            {
                visual.GetComponent<MeshRenderer>().material = item.material;
                break;
            }
        }
        foreach (SO_MeshRessources item in meshList)
        {
            if (item.acceptedType.Contains(type))
            {
                visual.transform.localScale = item.mesh.transform.localScale;
                visual.transform.localPosition = item.mesh.transform.localPosition + new Vector3(0,0.1f,0);
                visual.GetComponentInChildren<MeshFilter>().mesh = item.mesh.sharedMesh;
                

            }
        }
        
        return ressourceToGet;


    }
}
