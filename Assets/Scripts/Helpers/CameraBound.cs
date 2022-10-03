using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public class CameraBound
    {
        private BoundType boundType;
        private Vector3 coords;

        public BoundType BoundType => boundType;
        public Vector3 Coords => coords;

        public CameraBound(BoundType boundType, Vector3 coords)
        {
            this.boundType = boundType;
            this.coords = coords;
        }
    }
}