using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTransferManager : MonoBehaviour
{
    [SerializeField] private List<DataTransfer> _transfers;

    public void TransferAll(GameComponent toComponent)
    {
        foreach (var transfer in _transfers)
        {
            transfer.Transfer(toComponent);
        }
    }
}
