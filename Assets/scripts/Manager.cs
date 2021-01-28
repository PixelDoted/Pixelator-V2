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

    public void addText(string s) {
        math += s;
        calculateCheck();
    }

    public void removeText() {
        math = math.Remove(math.Length-1);
        calculateCheck();
    }

    public void clearText() {
        math = "";
        inputField.text = "";
        calculateCheck();
    }

    public void calculateCheck() {
        if (math == "") { inputFieldCheck.text = ""; return; }
        if (math.EndsWith("*") || math.EndsWith("/") || math.EndsWith("+") || math.EndsWith("-")) { inputField.text = math; return; }
        inputField.text = math;
        inputFieldCheck.text = MathHandler.calculate(math);
    }

    public void calculate() {
        if (math == "") { inputFieldCheck.text = ""; return; }
        if (math.EndsWith("*") || math.EndsWith("/") || math.EndsWith("+") || math.EndsWith("-")) { inputField.text = math; return; }
        math = MathHandler.calculate(math).ToString();
        inputField.text = math;
        inputFieldCheck.text = "";
    }

    //Special
    public void Remainder() {
        if (math.Contains("*") || math.Contains("-") || math.Contains("+")) return;
        if (!math.Contains("/")) return;
        string[] split = math.Split('/');
        if (split.Length > 2) return;
        string v = inputFieldCheck.text.Split('.')[0];
        float value = float.Parse(split[0]) - float.Parse(v) * float.Parse(split[1]);
        calculate();
        math = math.Split('.')[0] + "R" + value;

        inputField.text = math;
        inputFieldCheck.text = "";
    }

    public float Double(float v) {
        return v*v;
    }

    public void Area() {
        float Area = Pi * Double(float.Parse(math));

        math = Area.ToString();
        inputField.text = math;
        inputFieldCheck.text = "";
    }

    public void Circumference() {
        float Circ = Pi * float.Parse(math);

        math = Circ.ToString();
        inputField.text = math;
        inputFieldCheck.text = "";
    }

}