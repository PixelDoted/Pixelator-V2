using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathHandler : MonoBehaviour
{
    
    //Calculates the Math
    public static string calculate(string s) {
        string[] mathFirst = s.Split(new char[] {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.'});
        List<string> maths = new List<string>();
        List<int> nextCalculation = new List<int>();
        string[] nums = s.Split(new char[] {'+', '-', '*', '/'});

        float value = 0;
        bool valueChanged = false;

        int numIndex = 0;

        for (int i = 0; i < mathFirst.Length; i++) {
            if (mathFirst[i] == "") continue;
            maths.Add(mathFirst[i]);
        }

        List<string> mathsMulti = new List<string>();
        List<string> mathsAdd = new List<string>();

        //Seperates Multiplying and Dividing from Adding and Subtracting
        for (int i = 0; i < maths.Count; i++)
        {
            string multi = " ";
            string add = " ";
            if (maths[i] == "*" || maths[i] == "/") multi = maths[i];
            else if (maths[i] == "+" || maths[i] == "-") add = maths[i];
            mathsMulti.Add(multi);
            mathsAdd.Add(add);
        }

        //adds Multiplying and Dividing to nextCalculation
        for (int i = 0; i < mathsMulti.Count; i++) {
            if (mathsMulti[i] != "*" && mathsMulti[i] != "/") continue;
            nextCalculation.Add(i);
        }

        //adds Adding and Subtracting to nextCalculation
        for (int i = 0; i < mathsAdd.Count; i++) {
            if (mathsAdd[i] != "+" && mathsAdd[i] != "-") continue;
            nextCalculation.Add(i);
        }

        //Does the calculations
        for (int i = 0; i < nextCalculation.Count; i++) {
            string Math = maths[nextCalculation[i]];
            if (Math == "+" && valueChanged == false) value = calculateAdd(nums[nextCalculation[i]], nums[nextCalculation[i]+1]);
            else if (Math == "-" && valueChanged == false) value = calculateSubtract(nums[nextCalculation[i]], nums[nextCalculation[i]+1]);
            else if (Math == "*" && valueChanged == false) value = calculateTimes(nums[nextCalculation[i]], nums[nextCalculation[i]+1]);
            else if (Math == "/" && valueChanged == false) value = calculateDivide(nums[nextCalculation[i]], nums[nextCalculation[i]+1]);

            if (Math == "+" && valueChanged == true) value = calculateAdd(value.ToString(), nums[nextCalculation[i]]);
            else if (Math == "-" && valueChanged == true) value = calculateSubtract(value.ToString(), nums[nextCalculation[i]]);
            else if (Math == "*" && valueChanged == true) value = calculateTimes(value.ToString(), nums[nextCalculation[i]]);
            else if (Math == "/" && valueChanged == true) value = calculateDivide(value.ToString(), nums[nextCalculation[i]]);

            numIndex += 1;
            valueChanged = true;
        }
        
        return value.ToString();
    }

    public static float calculateAdd(string a, string b) {
        return float.Parse(a) + float.Parse(b);
    }

    public static float calculateSubtract(string a, string b) {
        return float.Parse(a) - float.Parse(b);
    }

    public static float calculateTimes(string a, string b) {
        return float.Parse(a) * float.Parse(b);
    }

    public static float calculateDivide(string a, string b) {
        return float.Parse(a) / float.Parse(b);
    }

    public static int GreatestCommonDivisor(int x, int y)
    {
        return y == 0 ? x : GreatestCommonDivisor(y, x % y);
    }
}
