using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{

    text Text;
    public GameObject Count;

    private Text levelText;
    public Slider slider;
    public static float strength;
    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<text>();
        slider = GetComponent<Slider>();
        strength = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Count.GetComponent<Text>().text = "" + Boss.count + "  health : " + MoveInCircle.health;
        setExpirenceBarSize(strength);
    }

    private void setExpirenceBarSize(float strength)
    {
        //strenght value will be code from here should only varry from 0 to 1
        slider.value = strength;
    }

    private void setLevelNumber(int levelNumber)
    {
        //levelText.text = "Level " + (levelNumber + 1);
    }


}
