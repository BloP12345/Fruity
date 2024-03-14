using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Collider bladeCollider;
    private TrailRenderer trailRenderer;

    bool canSlice;
    [SerializeField] float minSliceVelocity = 0.01f;
    public float force = 5f;
    public Vector3 dir { get; private set; }    
    private void Awake()
    {
        trailRenderer = GetComponentInChildren<TrailRenderer>();  
        bladeCollider = GetComponent<Collider>();
    }


    private void OnEnable()
    {
        StopSlicing();
    }

    private void OnDisable()
    {
        StopSlicing();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            canStartSlicing();
        }else if(Input.GetMouseButtonUp(0))
        {
            StopSlicing();

        }else if(canSlice) 
        {
            WhileSlicing();
        }
    }

    public void canStartSlicing()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos;
        canSlice = true;
        bladeCollider.enabled = true;
        trailRenderer.enabled = true;
        trailRenderer.Clear();
    }

    public void StopSlicing()
    {
        canSlice = false;
        bladeCollider.enabled = false;
        trailRenderer.enabled = false;

    }

    public void WhileSlicing()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        dir = mousePos - transform.position;

        float fruitVelocity = dir.magnitude / Time.deltaTime ;

        bladeCollider.enabled = fruitVelocity > minSliceVelocity;

        transform.position = mousePos;

    }



}
