using System.Collections.Generic;
using UnityEngine;

public class GameUpgradeContainer : MonoBehaviour
{
    private int maxUpgradeSlots = 6;
    private List<UpgradeManager> currentUpgradeManagers;
    private List<UpgradeManager> availableUpgradeManagers;
}