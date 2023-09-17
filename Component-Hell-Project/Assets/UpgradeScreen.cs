using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScreen : MonoBehaviour
{
    [SerializeField] private GameObject popup;
    [SerializeField] private List<UpgradeBox> _upgradeBoxes;

    private void OnEnable()
    {
        popup.SetActive(false);

        for (int i = 0; i < _upgradeBoxes.Count; i++)
        {
            _upgradeBoxes[i].Button.onClick.AddListener(OnClick);
        }
    }

    private void Start()
    {
        GameUpgradeManager.Instance.OnChosenOptions.AddListener(OnChosenOptions);
    }

    private void OnClick()
    {
        popup.SetActive(false);
    }

    public void OnChosenOptions(List<IUpgradable> upgradeOptions)
    {
        if (upgradeOptions.Count == 0)
            return;
        
        popup.SetActive(true);
        for (int i = 0; i < _upgradeBoxes.Count; i++)
        {
            _upgradeBoxes[i].gameObject.SetActive(false);
        }
        
        for (int i = 0; i < upgradeOptions.Count; i++)
        {
            _upgradeBoxes[i].gameObject.SetActive(true);
            _upgradeBoxes[i].SetContent(upgradeOptions[i]);
        }
        
        Time.timeScale = 0;
    }
}