using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invest 
{
    private float pension =0f;
    private float ISA =0f;
    private float lifetimeISA = 0f;
    
    // Use this for initialization
  
    public float getISA()
    {
        return ISA;
    }

    public float getLISA()
    {
        return lifetimeISA;
    }

    public float getPension()
    {
        return pension;
    }

    // Update is called once per frame


    // Setters for data fields
    public void addToPension()
    {
        pension += 1;
    }
    public int removeFromISA()
    {
        if (ISA != 0)
        {
            ISA -= 1;
            return 1;
        }
        
        return 0;
    }

    public void addToISA()
    {
        ISA += 1;
    }

    public void addTolifetimeISA()
    {
        lifetimeISA += 1.25f;
    }

    public void endOfDay()
    {
        pension = pension * 1.02f;
        ISA = ISA * 1.02f;
        lifetimeISA = lifetimeISA * 1.02f;

    }


}
