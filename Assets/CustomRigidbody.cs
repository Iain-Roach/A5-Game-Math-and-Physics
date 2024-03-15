using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomRigidbody : MonoBehaviour
{
    private Vector2 position;
    private Vector2 linearVelocity;
    private float rotation;
    private float rotationalVelocity;

    public float density;
    public float mass;
    public float restitution;

    public bool isStatic;

    private Vector2[] vertices;
    private Vector2[] transformedVertices;
    private bool transformUpdateRequired;

    public Vector2 Position { get { return position; } }

    private void Awake()
    {
        // Initialize values
        position = transform.position;
        linearVelocity = Vector2.zero;
        rotation = 0;
        rotationalVelocity = 0;
        mass = 1;
        restitution = .5f;
        density = 2f;

        vertices = initVertices();
        transformedVertices = new Vector2[vertices.Length];

        transformUpdateRequired = true;
    }

    private Vector2[] initVertices()
    {
        var renderer = GetComponent<Renderer>();
        if (!renderer) return null;
        var bounds = renderer.bounds;

        Vector2[] vertices = new Vector2[4];
        vertices[0] = new Vector2(bounds.min.x, bounds.max.y);
        vertices[1] = new Vector2(bounds.max.x, bounds.max.y);
        vertices[2] = new Vector2(bounds.max.x, bounds.min.y);
        vertices[3] = new Vector2(bounds.min.x, bounds.min.y);

        return vertices;
    }

    // Gets the transformed vertices, if an update is required 
    public Vector2[] GetTransformedVertices()
    {
        if(transformUpdateRequired)
        {
            // using position and rotation of the custom rigidbody update the vertices
            for (int i = 0; i < vertices.Length; i++)
            {
                Vector2 v = vertices[i];
                transformedVertices[i] = TransformVertex(v, rotation + (i * 90 + 45));
            }
        }

        transformUpdateRequired = false;
        return transformedVertices;
    }

    private Vector2 TransformVertex(Vector2 vertex, float angle)
    {
        Debug.LogWarning(this.position.x);
        Debug.LogWarning(this.position.y);
        // d [sqrt(x^2 + y^2) = d] sin(theta)
        //return new Vector2((Mathf.Cos(Mathf.Deg2Rad * angle) * (vertex.x) - Mathf.Sin(Mathf.Deg2Rad * angle) * (vertex.y)) + this.position.x,
        //    (Mathf.Sin(Mathf.Deg2Rad * angle) * (vertex.x) + Mathf.Cos(Mathf.Deg2Rad * angle) * (vertex.y)) + this.position.y);


        return new Vector2(1 / Mathf.Sqrt(2.0f) * Mathf.Cos(Mathf.Deg2Rad * angle) + this.position.x, 1 / Mathf.Sqrt(2.0f) * Mathf.Sin(Mathf.Deg2Rad * angle) + this.position.y);
    }


    public void Move(Vector2 amount)
    {
        position += amount;
        transform.position = position;
        transformUpdateRequired = true;
    }

    public void MoveTo(Vector2 position)
    {
        this.position = position;
        transform.position = position;
        transformUpdateRequired = true;
    }
    
    public void Rotate(float amount)
    {
        this.rotation += amount;
        transform.Rotate(new Vector3(0, 0, 1), amount);
        transformUpdateRequired = true;
    }

    public void Update()
    {
        // Get the corners of the box
        //    Vector2[] corners = GetCorners();

        //    // Draw lines between the corners
        //    Debug.DrawLine(corners[0], corners[1], Color.red);
        //    Debug.DrawLine(corners[1], corners[2], Color.red);
        //    Debug.DrawLine(corners[2], corners[3], Color.red);
        //    Debug.DrawLine(corners[3], corners[0], Color.red);

        GetTransformedVertices();
        Debug.Log(transformedVertices[1]);
        Debug.DrawLine(transformedVertices[0], transformedVertices[1], Color.green);
        Debug.DrawLine(transformedVertices[1], transformedVertices[2], Color.green);
        Debug.DrawLine(transformedVertices[2], transformedVertices[3], Color.green);
        Debug.DrawLine(transformedVertices[3], transformedVertices[0], Color.green);
    }
}
