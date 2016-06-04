using UnityEngine;


    public static class Formulas
    {

        /// <summary>
        /// Projects a point in a plane
        /// </summary>
        /// <param name="point"></param>
        /// <param name="plane"></param>
        /// <returns></returns>
        public static Vector3 ProjectPointOnPlane(Vector3 point, Plane plane)
        {

            float distance = plane.GetDistanceToPoint(point);
            return point - (plane.normal * distance);
        }

    /// <summary>
    /// returns positionOrigin - positionForOffset
    /// </summary>
    /// <param name="positionOrigin"></param>
    /// <param name="positionForOffset"></param>
    /// <returns></returns>
    public static Vector3 Offset(Vector3 positionOrigin, Vector3 positionForOffset )
    {

        return positionOrigin - positionForOffset;

    }




}



