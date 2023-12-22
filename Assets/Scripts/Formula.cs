using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Formula : MonoBehaviour
{
    public TextMeshProUGUI textB1;
    public TextMeshProUGUI textB2;
    public TextMeshProUGUI text4ac;
    public TextMeshProUGUI text2a;
    public TextMeshProUGUI text2a1;
    public TextMeshProUGUI x1;
    public TextMeshProUGUI x2;
    public TextMeshProUGUI solucao;
    private readonly List<TextMeshProUGUI> listTextMesh = new();

    void Awake(){
        listTextMesh.Add(textB1);
        listTextMesh.Add(textB2);
        listTextMesh.Add(text4ac);
        listTextMesh.Add(text2a);
        listTextMesh.Add(text2a1);
        listTextMesh.Add(x1);
        listTextMesh.Add(x2);
        listTextMesh.Add(solucao);
    }

    public string GetText(int textMesh){
        return listTextMesh[textMesh].text;
    }

    public void SetText(int textMesh, string txt){
       listTextMesh[textMesh].text = txt;
    }
}
