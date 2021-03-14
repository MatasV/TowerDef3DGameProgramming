using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    public SharedBool hasLost;
    public SharedBool hasWon;
    
    private void Start()
    {
        hasWon.valueChangeEvent.AddListener(ShowPanel);

        foreach (Transform t in transform)
        {
            t.gameObject.SetActive(false);
        }
    }

    public void ShowPanel()
    {
        if (hasWon && !hasLost)
        {
            foreach (Transform t in transform)
            {
                t.gameObject.SetActive(true);
            }
        }
    }

    private void OnDestroy()
    {
        hasWon.valueChangeEvent.RemoveListener(ShowPanel);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
