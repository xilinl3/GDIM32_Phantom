using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Xinlin Li
public class Cow : AnimalInstance
{
    public SOAnimalDefinition cow;
    private string cowname;
    private int cowvalue;
    private string cowtype;
    private Sprite cowicon;
    private int cowadultGrwothValue;
    private List<FoodType> cowpreferedFood;
    private int coweight;
    // Start is called before the first frame update
    public void getset()
    {
        cowname = cow.GetName();
        cowvalue = cow.GetSellValue();
        cowtype = "cow";
        cowicon = cow.GetIcon();
        cowadultGrwothValue = cow.GetAdultGrowthValue();
        cowpreferedFood = cow.GetPreferedFood();
        coweight = cow.GetWeight();
    }
    void Start()
    {
        getset();
        print(cowname);
        print(cowvalue);
        print(cowtype);
        print(cowadultGrwothValue);
        print(coweight);
        for (int i = 0; i < cowpreferedFood.Count; i++)
        {
            print(cowpreferedFood[i]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
