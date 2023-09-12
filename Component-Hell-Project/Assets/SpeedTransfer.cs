using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTransfer : MonoBehaviour
{
    [SerializeField] private MovementContainer from;
    [SerializeField] private MovementContainer to;

    [SerializeField] private bool mulitply;

    public void Transer()
    {
        float mulitplier = mulitply ? @to.MovementSpeed.value : 1;

        to.MovementSpeed.value = mulitplier * @from.MovementSpeed.value;
    }
}
