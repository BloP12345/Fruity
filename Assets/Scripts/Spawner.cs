using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] float minDelay = 0.25f;
    [SerializeField] float maxDelay = 1f;

    [SerializeField] float minAngle = -15f;
    [SerializeField] float maxAngle = 15f;

    [SerializeField] float minForce = 18f;
    [SerializeField] float maxForce = 22f;

    [SerializeField] float maxLifeTime = 5f;

    Collider spawnCollider;

    [SerializeField] GameObject[] fruitsGO;
    [SerializeField] GameObject bombGO;
    float bombPossibility = 0.05f;

    private void Awake()
    {
        spawnCollider = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnControl());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnControl()
    {
        
        yield return new WaitForSeconds(2f);

        while (enabled)
        {
            GameObject fruitGO = fruitsGO[Random.Range(0, fruitsGO.Length)];
            
            if(Random.value <bombPossibility)
            {
                fruitGO = bombGO;
                Debug.Log("Bomb");
            }


            Vector3 spawnPos = new Vector3();

            spawnPos.x = Random.Range(spawnCollider.bounds.min.x, spawnCollider.bounds.max.x);
            spawnPos.y = Random.Range(spawnCollider.bounds.min.y, spawnCollider.bounds.max.y);
            spawnPos.z = Random.Range(spawnCollider.bounds.min.z, spawnCollider.bounds.max.z);

            Quaternion lunchAngle = Quaternion.Euler(0f,0f,Random.Range(minAngle,maxAngle));
          
           GameObject fruit =   Instantiate(fruitGO,spawnPos, lunchAngle);
            Rigidbody fruitRB = fruit.GetComponent<Rigidbody>();
            fruitRB.AddForce(fruit.transform.up * Random.Range(minForce,maxForce),ForceMode.Impulse);


            


            Destroy(fruit, maxLifeTime);

            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));



   /*         GameObject bomb = Instantiate(bombGO, spawnPos, lunchAngle);
            Rigidbody bombRB = bomb.GetComponent<Rigidbody>();
            bombRB.AddForce(bomb.transform.up * Random.Range(minForce, maxForce), ForceMode.Impulse);*/


        }





    }

}
