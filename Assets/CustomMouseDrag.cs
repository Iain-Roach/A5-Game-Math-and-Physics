using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMouseDrag : MonoBehaviour
{
    [SerializeField] CustomPhysics customPhysics;
    // Start is called before the first frame update
    private void Update()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
           
            for(int i = 0; i < customPhysics.objList.Count; i++)
            {
                CustomRigidbody rb = customPhysics.objList[i].GetComponent<CustomRigidbody>();

                if((rb.Position - new Vector2(worldPos.x, worldPos.y)).magnitude <= 5.0f)
                {
                    Debug.Log((rb.Position - new Vector2(worldPos.x, worldPos.y)).magnitude);
                    rb.AddForce((rb.Position - new Vector2(worldPos.x, worldPos.y)) * 100);
                }


            }
           
            
            // Check all objs in custom physics Object list, check to see if their position is within a specific distance
            // Addforce to all nonstatic objects within the distance away from the point.




        }
    }
}
