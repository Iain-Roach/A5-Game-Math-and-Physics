using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPhysics : MonoBehaviour
{
    [SerializeField] private GameObject square;
    List<GameObject> objList = new List<GameObject>();

    private void Awake()
    {
        objList.Add(Instantiate(square, new Vector3(0, 0, 0), Quaternion.identity));
        objList.Add(Instantiate(square, new Vector3(0f, 1.5f, 0), Quaternion.identity));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < objList.Count; i++)
        {
            CustomRigidbody rb = objList[i].GetComponent<CustomRigidbody>();
            //rb.Rotate(Mathf.PI / 2f);
            
            if(i == 1)
            rb.Move(new Vector2(0, -2.0f * Time.deltaTime));
        }

        for(int i = 0; i < objList.Count - 1; i++)
        {
            CustomRigidbody rba = objList[i].GetComponent<CustomRigidbody>();
            for(int j = i + 1; j < objList.Count; j++)
            {
                CustomRigidbody rbb = objList[j].GetComponent<CustomRigidbody>();

                if (CollisionDetection.Intersect(
                    rba.GetTransformedVertices(), 
                    rbb.GetTransformedVertices(),
                    out Vector2 normal, out float depth))
                {
                    Debug.LogWarning("Collision Detected");
                    rba.Move(-normal * depth / 2f);
                    rbb.Move(normal * depth / 2f);
                }



            }
        }
    }
}
