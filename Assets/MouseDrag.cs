using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{



    private TargetJoint2D joint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0))
        {
            Collider2D colObj = Physics2D.OverlapPoint(worldPos, ~LayerMask.NameToLayer("Draggable"));
            if (!colObj) return;

            Rigidbody2D rb = colObj.attachedRigidbody;
            if (!rb) return;

            joint = rb.gameObject.AddComponent<TargetJoint2D>();
            joint.dampingRatio = 1.0f;
            joint.frequency = 2.0f;

            joint.anchor = joint.transform.InverseTransformPoint(worldPos);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Destroy(joint);
            joint = null;
            return;
        }

        if(joint)
        {
            joint.target = worldPos;
        }
    }
}
