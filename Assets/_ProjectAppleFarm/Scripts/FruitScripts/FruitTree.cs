// Jake
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTree : MonoBehaviour
{
    [SerializeField]
    Fruit newFruit;
    [SerializeField]
    public Item item;
    [SerializeField]
    GameObject fruitSpawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dropFruit(){
        print("Dropping Fruit");
        // Fruit newFruit = new Fruit();
        // Instantiate(newFruit, new Vector3(569.9f,7.84f,-716.4f), Quaternion.identity);
        // Instantiate(newFruit, fruitSpawnLocation.transform.position, Quaternion.identity);
        GameObject currentEntity = Instantiate(item.prefab, fruitSpawnLocation.transform.position, Quaternion.identity);
    }
}
