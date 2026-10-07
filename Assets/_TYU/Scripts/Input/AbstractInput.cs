using System;
using UnityEngine;

public abstract class AbstractInput : MonoBehaviour
{
    public event Action<Vector2> OnMovePressed;
    public event Action OnAttackPressed;
    public event Action OnDashPressed;
    
    protected Controls _control;

    protected void MoveInvoke(Vector2 dir) => OnMovePressed?.Invoke(dir);
    protected void AttackInvoke() => OnAttackPressed?.Invoke();
    protected void DashInvoke() => OnDashPressed?.Invoke();
}