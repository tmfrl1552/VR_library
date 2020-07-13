using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using Valve.VR.Extras;


public class laserinput : MonoBehaviour
{
    public static GameObject currentObject;
    int currentID;
    void Start()
    {
        currentObject = null;
        currentID = 0;
    }
    private void Update()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 100.0f);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            int id = hit.collider.gameObject.GetInstanceID();

            if (currentID != id)
            {
                currentID = id;
                currentObject = hit.collider.gameObject;

                string name = currentObject.name;
                if (name == "next")
                {
                    Debug.Log("hit next");
                }
            }
        }
    }
}

