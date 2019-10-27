using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeathUI : MonoBehaviour
{
    public Canvas canvas;
    public GameObject eventSystem;

    void Start()
    {
        canvas.enabled = false;
        eventSystem = GameObject.FindGameObjectWithTag("EventSystem");
    }

    private void Update()
    {
        PlayerScore isScoring = eventSystem.GetComponent<PlayerScore>();
        if (isScoring == false)
        {
            canvas.enabled = true;
        }
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }

}
