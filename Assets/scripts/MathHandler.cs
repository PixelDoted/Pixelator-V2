using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathHandler : MonoBehaviour
{
    
    public static string calculate(string s) {
        string[] mathFirst = s.Split(new char[] {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.'});
        List<string> maths = new List<string>();
        string[] nums = s.Split(new char[] {'+', '-', '*', '/'});

        float value = 0;
        bool valueChanged = false;

        int numIndex = 0;

        for (int i = 0; i < mathFirst.Length; i++) {
            if (mathFirst[i] == "") continue;
            maths.Add(mathFirst[i]);
        }

        for (int i = 0; i < maths.Count; i++) {
            if (maths[i] == "+" && valueChanged == false) value = calculateAdd(nums[numIndex], nums[numIndex+1]);
            else if (maths[i] == "-" && valueChanged == false) value = calculateSubtract(nums[numIndex], nums[numIndex+1]);
            else if (maths[i] == "*" && valueChanged == false) value = calculateTimes(nums[numIndex], nums[numIndex+1]);
            else if (maths[i] == "/" && valueChanged == false) value = calculateDivide(nums[numIndex], nums[numIndex+1]);

            if (maths[i] == "+" && valueChanged == true) value = calculateAdd(value.ToString(), nums[numIndex]);
            else if (maths[i] == "-" && valueChanged == true) value = calculateSubtract(value.ToString(), nums[numIndex]);
            else if (maths[i] == "*" && valueChanged == true) value = calculateTimes(value.ToString(), nums[numIndex]);
            else if (maths[i] == "/" && valueChanged == true) value = calculateDivide(value.ToString(), nums[numIndex]);

            numIndex += valueChanged == false ? 2 : 1;
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
}
