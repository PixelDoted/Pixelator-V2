using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{

    public TMP_InputField inputField;
    public TMP_InputField inputFieldCheck;

    public string math;

    private float Pi = 3.14f;

    //Adds text to the end
    public void addText(string s) {
        if (math.Contains("F")) 
        {
            if (s == "+" || s == "-" || s == "*" || s == "/" || s == ".") return;
        }
        math += s;
        if (!math.Contains("F")) calculateCheck();
        else updateText();
    }

    //Removes text from the end
    public void removeText() {
        math = math.Remove(math.Length-1);
        calculateCheck();
    }

    //Clears the text
    public void clearText() {
        math = "";
        inputField.text = "";
        calculateCheck();
    }

    //Check claculates the math problem
    public void calculateCheck() {
        if (math == "") { inputFieldCheck.text = ""; return; }
        if (math.EndsWith("*") || math.EndsWith("/") || math.EndsWith("+") || math.EndsWith("-")) { inputField.text = math; return; }
        inputField.text = math;
        inputFieldCheck.text = MathHandler.calculate(math);
    }

    //Calculates the math problem
    public void calculate() {
        if (math == "") { inputFieldCheck.text = ""; return; }
        if (math.EndsWith("*") || math.EndsWith("/") || math.EndsWith("+") || math.EndsWith("-")) { inputField.text = math; return; }
        math = MathHandler.calculate(math).ToString();
        updateText();
    }

    public void updateText() {
        inputField.text = math;
        inputFieldCheck.text = "";
    }
    //Special

    //Calculates the Remainder
    public void Remainder() {
        if (math.Contains("*") || math.Contains("-") || math.Contains("+")) return;
        if (!math.Contains("/")) return;
        string[] split = math.Split('/');
        if (split.Length > 2) return;
        string v = inputFieldCheck.text.Split('.')[0];
        float value = float.Parse(split[0]) - float.Parse(v) * float.Parse(split[1]);
        calculate();
        math = math.Split('.')[0] + "R" + value;

        updateText();
    }

    //Doubles any value
    public float Double(float v) {
        return v*v;
    }

    //Calculates the Area of a circle
    public void Area() {
        float Area = Pi * Double(float.Parse(math));

        math = Area.ToString();
        updateText();
    }

    //Calculates the Circumference of a circle
    public void Circumference() {
        float Circ = Pi * float.Parse(math);

        math = Circ.ToString();
        updateText();
    }

    //Calculates the lowest terms of a fraction
    public void LowestTerms() {
        if (!math.Contains("F")) return;
        string[] values = math.Split('F');
        int gcd = MathHandler.GreatestCommonDivisor(int.Parse(values[0]), int.Parse(values[1]));
        float a = float.Parse(values[0])/gcd;
        float b = float.Parse(values[1])/gcd;
        math = a.ToString() + "F" + b.ToString();
        updateText();
    }

    //set the Type to be a Fraction
    public void setFraction() {
        if (math.Contains("+") || math.Contains("-") || math.Contains("/") || math.Contains("*")) { calculate(); }
        math += "F";
        updateText();
    }

}