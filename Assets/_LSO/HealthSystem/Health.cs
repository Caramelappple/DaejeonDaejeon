using System;
using _Scripts.HealthSystem;
using UnityEngine;

public class Health : DamageableResources, IRecoverable
{
    public event Action<RecoverResultData> OnRecover;
    
    public virtual void Recover(RecoverData data)
    {
        if(IsDestroyed) return;

        int recoverValue = data.recoverValue;
        Health giver = data.giver;

        int lastValue = Value;
        Value += recoverValue;
        int calcValue = Value;
        bool hasRecover = lastValue < calcValue;

        if (hasRecover)
        {
            Debug.Log($"{recoverValue}??? ???? ???????. ??????? : {calcValue}");
            RecoverResultData resultData = RecoverResultData.Create(giver, recoverValue, Value);
            OnRecover?.Invoke(resultData);
        }


    }
}