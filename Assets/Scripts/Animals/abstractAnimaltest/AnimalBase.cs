using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AnimalBase : MonoBehaviour
{
    public float health = 100;
    public float hungry = 100;
    public int hungryminuseachsecond = 1;
    public int child = 1;

    public virtual void Initialsetting()
    {
    }

    public virtual void getnew()
    { 
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
