using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSystem : MonoBehaviour
{
    [SerializeField] private Camera characterCamera;
    [SerializeField] private Transform slot;
    private PickableItem pickedItem;

    // Update is called once per frame
    void Update()
    {
        var ray = characterCamera.ScreenPointToRay(Input.mousePosition) ;
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        if (Input.GetButtonDown("Fire1"))
        {
            if(pickedItem)
            {
                DropItem(pickedItem);
            }
            else
            {
                if (Physics.Raycast(ray, out hit, 5f))
                {
                    var pickable = hit.transform.GetComponent<PickableItem>();

                    if(pickable)
                    {
                        PickItem(pickable);
                    }
                }
            }
        }
    }

    private void PickItem(PickableItem item)
    {
        pickedItem = item;

        item.Rb.isKinematic = true;
        item.Rb.velocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;

        item.transform.SetParent(slot);

        item.transform.localPosition = Vector3.zero;
        item.transform.localEulerAngles = Vector3.zero;
    }

    private void DropItem(PickableItem item)
    {
        pickedItem = null;
        item.transform.SetParent(null);
        item.Rb.isKinematic = false;
        item.Rb.AddForce(item.transform.forward * 2, ForceMode.VelocityChange);
    }
}
