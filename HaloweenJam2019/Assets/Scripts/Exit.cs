using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    [Header("Activity Bools")]
    [Tooltip("Wheather or not the player can interact with this terminal")]
    public bool isActive;
    [Tooltip("If the player is in range for interaction")]
    public bool inRange;
    [Tooltip("If the terminal has been activated")]
    public bool activated;
    [Header("Locations to Move to")]
    [SerializeField]private GameObject[] MoveLocations;
    [Header("UI Things")]
    [SerializeField] private Text interactText;

    //Player refrence. Aquired by the player interacting with the terminal
    private GameObject player;

    private void Update()
    {
        if(isActive && !activated && inRange)
        {
            interactText.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Activate();
            }
        }
        else
        {
            interactText.enabled = false;
        }
    }

    private void Activate()
    {
        activated = true;
        Debug.Log("I Have Been Pressed");
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            inRange = true;
            player = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            inRange = false;
        }
    }
}
