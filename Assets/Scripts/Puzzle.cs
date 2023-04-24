using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Puzzle : MonoBehaviour
{
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
}
