using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise2_2 : MonoBehaviour
{
    public bool Refresh = false;
    public bool CustomEnabled;
    public string EntityType;
    public float Hp;

    // Start is called before the first frame update
    void Start()
    {
        Refresh = false;
        Debug.Log($"I am {EntityType}! My HP is {Hp}");
    }

    bool isChanged;
    string entityType;
    float hp;

    // Update is called once per frame
    void Update()
    {
        if(CustomEnabled)
        {
            if(entityType!=EntityType)
            {
                entityType = EntityType;
                isChanged = true;
            }
            else if(hp!=Hp)
            {
                hp=Hp;
                isChanged=true;
            }
            if(isChanged)
            {
                if(EntityType == "") EntityType = "Undefined";
                isChanged = false;
            }
        }
        else
        {
            if(EntityType == "Player")
            {
                Hp = 50;
            }
            else if(EntityType == "Enemy")
            {
                Hp = 10;
            }
            else
            {
                EntityType = "Wrong";
                Hp = 0;
            }
        }
        if(Refresh)
        {
            Refresh = false;
            Debug.Log($"I am {EntityType}! My HP is {Hp}");
        }
    }
}
