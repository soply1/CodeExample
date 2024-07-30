using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    public void RefreshProgressBar(float _newHealthPoints, float _maxHealthPoints)
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        fillImage.fillAmount = _newHealthPoints / _maxHealthPoints;
    }
    public void HideProgressBar()
    {
        gameObject.SetActive(false);
    }
}
