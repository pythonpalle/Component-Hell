using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI upgradeNameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI levelNumberText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image upgradeImage;
    [SerializeField] private Button _button;
    public Button Button => _button;

    private IUpgradable upgradeOption;

    private void OnEnable()
    {
        _button.onClick.AddListener(ApplyUpgrade);
    }
    
    private void OnDisable()
    {
        _button.onClick.RemoveListener(ApplyUpgrade);
    }

    private void ApplyUpgrade()
    {
        GameUpgradeManager.Instance.ApplyUpgrade(upgradeOption);
        Time.timeScale = 1;
    }

    public void SetContent(IUpgradable upgradeOption)
    {
        this.upgradeOption = upgradeOption;
        var manager = upgradeOption.GetUpgradeManager();
        var data = manager.DataHolder;

        upgradeNameText.text = data.ManagerName;
        upgradeImage.sprite = data.Image;

        
        if (!manager.IsInstantiated)
        {
            levelText.text = "NEW!";
            levelNumberText.text = "";
            descriptionText.text = data.ManagerDescription;
        }
        else
        {
            var nextUpgrade = manager.NextUpgrade();

            levelText.text = "Level: ";
            levelNumberText.text = (manager.Counter + 1).ToString();
            descriptionText.text = nextUpgrade.Description;
        }
    }
} 