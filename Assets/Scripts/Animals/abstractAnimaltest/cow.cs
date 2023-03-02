using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class cow : AnimalBase
{
    public Camera cam;
    public NavMeshAgent agent;
    void Initialsetting()
    {
        health = 100;
        hungry = 50;
        hungryminuseachsecond = 10;
    }
    // Start is called before the first frame update
    void Start()
    {
        Initialsetting();
    }

    // Update is called once per frame
    void Update()
    {
        gethungry();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
