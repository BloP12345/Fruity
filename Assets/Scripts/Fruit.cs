using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // 2 gameobject (whole and sliced)
    // in sliced - 2 gameobject of bottom and top 

    // full -- > entertrigger -- > sliced 
    [SerializeField] GameObject wholeFruit;
    [SerializeField] GameObject slicedFruit;

    Rigidbody fruitRB;
    Collider fruitCD;

    private void Awake()
    {
        wholeFruit.SetActive(true); 
        fruitCD = GetComponent<Collider>();
        fruitRB = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Blade blade = other.GetComponent<Blade>();

        if (blade != null)
        {

            slice(blade.dir, blade.transform.position,blade.force);
         
        }
        
    }

    public void slice(Vector3 dir, Vector3 position, float force)
    {

        wholeFruit.SetActive(false);
        slicedFruit.SetActive(true);
        fruitCD.enabled = false;
        Rigidbody[] slices = slicedFruit.GetComponentsInChildren<Rigidbody>();

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        slicedFruit.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        foreach(Rigidbody slice in slices)
        {
            slice.velocity = fruitRB.velocity;
            slice.AddForceAtPosition(dir * force, position, ForceMode.Impulse);
            
        }



    }



}
