using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollisionDetection
{
    public static bool Intersect(Vector2[] verticesA, Vector2[] verticesB)
    {
        for(int i = 0; i < verticesA.Length; i++)
        {
            Vector2 va = verticesA[i];
            Vector2 vb = verticesA[(i + 1) % verticesA.Length];

            Vector2 edge = vb - va;
            Vector2 axis = new Vector2(-edge.y, edge.x);

            ProjectVertices(verticesA, axis, out float minA, out float maxA);
            ProjectVertices(verticesB, axis, out float minB, out float maxB);

            if(minA >= maxB || minB >= maxA)
            {
                return false;
            }
        }

        for (int i = 0; i < verticesB.Length; i++)
        {
            Vector2 va = verticesB[i];
            Vector2 vb = verticesB[(i + 1) % verticesB.Length];

            Vector2 edge = vb - va;
            Vector2 axis = new Vector2(-edge.y, edge.x);

            ProjectVertices(verticesA, axis, out float minA, out float maxA);
            ProjectVertices(verticesB, axis, out float minB, out float maxB);

            if (minA >= maxB || minB >= maxA)
            {
                return false;
            }
        }




        return true;
    }

    private static void ProjectVertices(Vector2[] vertices, Vector2 axis, out float min, out float max)
    {
        min = float.MaxValue;
        max = float.MinValue;

        for(int i = 0; i < vertices.Length; i++)
        {
            Vector2 v = vertices[i];
            float proj = Vector2.Dot(v, axis);

            if (proj < min) { min = proj; }
            if (proj > max) { max = proj; }
        }
    }
}
