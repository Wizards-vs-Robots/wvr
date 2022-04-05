using UnityEngine;

namespace Fighting
{
    public static class SpellUtil
    {
        public static float CalculateAngle(Vector2 dir)
        {
            return Vector3.Angle(Vector3.right * (dir.y < 0 ? -1 : 1), dir) + (dir.y < 0 ? -180 : 0);
        }
    }
}