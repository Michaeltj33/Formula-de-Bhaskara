using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bhaskara : MonoBehaviour
{
    public FundoPanel fundoPanel;
    public Formula f2;
    public Formula f3;
    public Formula f4;
    public Formula f5;
    public Formula f6;
    public Formula f7;

    public GameObject NotDivisionZero;
    public GameObject negativeSolution;
    private string text4ac;
    private string text4acRaizQuadrada;
    private string text2a;
    private string menosB;
    private string x1;
    private string x2;
    private Text getLetterA;
    private Text getLetterB;
    private Text getLetterC;


    public TextMeshProUGUI bhaskaraTextMeshProUGUI;

    private string calculos;
    private string letraB;
    private string FBhaskaraTitulo;
    private string tituloBx;
    private string tituloC;
    private string resMais;
    private string resMenos;
    private string solucao;
    public GameController gameController;


    public void CalcularBhaskara()
    {

        negativeSolution.SetActive(false);
        getLetterA = fundoPanel.Getletra(0);
        getLetterB = fundoPanel.Getletra(1);
        getLetterC = fundoPanel.Getletra(2);

        gameController.ActiveforButton();

        GetTextTitulo(getLetterB.text, ref tituloBx);
        GetTextTitulo(getLetterC.text, ref tituloC);
        FBhaskaraTitulo = getLetterA.text + "x²" + tituloBx + "x" + tituloC + " = 0";
        bhaskaraTextMeshProUGUI.text = FBhaskaraTitulo;

        //Substitu as letras por números dentro da Formula F2       
        CalcF2();

        //Calcula o valores dentro da Formula F3       
        CalcF3();

        //realiza os cálculos dentro da raiz
        CalcF4();

        //Calcula a Raiz quadrada dentro da raiz
        CalcF5();

        CalcF6();

        CalcF7();
    }

    private void GetTextTitulo(string texto, ref string textLetter)
    {
        if (int.Parse(texto) > 0)
        {
            textLetter = " + " + texto;
        }
        else
        {
            textLetter = " - " + Converter(texto);
        }

    }


    private void CalcF2()
    {
        f2.SetText(0, Getparent(getLetterB.text));

        f2.SetText(1, getLetterB.text);
        text4ac = "4." + getLetterA.text + "." + Getparent(getLetterC.text);
        f2.SetText(2, text4ac);
        text2a = "2." + getLetterA.text;
        f2.SetText(3, text2a);
    }

    private void CalcF3()
    {

        f3.SetText(0, Getparent(getLetterB.text));

        calculos = CalcStrings(getLetterB.text, getLetterB.text, "*");
        f3.SetText(1, calculos);

        text4ac = (4 * int.Parse(getLetterA.text) * int.Parse(getLetterC.text)).ToString();
        f3.SetText(2, text4ac);

        text2a = (2 * int.Parse(getLetterA.text)).ToString();
        f3.SetText(3, text2a);
    }

    private void CalcF4()
    {

        menosB = Converter(getLetterB.text);
        f4.SetText(0, menosB);

        text4ac = (int.Parse(calculos) - int.Parse(text4ac)).ToString();
        f4.SetText(2, text4ac);

        f4.SetText(3, text2a);

        if (int.Parse(text4ac) < 0)
        {
            NotDivisionZero.SetActive(false);
            negativeSolution.SetActive(true);
        }
        else
        {
            NotDivisionZero.SetActive(true);
            negativeSolution.SetActive(false);
        }

    }

    private void CalcF5()
    {
        f5.SetText(0, menosB);
        text4acRaizQuadrada = RaizQuadrada(text4ac);

        text4acRaizQuadrada = FloatToInt(text4acRaizQuadrada);
        f5.SetText(2, text4acRaizQuadrada);
        f5.SetText(3, text2a);
    }

    private void CalcF6()
    {
        f6.SetText(0, menosB + " + " + text4acRaizQuadrada);
        f6.SetText(1, menosB + " - " + text4acRaizQuadrada);
        f6.SetText(3, text2a);
        f6.SetText(4, text2a);
    }

    private void CalcF7()
    {
        x1 = CalcStrings(menosB, text4acRaizQuadrada, "+");
        f7.SetText(5, x1);

        x2 = CalcStrings(menosB, text4acRaizQuadrada, "-");
        f7.SetText(6, x2);


        f7.SetText(3, text2a);
        f7.SetText(4, text2a);

        resMais = CalcStrings(x1, text2a, "/");
        f7.SetText(0, resMais);

        resMenos = CalcStrings(x2, text2a, "/");
        f7.SetText(1, resMenos);

        solucao = OrdemCrescente(resMais, resMenos);
        f7.SetText(7, solucao);
    }

    private string OrdemCrescente(string text1, string text2)
    {
        float getTxt1 = float.Parse(text1);
        float getTxt2 = float.Parse(text2);
        if (getTxt1 < getTxt2)
        {
            return ReturnInt(getTxt1) + "," + ReturnInt(getTxt2);
        }
        else if (getTxt1 > getTxt2)
        {
            return ReturnInt(getTxt2) + "," + ReturnInt(getTxt1);
        }
        return ReturnInt(getTxt1);
    }

    public string ReturnInt(float n1)
    {
        if (n1 % 1 == 0)
        {
            var getFloat = (int)n1;
            return getFloat.ToString();
        }
        return n1.ToString("F2");
    }

    private string CalcStrings(string txt1, string txt2, string tipo)
    {
        float pgtext1 = float.Parse(txt1);
        float pgtext2 = float.Parse(txt2);
        if (tipo == "+")
        {
            return (pgtext1 + pgtext2).ToString();
        }
        else if (tipo == "-")
        {
            return (pgtext1 - pgtext2).ToString();
        }
        else if (tipo == "/")
        {
            return (pgtext1 / pgtext2).ToString();
        }
        else if (tipo == "*")
        {
            return (pgtext1 * pgtext2).ToString();
        }
        return "";
    }


    private string FloatToInt(string value)
    {
        float getValueFloat = float.Parse(value);
        int getValueInt = (int)Mathf.Floor(getValueFloat);
        if (getValueFloat % getValueInt == 0)
        {
            return getValueInt.ToString();
        }
        return value;
    }


    private void NotNegative()
    {
        if (int.Parse(getLetterA.text) < 0)
        {
            var getletter = int.Parse(getLetterA.text);
            getletter *= -1;
            getLetterA.text = getletter.ToString();
        }
    }

    private string Getparent(string letter)
    {
        if (int.Parse(letter) > 0)
        {
            return letter;
        }
        return "(" + letter + ")";
    }

    private string Converter(string text)
    {
        var text1 = int.Parse(text);
        text1 *= -1;
        return text1.ToString();
    }

    private string RaizQuadrada(string value)
    {
        var getValue = float.Parse(value);
        return Mathf.Sqrt(getValue).ToString("F2");
    }


    private int Expoente(int value)
    {
        return value * value;
    }
}
