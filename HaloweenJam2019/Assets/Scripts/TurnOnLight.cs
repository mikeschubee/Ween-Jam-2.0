﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class TurnOnLight : MonoBehaviour
{
    public GameObject Light;
    public bool InteractTrigger;
    public bool LightReset;
    public GameObject player;
    public Text InteractText;
    AudioSource buttonPush;

    private void Awake()
    {
        Light.SetActive(false);
        LightReset = true;
        player = GameObject.FindGameObjectWithTag("Player");
        InteractText.enabled = false;
        buttonPush = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        if((other.gameObject.tag == "Player") && (LightReset == true))
        {
            InteractTrigger = true;
            InteractText.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InteractTrigger = false;
            InteractText.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (InteractTrigger == true))
        {
            Light.SetActive(true);
            StartCoroutine(LightDuration());
            buttonPush.Play(0);
        }
    }

    IEnumerator LightDuration()
    {
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        health.currentHealth = 10;
        InteractTrigger = false;
        yield return new WaitForSeconds(60);
        Light.SetActive(false);
        LightReset = false;
        InteractTrigger = false;
        yield return new WaitForSeconds(120);
        LightReset = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
