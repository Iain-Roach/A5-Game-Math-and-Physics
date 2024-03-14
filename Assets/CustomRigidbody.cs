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
                transformedVertices[i] = TransformVertex(v, rotation);
            }
        }

        transformUpdateRequired = false;
        return transformedVertices;
    }

    private Vector2 TransformVertex(Vector2 position, float angle)
    {
        return new Vector2(Mathf.Cos(angle) * position.x - Mathf.Sin(angle) * position.y + this.position.x,
            Mathf.Sin(angle) * position.x + Mathf.Cos(angle) * position.y + this.position.y);
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
        transformUpdateRequired = true;
    }
}
