using System;

namespace Assets.Scripts.Interaction
{
    public interface IInputService
    {
        event Action OnClickPerformed;
    }
}