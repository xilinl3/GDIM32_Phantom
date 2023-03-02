using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class cow : AnimalBase
{
    private NavMeshAgent agent;
    private Animator mAnimator;
    private Vector3 temppos;
    void Initialsetting()
    {
        health = 100;
        hungry = 50;
        hungryminuseachsecond = 10;
        agent = this.GetComponent<NavMeshAgent>();
        mAnimator = GetComponent<Animator>();
    }

    public void getobjectpositon()
    {
        GameObject[] gs = GameObject.FindGameObjectsWithTag("coweat");
        foreach (GameObject g3 in gs)
        {
            temppos = g3.transform.position;
            UnityEngine.Debug.Log(temppos);
            mAnimator.SetBool("isWalking", true);
            agent.SetDestination(temppos);
        }
        
        //List<GameObject> gs2 = GameObject.FindGameObjectsWithTag("coweat").ToList();

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
        if (hungry < 10)
        {
            getobjectpositon();
        }
        
    }
}
