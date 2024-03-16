using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Blade blade = other.GetComponent<Blade>();
        Score score = FindAnyObjectByType<Score>();

        if(blade != null)
        {
            Destroy(gameObject);
            score.bombSliced();

        }
    }
}
