using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Puzzle : MonoBehaviour
{
    Color colorG = Color.green;
    Color def = Color.gray;

    public Image[] indicators;
    public bool isOne = false;
    public bool isTwo = false;
    public bool isThree = false;
    public bool isFour = false;
    public bool isFive = false;
    public bool isSix = false;
    public bool isSeven = false;
    public bool isEight = false;
    void Start()
    {
        
    }

    void Update()
    {
        CheckDone();
        CheckLights();
        CheckLightsDef();
    }
    public void One()
    {
        if (!isTwo && !isThree && !isFour && !isFive && !isSix && !isSeven && !isEight)
        {
            isOne = true;
        }
        else
        {
            Deactive();
        }
            
    }
    public void Two()
    {
        if (isOne && !isThree && !isFour && !isFive && !isSix && !isSeven && !isEight)
        {
            isTwo = true;
        }
        else
        {
            Deactive();
        }
    }
    public void Three()
    {
        if (isOne && isTwo && !isFour && !isFive && !isSix && !isSeven && !isEight)
        {
            isThree = true;
        }
        else
        {
            Deactive();
        }
    }
    public void Four()
    {
        if (isOne && isTwo && isThree && !isFive && !isSix && !isSeven && !isEight)
        {
            isFour = true;
        }
        else
        {
            Deactive();
        }
    }
    public void Five()
    {
        if (isOne && isTwo && isThree && isFour && !isSix && !isSeven && !isEight)
        {
            isFive = true;
        }
        else
        {
            Deactive();
        }
    }
    public void Six()
    {
        if (isOne && isTwo && isThree && isFour && isFive && !isSeven && !isEight)
        {
            isSix = true;
        }
        else
        {
            Deactive();
        }
    }
    public void Seven()
    {
        if (isOne && isTwo && isThree && isFour && isFive && isSix && !isEight)
        {
            isSeven = true;
        }
        else
        {
            Deactive();
        }
    }
    public void Eight()
    {
        if (isOne && isTwo && isThree && isFour && isFive && isSix && isSeven)
        {
            isEight = true;
        }
        else
        {
            Deactive();
        }
    }
    public void Deactive()
    {
        isOne = false;
        isTwo = false;
        isThree = false;
        isFour = false;
        isFive = false;
        isSix = false;
        isSeven = false;
        isEight = false;
    }
    public void CheckDone()
    {
        if(isOne && isTwo && isThree && isFour && isFive && isSix && isSeven && isEight)
        {
            SceneManager.LoadScene("asdas");//asdlaskdlaskdsk
        }
    }
    public void CheckLights()
    {
        if (isOne)
            indicators[0].color = colorG;
        if (isTwo)
            indicators[1].color = colorG;
        if (isThree)
            indicators[2].color = colorG;
        if (isFour)
            indicators[3].color = colorG;
        if (isFive)
            indicators[4].color = colorG;
        if (isSix)
            indicators[5].color = colorG;
        if (isSeven)
            indicators[6].color = colorG;
        if (isEight)
            indicators[7].color = colorG;
    }
    public void CheckLightsDef()
    {
        if (!isOne)
            indicators[0].color = def;
        if (!isTwo)
            indicators[1].color = def;
        if (!isThree)
            indicators[2].color = def;
        if (!isFour)
            indicators[3].color = def;
        if (!isFive)
            indicators[4].color = def;
        if (!isSix)
            indicators[5].color = def;
        if (!isSeven)
            indicators[6].color = def;
        if (!isEight)
            indicators[7].color = def;
    }
}
