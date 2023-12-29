using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAlpha : MonoBehaviour
{
    private CanvasGroup canvasGroupVfx;
    private Transform transformVfx;

    public Bhaskara bhaskara;

    public GameObject[] formulas;

    public Transform[] location;

    private bool active = false;

    private float updateX;

    private float TempoDecorrido = 0;
    public float TempoDecorridoValue;
    private int getValueFormula;
    private int valueFormulas;

    void Awake()
    {
        canvasGroupVfx = GetComponent<CanvasGroup>();
        transformVfx = GetComponent<Transform>();
    }

    void Update()
    {
        if (active)
        {
            TempoDecorrido += Time.deltaTime;
            if (TempoDecorrido >= TempoDecorridoValue)
            {
                TempoDecorrido = 0;
                updateX++;
                canvasGroupVfx.alpha = (updateX / 100);
                if (updateX > 100)
                {
                    active = false;
                    SetParentNull(getValueFormula);
                    valueFormulas++;
                    if (valueFormulas < 7)
                    {
                        SetFormulasTotal();
                    }
                    else
                    {
                        valueFormulas = 0;
                    }
                }
            }
        }
    }


    private void SetAlphaTotal()
    {
        updateX = 0;
        canvasGroupVfx.alpha = updateX;

        active = true;
    }

    public void SetParentThis(int value)
    {
        formulas[value].transform.SetParent(transformVfx);
        SetAlphaTotal();
        getValueFormula = value;
        //
    }

    public void SetParentNull(int value)
    {
        if (value <= 4)
        {
            formulas[value].transform.SetParent(location[0]);
        }
        else
        {
            formulas[value].transform.SetParent(location[1]);
        }

    }

    public void SetParent(int value)
    {
        SetParentThis(value);
    }

    public void SetFormulasTotal() 
    {        

        if (bhaskara.GetRaizQuadrada4ac() == "erroRaiz" && valueFormulas > 3)
        {            
            SetParent(7);
            bhaskara.negativeSolution.SetActive(true);
        }
        else if (bhaskara.GetRaizQuadrada4ac() == "erroRaiz" && valueFormulas <= 3)
        {
            bhaskara.SetActiveFormula(valueFormulas, true);
            SetParent(valueFormulas);
        }
        else
        {
            bhaskara.SetActiveFormula(valueFormulas, true);
            SetParent(valueFormulas);
        }
    }
}
