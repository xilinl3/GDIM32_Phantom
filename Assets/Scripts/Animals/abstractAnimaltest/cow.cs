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
    //public Transform putcowhere;
    private NavMeshAgent agent;
    private Animator mAnimator;
    private Vector3 temppos;
    private Vector3 resultpos;
    
    void Initialsetting()
    {
        health = 100;
        hungry = 20;
        hungryminuseachsecond = 0.5f;
        agent = this.GetComponent<NavMeshAgent>();
        mAnimator = GetComponent<Animator>();
        foodtag = "coweat";
    }

    public void findnearestfood(string ftag)
    {
        GameObject[] gs = GameObject.FindGameObjectsWithTag(ftag);
        foreach (GameObject g3 in gs)
        {
            temppos = g3.transform.position;
            UnityEngine.Debug.Log(temppos); 
            float comparedistance = Vector3.Distance(transform.position, temppos);
            if (comparedistance < fooddistance)
            {
                fooddistance = comparedistance;
                resultpos = temppos;
            }
        }
        mAnimator.SetBool("isWalking", true);
        agent.SetDestination(resultpos);
    }

    void eatfood()
    {
        
    }

    public void generate()
    {
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
            findnearestfood(foodtag);
        }
        
    }
}
