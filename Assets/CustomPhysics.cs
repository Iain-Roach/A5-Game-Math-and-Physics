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
            rb.Rotate(Mathf.PI / 2f);
            // rb.Move(new Vector2(1.0f * Time.deltaTime, 0));
        }
    }
}
