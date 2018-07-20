using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch_emit : MonoBehaviour {

    public ParticleSystem parts;
    private bool touching;
    public int emitAmount = 5;
    public int midinote = 71;

	// Use this for initialization
	void Start () {
        touching = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (touching)
        {
            parts.Emit(5);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            touching = true;
           // MidiOut.SendNoteOn(MidiChannel.Ch1, midinote, 0.9f);




            // body.add


        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {


            touching = false;
        }
    }
}
