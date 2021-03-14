using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    public SharedBool hasLost;
    public SharedBool hasWon;
    
    private void Start()
    {
        hasLost.valueChangeEvent.AddListener(ShowPanel);

        foreach (Transform t in transform)
        {
            t.gameObject.SetActive(false);
        }
    }

    public void ShowPanel()
    {
        if (!hasWon && hasLost)
        {
            foreach (Transform t in transform)
            {
                t.gameObject.SetActive(true);
            }
        }
    }

    private void OnDestroy()
    {
        hasLost.valueChangeEvent.RemoveListener(ShowPanel);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
