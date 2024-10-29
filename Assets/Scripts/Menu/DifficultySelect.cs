using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class DifficultySelect : MonoBehaviour
{
    public GameObject SelectDiff;
    private AudioSource soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        soundEffect = GetComponent<AudioSource>();
        GetComponent<TapGesture>().Tapped += tappedHandler;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void tappedHandler(object sender, EventArgs e)
    {
        soundEffect.Play();
        Invoke("nextMenu", (float)0.25);
    }

    private void nextMenu()
    {
        SelectDiff.SetActive(true);
    }
}