using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollisionDetection
{
    //SAT :O
    public static bool Intersect(Vector2[] verticesA, Vector2[] verticesB, out Vector2 normal, out float depth)
    {
        normal = Vector2.zero;
        depth = float.MaxValue;

        for(int i = 0; i < verticesA.Length; i++)
        {
            Vector2 va = verticesA[i];
            Vector2 vb = verticesA[(i + 1) % verticesA.Length];

            Vector2 edge = vb - va;
            Vector2 axis = new Vector2(-edge.y, edge.x);

            // normalize axis
            axis = axis.normalized;

            ProjectVertices(verticesA, axis, out float minA, out float maxA);
            ProjectVertices(verticesB, axis, out float minB, out float maxB);

            if(minA >= maxB || minB >= maxA)
            {
                return false;
            }

            // store minimum depth to resolve collision
            float axisDepth = Mathf.Min(maxB - minA, maxA - minB);

            if(axisDepth < depth)
            {
                depth = axisDepth;
                normal = axis;
            }
        }

        for (int i = 0; i < verticesB.Length; i++)
        {
            Vector2 va = verticesB[i];
            Vector2 vb = verticesB[(i + 1) % verticesB.Length];

            Vector2 edge = vb - va;
            Vector2 axis = new Vector2(-edge.y, edge.x);

            axis = axis.normalized;

            ProjectVertices(verticesA, axis, out float minA, out float maxA);
            ProjectVertices(verticesB, axis, out float minB, out float maxB);

            if (minA >= maxB || minB >= maxA)
            {
                return false;
            }

            // store minimum depth to resolve collision
            float axisDepth = Mathf.Min(maxB - minA, maxA - minB);

            if (axisDepth < depth)
            {
                depth = axisDepth;
                normal = axis;
            }
        }

        //depth /= normal.magnitude;
        //normal = normal.normalized;


        Vector2 centerA = ArithmeticMean(verticesA);
        Vector2 centerB = ArithmeticMean(verticesB);

        Vector2 direction = centerB - centerA;

        if(Vector2.Dot(direction, normal) < 0f)
        {
            normal = -normal;
        }

        return true;
    }

    private static Vector2 ArithmeticMean(Vector2[] vertices)
    {
        float sumX = 0f;
        float sumY = 0f;
        for(int i = 0; i < vertices.Length; i++)
        {
            Vector2 v = vertices[i];
            sumX += v.x;
            sumY += v.y;
        }

        return new Vector2(sumX / (float)vertices.Length, sumY / (float)vertices.Length);
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
