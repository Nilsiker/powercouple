using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    float satiety = 5;

    public float Ingest(){
        return satiety;
    }
}
