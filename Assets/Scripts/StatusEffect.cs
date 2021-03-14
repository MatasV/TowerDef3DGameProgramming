using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffect : MonoBehaviour
{
    public float effectTimer;
    public Sprite effectIcon;
    public GameObject affectee;
    public Image selectedImage;
    public Enemy affectedEnemy;
    public virtual void ActivateStatus(Transform parent)
    {
        affectee = parent.gameObject;
        affectedEnemy = affectee.GetComponent<Enemy>();
        if (CheckForDuplicates()) Destroy(gameObject);
        transform.SetParent(parent);
        Invoke(nameof(DeactivateStatus), effectTimer);
        ActivateImage();
    }

    private bool CheckForDuplicates()
    {
        foreach (Transform child in affectedEnemy.statusTransform)
        {
            if (child.name == this.name)
            {
                child.GetComponent<StatusEffect>().effectTimer += effectTimer;
                Debug.Log("found duplicate effect");
                return true;
            }
            
        }

        return false;
    }

    public virtual void DeactivateStatus()
    {
        selectedImage.enabled = false;
        Destroy(gameObject);
    }

    public virtual void ActivateImage()
    {
        if (!(effectIcon is null) && !(affectee is null))
        {
            var canvas = affectee.GetComponentInChildren<Canvas>();
            var imageHolder = canvas.transform.GetComponentInChildren<Shadow>();
            
            foreach (Transform img in imageHolder.transform)
            {
                var image = img.GetComponent<Image>();
                if (image.enabled == false)
                {
                    selectedImage = image;
                    image.enabled = true;
                    image.sprite = effectIcon;
                    return;
                }
            }
        }
    }
}