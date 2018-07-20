using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]

public class part_behavior : MonoBehaviour {
    public float UnLocked_Perc = 50.0f;

    public float size_min = 0.2f;
    public float size_max = 0.8f;
    public float R_ForcePercentage = 50.0f;
    public float R_forceLow = 10.0f;
    public float R_forceHight = 100.0f;

    public GameObject Magnet;
    public float Atr_forcePercentage = 50.0f;
    public float Atr_force_min = 1.0f;
    public float Atr_force_max = 2.0f;

    Rigidbody body;
    // Use this for initialization
    void Start () {
        
        body = GetComponent<Rigidbody>();

        if (Random.Range(0.0f, 100.0f) < UnLocked_Perc)
        {
            body.constraints = RigidbodyConstraints.None;
        }
       // body.mass = body.mass * transform.localScale.x;
        //body.drag = body.drag * (1f * transform.localScale.x);
       // Atr_force_max = Atr_force_max * transform.localScale.x *.2f;
        //Atr_forcePercentage = Atr_forcePercentage * transform.localScale.x;
    }

    void OnSpawned()
    {
        transform.localScale = Vector3.zero;
        float randomScale = Random.Range(size_min , size_max);
        Vector3 tempScale = new Vector3(randomScale, randomScale, randomScale);
        transform.DOScale(tempScale, .2f).SetEase(Ease.InElastic);
        //transform.localScale = tempScale;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        body = GetComponent<Rigidbody>();
        float tester = Random.Range(0.0f, 100.0f);
        float amount = Random.Range(R_forceLow, R_forceHight);
        if (tester < R_ForcePercentage)
        {
            body.AddForce(new Vector3(
                Random.Range(-amount, amount),
                Random.Range(-amount, amount),
                Random.Range(-amount, amount)));
        }

        float attractiontest = Random.Range(0f, 100f);

        if (Magnet != null)
        {
            if (attractiontest < Atr_forcePercentage)
            {
                body.AddForce((Magnet.transform.position - transform.localPosition) * (Random.Range(Atr_force_min, Atr_force_max)));

            }
        }


    }
}
