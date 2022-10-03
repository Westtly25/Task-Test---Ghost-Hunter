using UnityEngine;
using Zenject;

public class GhostPool : MonoPoolableMemoryPool<Vector3, IMemoryPool, Ghost>
{
}