using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPhysics : MonoBehaviour
{
    [SerializeField] private GameObject square;
    List<GameObject> objList = new List<GameObject>();

    [SerializeField]
    private Vector2 gravity = new Vector2(0.0f, -9.81f);

    private void Awake()
    {
        objList.Add(Instantiate(square, new Vector3(0, -4.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(square, new Vector3(0f, 0f, 0), Quaternion.identity));
        objList.Add(Instantiate(square, new Vector3(0f, 4.0f, 0), Quaternion.Euler(new Vector3(0, 0, 0))));
        //objList[2].GetComponent<CustomRigidbody>().rotation = 45f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //for (int i = 0; i < objList.Count; i++)
        //{
        //    CustomRigidbody rb = objList[i].GetComponent<CustomRigidbody>();
        //    //rb.Rotate(Mathf.PI / 2f);

        //    if(i == 1)
        //    rb.Move(new Vector2(0, -2.0f * Time.deltaTime));
        //}

        //for(int i = 0; i < objList.Count - 1; i++)
        //{
        //    CustomRigidbody rba = objList[i].GetComponent<CustomRigidbody>();
        //    for(int j = i + 1; j < objList.Count; j++)
        //    {
        //        CustomRigidbody rbb = objList[j].GetComponent<CustomRigidbody>();

        //        if (CollisionDetection.Intersect(
        //            rba.GetTransformedVertices(), 
        //            rbb.GetTransformedVertices(),
        //            out Vector2 normal, out float depth))
        //        {
        //            Debug.LogWarning("Collision Detected");
        //            rba.Move(-normal * depth / 2f);
        //            rbb.Move(normal * depth / 2f);
        //        }



        //    }
        //}

        Step(Time.deltaTime);
    }



    public void Step(float time)
    {
        for (int i = 0; i < objList.Count; i++)
        {
            CustomRigidbody rb = objList[i].GetComponent<CustomRigidbody>();

            if (i == 0)
                rb.AddForce(new Vector2(0.0f, 9.0f));
            //rb.Move(new Vector2(0, -2.0f * time));
            
            rb.Step(time);
        }


        for (int i = 0; i < objList.Count - 1; i++)
        {
            CustomRigidbody rba = objList[i].GetComponent<CustomRigidbody>();
            for (int j = i + 1; j < objList.Count; j++)
            {
                CustomRigidbody rbb = objList[j].GetComponent<CustomRigidbody>();

                if (Collide(rba, rbb, out Vector2 normal, out float depth))
                {
                    rba.Move(-normal * depth / 2f);
                    rbb.Move(normal * depth / 2f);

                    ResolveCollision(rba, rbb, normal, depth);
                }
            }
        }
    }

    public void ResolveCollision(CustomRigidbody bodyA, CustomRigidbody bodyB, Vector2 normal, float depth)
    {
        float e = Mathf.Min(bodyA.restitution, bodyB.restitution);
        Vector2 relativeVelocity = bodyB.LinearVelocity - bodyA.LinearVelocity;
        float j = -(1f + e) * Vector2.Dot(relativeVelocity, normal);
        j /= (1f / bodyA.mass) + (1f / bodyB.mass);
        bodyA.LinearVelocity -= j / bodyA.mass * normal;
        bodyB.LinearVelocity += j / bodyB.mass * normal;
    }

    public bool Collide(CustomRigidbody bodyA, CustomRigidbody bodyB, out Vector2 normal, out float depth)
    {
        normal = Vector2.zero;
        depth = 0f;

        return CollisionDetection.Intersect(bodyA.GetTransformedVertices(), bodyB.GetTransformedVertices(), out normal, out depth);
    }
}
