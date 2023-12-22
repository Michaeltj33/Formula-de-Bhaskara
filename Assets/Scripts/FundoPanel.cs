using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FundoPanel : MonoBehaviour
{
    public Text[] letras;
    public InputField[] letrasInput;

    public Text Getletra(int value){
        return letras[value];
    }

    public string GetletraInput(int value){
        return letrasInput[value].text;
    }

   public void Setletter(int value){
     if(int.Parse(letrasInput[value].text) < 0){
        var getLetra = int.Parse(letrasInput[value].text);
        getLetra *= -1;
        letrasInput[value].text = getLetra.ToString();
     }
   }
}
