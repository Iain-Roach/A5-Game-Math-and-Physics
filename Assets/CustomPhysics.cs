using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPhysics : MonoBehaviour
{
    [SerializeField] private GameObject square;
    [SerializeField] private GameObject ground;
    List<GameObject> objList = new List<GameObject>();
    List<CollisionManifold> contactList = new List<CollisionManifold>();

    [SerializeField]
    private Vector2 gravity = new Vector2(0.0f, -9.81f);

    private void Awake()
    {


        objList.Add(Instantiate(square, new Vector3(4, -4.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(square, new Vector3(0f, 2f, 0), Quaternion.identity));
        objList.Add(Instantiate(square, new Vector3(4f, 4.0f, 0), Quaternion.Euler(new Vector3(0, 0, 0))));
        objList.Add(Instantiate(ground, new Vector3(.25f, 0.0f, 0), Quaternion.Euler(new Vector3(0, 0, 45))));
        objList[3].GetComponent<CustomRigidbody>().rotation = 45f;

        // Grond grond grond it just works :p
        objList.Add(Instantiate(ground, new Vector3(0f, -5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(1f, -5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(2f, -5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(3f, -5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(4f, -5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(5f, -5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(6f, -5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(7f, -5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(8f, -5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(9f, -5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-1f, -5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-2f, -5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-3f, -5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-4f, -5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-5f, -5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-6f, -5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-7f, -5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-8f, -5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-9f, -5.0f, 0), Quaternion.identity));



        // wall
        objList.Add(Instantiate(ground, new Vector3(-9f, -4.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-9f, -3.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-9f, -2.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-9f, -1.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-9f, 0.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-9f, 1.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-9f, 2.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-9f, 3.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-9f, 4.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-9f, 5.0f, 0), Quaternion.identity));

        objList.Add(Instantiate(ground, new Vector3(9f, -4.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(9f, -3.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(9f, -2.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(9f, -1.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(9f, 0.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(9f, 1.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(9f, 2.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(9f, 3.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(9f, 4.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(9f, 5.0f, 0), Quaternion.identity));

        // ceiling
        objList.Add(Instantiate(ground, new Vector3(1f, 5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(2f, 5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(3f, 5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(4f, 5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(5f, 5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(6f, 5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(7f, 5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(8f, 5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(9f, 5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-1f, 5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-2f, 5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-3f, 5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-4f, 5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-5f, 5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-6f, 5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-7f, 5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(-8f, 5.0f, 0), Quaternion.identity));
        objList.Add(Instantiate(ground, new Vector3(0f, 5.0f, 0), Quaternion.identity));



        

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

            //if (i == 0)
            //rb.AddForce(new Vector2(0.0f, -9.0f));
            //rb.Move(new Vector2(0, -2.0f * time));
            
            rb.Step(time, gravity);
        }

        contactList.Clear();

        for (int i = 0; i < objList.Count - 1; i++)
        {
            CustomRigidbody rba = objList[i].GetComponent<CustomRigidbody>();
            for (int j = i + 1; j < objList.Count; j++)
            {
                CustomRigidbody rbb = objList[j].GetComponent<CustomRigidbody>();

                if(rba.isStatic && rbb.isStatic)
                {
                    continue;
                }


                if (Collide(rba, rbb, out Vector2 normal, out float depth))
                {

                    if(rba.isStatic)
                    {
                        rbb.Move(normal * depth);
                    }
                    else if(rbb.isStatic)
                    {
                        rba.Move(-normal * depth);
                    }
                    else
                    {
                        rba.Move(-normal * depth / 2f);
                        rbb.Move(normal * depth / 2f);
                    }

                    CollisionDetection.FindContactPoints(rba.GetTransformedVertices(), rbb.GetTransformedVertices(), out Vector2 contact1, out Vector2 contact2, out int contactCount);
                    CollisionManifold contact = new CollisionManifold(rba, rbb, normal, depth, contact1, contact2, contactCount);
                    contactList.Add(contact);
                    
                }
            }
        }

        for(int i =0; i< contactList.Count; i++)
        {
            CollisionManifold contact = contactList[i];
            ResolveCollisionWithRotation(in contact);
        }


    }

    public void ResolveCollision(in CollisionManifold contact)
    {
        CustomRigidbody bodyA = contact.bodyA;
        CustomRigidbody bodyB = contact.bodyB;
        Vector2 normal = contact.normal;
        float depth = contact.depth;

        Vector2 relativeVelocity = bodyB.LinearVelocity - bodyA.LinearVelocity;

        if(Vector2.Dot(relativeVelocity, normal) > 0f)
        {
            return;
        }

        float e = Mathf.Min(bodyA.restitution, bodyB.restitution);
        
        float j = -(1f + e) * Vector2.Dot(relativeVelocity, normal);
        j /= (bodyA.invMass) + (bodyB.invMass);

        Vector2 impulse = j * normal;

        bodyA.LinearVelocity -= impulse * bodyA.invMass;
        bodyB.LinearVelocity += impulse * bodyB.invMass;
    }

    public void ResolveCollisionWithRotation(in CollisionManifold contact)
    {
        CustomRigidbody bodyA = contact.bodyA;
        CustomRigidbody bodyB = contact.bodyB;
        Vector2 normal = contact.normal;

        Vector2 contact1 = contact.contact1;
        Vector2 contact2 = contact.contact2;
        int contactCount = contact.contactCount;

        float e = Mathf.Min(bodyA.restitution, bodyB.restitution);

        Vector2[] contactList = new Vector2[] { contact1, contact2 };
        Vector2[] impulseList = new Vector2[2];
        Vector2[] raList = new Vector2[2];
        Vector2[] rbList = new Vector2[2];

        for(int i = 0; i < contactCount; i ++)
        {
            Vector2 ra = contactList[i] - bodyA.Position;
            Vector2 rb = contactList[i] - bodyB.Position;

            raList[i] = ra;
            rbList[i] = rb;

            Vector2 raPerp = new Vector2(-ra.y, ra.x);
            Vector2 rbPerp = new Vector2(-rb.y, rb.x);

            Vector2 angularLinearVelocityA = raPerp * bodyA.RotationalVelocity;
            Vector2 angularLinearVelocityB = rbPerp * bodyB.RotationalVelocity;

            Vector2 relativeVelocity = (bodyB.LinearVelocity + angularLinearVelocityB) - 
                (bodyA.LinearVelocity + angularLinearVelocityA);

            float contactVelocityMag = (Vector2.Dot(relativeVelocity, normal));
            if  (contactVelocityMag > 0f)
            {
                continue;
            }

            float raPerpDotN = Vector2.Dot(raPerp, normal);
            float rbPerpDotN = Vector2.Dot(rbPerp, normal);

            float denom = bodyA.invMass + bodyB.invMass + 
                ((raPerpDotN * raPerpDotN) * bodyA.invInertia) + 
                ((rbPerpDotN * rbPerpDotN) * bodyB.invInertia);

            float j = -(1f + e) * contactVelocityMag;
            j /= denom;
            j /= (float)contactCount;

            Vector2 impulse = j * normal;
            impulseList[i] = impulse;
        }

        for(int i = 0; i < contactCount; i++)
        {
            Vector2 impulse = impulseList[i];
            Vector2 ra = raList[i];
            Vector2 rb = raList[i];

            bodyA.LinearVelocity -= impulse * bodyA.invMass;
            bodyA.RotationalVelocity -= (Cross(ra, impulse) * bodyA.invInertia);
            bodyB.LinearVelocity += impulse * bodyB.invMass;
            bodyB.RotationalVelocity += (Cross(rb, impulse) * bodyB.invInertia);
        }
    }

    public float Cross(Vector2 a, Vector2 b)
    {
        return a.x * b.y - a.y * b.x;
    }

    public bool Collide(CustomRigidbody bodyA, CustomRigidbody bodyB, out Vector2 normal, out float depth)
    {
        normal = Vector2.zero;
        depth = 0f;

        return CollisionDetection.Intersect(bodyA.GetTransformedVertices(), bodyB.GetTransformedVertices(), out normal, out depth);
    }
}

public struct CollisionManifold
{
    public CustomRigidbody bodyA;
    public CustomRigidbody bodyB;
    public Vector2 normal;
    public float depth;
    public Vector2 contact1;
    public Vector2 contact2;
    public int contactCount;

    public CollisionManifold(CustomRigidbody bodyA, CustomRigidbody bodyB, Vector2 normal, float depth, Vector2 contact1, Vector2 contact2, int contactCount)
    {
        this.bodyA = bodyA;
        this.bodyB = bodyB;
        this.normal = normal;
        this.depth = depth;
        this.contact1 = contact1;
        this.contact2 = contact2;
        this.contactCount = contactCount;
    }
}