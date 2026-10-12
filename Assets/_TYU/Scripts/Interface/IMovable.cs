using UnityEngine;

namespace _TYU.Scripts.Interface
{
    public interface IMovable
    {
        void Push(Vector3 dir, float pow, ForceMode forceMode);
    }
}