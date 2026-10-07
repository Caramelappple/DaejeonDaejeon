using UnityEngine;

namespace _TYU.Scripts.Interface
{
    public interface IMovable
    {
        void Push(Vector2 dir, float pow, ForceMode forceMode);
    }
}