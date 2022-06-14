using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceSetter : MonoBehaviour
{
    public int price;
    
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponentInChildren<Text>().text = price.ToString();
    }
}
