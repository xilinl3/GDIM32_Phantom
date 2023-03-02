using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class cow : AnimalBase
{
    public Transform putcowhere;
    private NavMeshAgent agent;
    private Animator mAnimator;
    private Vector3 temppos;
    private Vector3 resultpos;
    private float distance = 80;
    
    void Initialsetting()
    {
        health = 100;
        hungry = 20;
        hungryminuseachsecond = 10;
        agent = this.GetComponent<NavMeshAgent>();
        mAnimator = GetComponent<Animator>();   
    }

    public void getobjectpositon()
    {
        GameObject[] gs = GameObject.FindGameObjectsWithTag("coweat");
        GameObject food;
        foreach (GameObject g3 in gs)
        {
            temppos = g3.transform.position;
            UnityEngine.Debug.Log(temppos);
            //put cowhere in line37 if change class to scriptable 
            float comparedistance = Vector3.Distance(transform.position, temppos);
            if (comparedistance < distance)
            {
                distance = comparedistance;
                resultpos = temppos;
            }
        }
        mAnimator.SetBool("isWalking", true);
        agent.SetDestination(resultpos);

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
