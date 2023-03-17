using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AnimalBase : MonoBehaviour
{
    public float health = 100;
    public float hungry = 100;
    public float hungryminuseachsecond = 1;
    public int child = 1;
    public float maxfooddistance = 100;
    public string foodtag;

    public virtual void InitialSetting()
    {
    }

    public void CheckHunger()
    {
        if (hungry <= 0)
        {
            health -= 1f;
        }
    }

    public void gethungry()
    {
        if (hungry >= 0)
        {
            hungry -= hungryminuseachsecond * Time.deltaTime;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}