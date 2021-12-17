using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashClean : MonoBehaviour
{
    LocationsToMove locationsToMove;

    [SerializeField] public List<GameObject> trashes;

    bool isMoved = false;


    void Start()
    {
        locationsToMove = FindObjectOfType<LocationsToMove>();
    }


    void Update()
    {
        if (trashes.Count == 0 && !isMoved)
        {
            locationsToMove.PlayConfetti();
            locationsToMove.MoveToNextLocation(2f);
            isMoved = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                if (hit.transform != null)
                {
                    if (hit.transform.gameObject.tag == "Trash")
                    {
                        trashes.Remove(hit.transform.gameObject);
                        Destroy(hit.transform.gameObject);
                    }
                }
        }
    }
}
