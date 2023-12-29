using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject textBhaskara;
    public GameObject painelBhaskara;

    public Bhaskara bhaskara;

    void Awake()
    {
        ActiveText(true);
        ActivePanel(false);
    }

    public void ActiveforInput()
    {
        ActiveText(true);
        //ActivePanel(false);
        bhaskara.ResetFomulasSetActive();
    }

    public void ActiveforButton()
    {
        ActiveText(false);
        //ActivePanel(true);
    }



    public void ActiveText(bool active)
    {
       SetActive(ref textBhaskara, active);

    }

    public void ActivePanel(bool active)
    {
        //SetActive(ref painelBhaskara, active);

    }

    public void SetActive(ref GameObject game, bool active)
    {
        if (active)
        {
            if (!game.activeSelf)
            {
                game.SetActive(true);
            }
        }
        else
        {
            if (game.activeSelf)
            {
                game.SetActive(false);
            }
        }

    }

}
