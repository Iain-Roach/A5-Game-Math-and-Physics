using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBoxCollider : MonoBehaviour
{
    //public Vector2 size;
    //public float rotation;

    //public Vector2[] GetCorners()
    //{
    //    Vector2 halfSize = size / 2;
    //    Vector2[] corners = new Vector2[4];
    //    corners[0] = RotatePoint(halfSize, rotation);
    //    corners[1] = RotatePoint(new Vector2(-halfSize.x, halfSize.y), rotation);
    //    corners[2] = RotatePoint(-halfSize, rotation);
    //    corners[3] = RotatePoint(new Vector2(halfSize.x, -halfSize.y), rotation);
    //    return corners;
    //}

    //private Vector2 RotatePoint(Vector2 point, float angle)
    //{
    //    float rad = angle * Mathf.Deg2Rad;
    //    float s = Mathf.Sin(rad);
    //    float c = Mathf.Cos(rad);
    //    return new Vector2(
    //        point.x * c - point.y * s,
    //        point.y * c + point.x * s
    //    );
    //}


    //// Separating Axis Theorem
    //public bool isColliding(CustomBoxCollider other)
    //{
    //    Vector2[] axes = new Vector2[4];
    //    axes[0] = RotatePoint(Vector2.right, rotation);
    //    axes[1] = RotatePoint(Vector2.up, rotation);
    //    axes[2] = RotatePoint(Vector2.right, other.rotation);
    //    axes[3] = RotatePoint(Vector2.up, other.rotation);

    //    foreach (Vector2 axis in axes)
    //    {
    //        if (!OverlapOnAxis(this, other, axis))
    //        {
    //            return false;
    //        }
    //        else
    //        {
    //            HandleCollision(this, other, axis);
    //        }
    //    }



    //    return true;

    //}

    //private bool OverlapOnAxis(CustomBoxCollider a, CustomBoxCollider b, Vector2 axis)
    //{
    //    // Project the corners of the boxes onto the axis
    //    float[] aProject = ProjectCornersOnAxis(a.GetCorners(), axis);
    //    float[] bProject = ProjectCornersOnAxis(b.GetCorners(), axis);

    //    // Check for overlap
    //    return aProject[0] < bProject[1] && aProject[1] > bProject[0];
    //}

    //// Project the corners of a box onto an axis
    //private float[] ProjectCornersOnAxis(Vector2[] corners, Vector2 axis)
    //{
    //    float min = Vector2.Dot(axis, corners[0]);
    //    float max = min;
    //    for (int i = 1; i < corners.Length; i++)
    //    {
    //        float p = Vector2.Dot(axis, corners[i]);
    //        if (p < min)
    //        {
    //            min = p;
    //        }
    //        else if (p > max)
    //        {
    //            max = p;
    //        }
    //    }
    //    return new float[] { min, max };
    //}

    //// Handle a collision between two boxes
    //private void HandleCollision(CustomBoxCollider a, CustomBoxCollider b, Vector2 axis)
    //{
    //    CustomRigidbody aRb = a.GetComponent<CustomRigidbody>();
    //    CustomRigidbody bRb = b.GetComponent<CustomRigidbody>();

    //    if (aRb != null && bRb != null)
    //    {
    //        // Both objects are movable
    //        Vector2 relativeVelocity = aRb.velocity - bRb.velocity;
    //        float impulse = Vector2.Dot(relativeVelocity, axis) / (1 / aRb.mass + 1 / bRb.mass);
    //        aRb.ApplyForce(-axis * impulse / Time.deltaTime);
    //        bRb.ApplyForce(axis * impulse / Time.deltaTime);
    //    }
    //    else if (aRb != null)
    //    {
    //        // Only object A is movable
    //        aRb.ApplyForce(-2 * Vector2.Dot(aRb.velocity, axis) * axis / Time.deltaTime);
    //    }
    //    else if (bRb != null)
    //    {
    //        // Only object B is movable
    //        bRb.ApplyForce(-2 * Vector2.Dot(bRb.velocity, axis) * axis / Time.deltaTime);
    //    }
    //}

    //private void Update()
    //{
    //    // Get the corners of the box
    //    Vector2[] corners = GetCorners();

    //    // Draw lines between the corners
    //    Debug.DrawLine(corners[0], corners[1], Color.red);
    //    Debug.DrawLine(corners[1], corners[2], Color.red);
    //    Debug.DrawLine(corners[2], corners[3], Color.red);
    //    Debug.DrawLine(corners[3], corners[0], Color.red);
    //}
}

