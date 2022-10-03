using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public static class CameraBoundsHandler
    {
        private static CameraBound[] bounds;

        static CameraBoundsHandler()
        {
            bounds = new CameraBound[]
            {
                new CameraBound(BoundType.LeftTop, Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0))),
                new CameraBound(BoundType.LeftBottom, Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0))),
                new CameraBound(BoundType.RightTop, Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0))),
                new CameraBound(BoundType.RightBottom, Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)))
            };
        }

        public static Vector3 GetBoundCoordByType(BoundType boundType)
        {
            for (int i = 0; i < bounds.Length; i++)
            {
                if (bounds[i].BoundType == boundType)
                {
                    return bounds[i].Coords;
                }
            }

            return Vector3.zero;
        }
    }
}