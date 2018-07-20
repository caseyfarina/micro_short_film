using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class breathing : MonoBehaviour {
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    Vector3 Scale;
    // Use this for initialization
    void Start () {
        //InvokeRepeating("breathOut",0f,2f);
        Scale = transform.localScale;
        //breathOut();
    }
    void OnSpawned()
    {
       Scale = transform.localScale;
        Invoke("breathOut",1f);
    }
	
	// Update is called once per frame
	void Update () {

        //transform.DORotate(new Vector3(0, rotationAccum, 0), randomTime, 0);
        
    }
    void breathOut()
    {
        transform.DOScale(new Vector3(Scale.x * 5f, Scale.y * 2f, Scale.z * 2f), 1f).OnComplete(breathIn);
        /*
        float breathtime = Random.Range(2.0f, 3.0f);
        transform.DOScaleX(Random.Range(minSize * 0.8f, minSize * 1.1f), breathtime).SetEase(Ease.InOutSine).OnComplete(breathIn);
        transform.DOScaleY(Random.Range(minSize * 0.8f, minSize * 1.1f), breathtime).SetEase(Ease.InOutSine);
        transform.DOScaleZ(Random.Range(minSize * 0.8f, minSize * 1.1f), breathtime).SetEase(Ease.InOutSine);
        */
    }
    void breathIn()
    {

        transform.DOScale(new Vector3(Scale.x * 1f, Scale.y * 1f, Scale.z * 1f), 1f).OnComplete(breathOut);
        /*
        float breathtime = Random.Range(2.0f, 3.0f);
        transform.DOScaleX(Random.Range(maxSize*0.8f, maxSize * 1.1f), breathtime).SetEase(Ease.InOutSine).OnComplete(breathOut);
        transform.DOScaleY(Random.Range(maxSize * 0.8f, maxSize * 1.1f), breathtime).SetEase(Ease.InOutSine);
        transform.DOScaleZ(Random.Range(maxSize * 0.8f, maxSize * 1.1f), breathtime).SetEase(Ease.InOutSine);
        */
    }
}
