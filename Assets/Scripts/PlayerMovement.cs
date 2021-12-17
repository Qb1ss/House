using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] LocationsToMove locationsToMove;

    void Start()
    {
        GameObject.FindObjectOfType<LocationsToMove>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                if (hit.transform != null)
                {
                    if (hit.transform.gameObject.name == "MainDoor")
                    {
                        locationsToMove.MoveToNextLocation();
                        locationsToMove.MoveToNextLocation(3f);
                    }
                }
        }
    }
}
