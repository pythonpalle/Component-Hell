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

    private UpgradeManager upgradeOption;

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

    public void SetContent(UpgradeManager upgradeOption)
    {
        this.upgradeOption = upgradeOption;
        var data = upgradeOption.DataHolder;

        upgradeNameText.text = data.ManagerName;
        upgradeImage.sprite = data.Image;

        
        if (!upgradeOption.IsInstantiated)
        {
            levelText.text = "NEW!";
            levelText.color = Color.yellow;
            levelNumberText.text = "";
            descriptionText.text = data.ManagerDescription;
        }
        else
        {
            var nextUpgrade = upgradeOption.NextUpgrade();

            levelText.text = "Level: ";
            levelText.color = Color.black;
            levelNumberText.text = (upgradeOption.Counter + 1).ToString();
            descriptionText.text = nextUpgrade.Description;
        }
    }
} 