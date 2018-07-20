using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class cameraInOut : MonoBehaviour {

    public float speed_min = 15.0f;
    public float speed_max = 20.0f;
    public float distance_min = -30.0f;
    public float distance_max = -50.0f;
    public float inner_distance = -28.0f;
    public float xOffSet = 0.0f;

    private float speed;
    private float distance;

    public Tween camTween;
    public Tween rotTween;
    private float timer = 2f;
    private float rotationsPerMinute;
    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(0f, 0f, -400f);
        distance = Random.Range(distance_min, distance_max);
        speed = Random.Range(speed_min, speed_max);
        camTween = transform.DOLocalMove(new Vector3(xOffSet, 0 , distance), speed).SetEase(Ease.InOutSine).OnComplete(tweenin);
        rotTween = transform.DOLocalRotate(new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-90f, 90f)), speed).SetEase(Ease.InOutSine);
        Time.timeScale = timer;

        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            camTween.Pause();
            Camera.main.backgroundColor = new Color(0,0,0,0);

         }

        if (Input.GetKeyDown("m")){
            timer += 0.2f;
        }
        if (Input.GetKeyDown("n"))
        {
            timer -= 0.2f;
        }

        timer = Mathf.Clamp(timer,0.1f, 3.0f);
        Time.timeScale = timer;

        /*
        if (Input.GetKeyDown("s"))
        {
            Camera.main.DOShakeRotation(4f, 5f, 1, 30f, true);
        }*/

        //MidiOut.SendControlChange(MidiChannel.Ch1, 4, 1.0f);
    }

    void tweenin()
    {
        distance = Random.Range(distance_min, distance_max);
        speed = Random.Range(speed_min, speed_max);
        float xMovement = Random.Range(-3, 3);
        float yMovement = Random.Range(-3, 3);
        camTween = transform.DOLocalMove(new Vector3(xMovement, yMovement, inner_distance), speed).SetEase(Ease.InOutSine).OnComplete(tweenout);
        rotTween = transform.DOLocalRotate(new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-90f, 90f)), speed).SetEase(Ease.InOutSine);
    }

    void tweenout()
    {
        distance = Random.Range(distance_min, distance_max);
        speed = Random.Range(speed_min, speed_max);
        float xMovement = Random.Range(-3, 3);
        float yMovement = Random.Range(-3, 3);
        camTween = transform.DOLocalMove(new Vector3(xMovement, yMovement, distance), speed).SetEase(Ease.InOutSine).OnComplete(tweenin);
        rotTween = transform.DOLocalRotate(new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-90f, 90f)), speed).SetEase(Ease.InOutSine).OnComplete(tweenin);

    }
}
