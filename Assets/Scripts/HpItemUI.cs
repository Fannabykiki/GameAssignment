using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpItemUI : MonoBehaviour
{
    public Image hpImage;
    public Sprite hpActive;
    public Sprite hpInactive;

    public void UpdateUI(bool isActive = true)
    {
        if(!hpImage) return;

        if(isActive )
        {
            hpImage.sprite = hpActive;
        }
        else
        {
            hpImage.sprite = hpInactive;
        }
    }
}
