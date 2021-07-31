using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorHealt : MonoBehaviour
{

    public Text scorText;
    public int scorValue;

    public Text healtText;
    public Slider healtSlider;
    public float healtValue;


    void Start()
    {
        scorText.text = scorValue.ToString();

        healtText.text = healtValue.ToString();
        healtSlider.value = healtValue;


    }

   
    
    public void ScorAdd(int scradd)
    {
        scorValue += scradd;
        scorText.text = scorValue.ToString();


    }

    public void ReduceHealt(float rdcHealt)
    {
        healtValue -= rdcHealt;
        healtSlider.value = healtValue;
        healtText.text = healtValue.ToString();


    }


}
