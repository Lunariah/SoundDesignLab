using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float reach;

    //[HideInInspector]
    public byte progress = 0;

    private Ray ray;
    private RaycastHit hit;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            Debug.Log("Casting");
            if (Physics.Raycast(ray, out hit, reach))
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.CompareTag("Specimen"))
                {
                    Destroy(hit.transform.gameObject);
                    progress++;
                }
            }
        }
    }
}