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

    private UpgradeManager _upgradeManager;

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
        GameUpgradeManager.Instance.ApplyUpgrade(_upgradeManager);
        Time.timeScale = 1;
    }

    public void SetContent(UpgradeManager upgradeOption)
    {
        _upgradeManager = upgradeOption;
        
        var nextUpgrade = upgradeOption.NextUpgrade();

        upgradeNameText.text = upgradeOption.ManagerName;
        levelText.text = "Level: ";
        levelNumberText.text = (upgradeOption.Counter + 1).ToString();
        descriptionText.text = nextUpgrade.Description;

        upgradeImage.sprite = upgradeOption.Sprite;
    }
} 