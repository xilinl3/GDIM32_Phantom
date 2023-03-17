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
    private List<GameObject> foodsInRange = new List<GameObject>();

    public override void InitialSetting()
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
            if (!foodsInRange.Contains(g3)) // 如果这个食物不在列表中，就加入列表
            {
                foodsInRange.Add(g3);
            }
        }

        if (foodsInRange.Count > 0) // 如果有食物在列表中，就找到最近的食物去吃
        {
            float minDistance = float.MaxValue;
            GameObject nearestFood = null;

            foreach (GameObject food in foodsInRange)
            {
                float comparedistance = Vector3.Distance(transform.position, food.transform.position);
                if (comparedistance < maxfooddistance && comparedistance < minDistance)
                {
                    minDistance = comparedistance;
                    nearestFood = food;
                }
            }

            if (nearestFood != null)
            {
                resultpos = nearestFood.transform.position;
                mAnimator.SetBool("isWalking", true);
                agent.SetDestination(resultpos);
            }
        }
        else // 如果没有食物在列表中，就停止移动
        {
            mAnimator.SetBool("isWalking", false);
            agent.ResetPath();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coweat"))
        {
            mAnimator.SetBool("isWalking", false);
            mAnimator.SetBool("isEating", true);
            FoodBase food = other.gameObject.GetComponent<FoodBase>();
            if (food != null)
            {
                hungry += food.hungerValue;
            }
            foodsInRange.Remove(other.gameObject);

            // Check if the game object has been destroyed before trying to destroy it
            if (other.gameObject != null)
            {
                Destroy(other.gameObject,3f);
                StartCoroutine(StopEatingAnimation(3f));
            }
        }
    }

    private IEnumerator StopEatingAnimation(float delay)
    {
        yield return new WaitForSeconds(delay);
        mAnimator.SetBool("isEating", false);
    }


    // Start is called before the first frame update
    void Start()
    {
        InitialSetting();


    }

    // Update is called once per frame
    void Update()
    {
        gethungry();
        CheckHunger();
        if (hungry < 10)
        {
            findnearestfood(foodtag);
        }

    }
}

