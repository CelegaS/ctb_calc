using System;
using System.Collections.Generic;

// Collection of useful static functions
public static class Dewlib
{
    /// Takes an array of strings and trims all of their trailing and leading whitespace
    public static string[] TrimStringArray(string[] arr)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            arr[i] = arr[i].Trim();
        }
        return arr;
    }

    // Keeps the number in the range between lower and upper
    public static double RestrictRange(double num, double lower, double upper)
    {
        if(lower > upper)
            throw new ArgumentException("Error, lower is greater than upper\n" +
                                        "lower: " + lower + "\n" +
                                        "upper: " + upper);

        //A positive threshold is exceeded by going above it
        if(num > upper)
        {
            //Just in case the threshold is exceeded multiple times
            while(num > upper)
                num = num - upper + lower;
        }
        //A negative threshold is exceeded by going below it
        else if(num < lower)
        {
            while(num < lower)
                num = upper - (lower - num);
        }

        return num;
    }

    //Removes empty strings in a given array
    public static string[] RemoveEmptyEntries(string[] arr)
    {
        List<string> finalarr = new List<string>(arr);

        finalarr.RemoveAll(isEmpty);

        return finalarr.ToArray();
    }

    //Predicate method for RemoveEmptyEntries that determines if a string is empty
    private static bool isEmpty(string str)
    {
        return str.Length == 0;
    }

    //Calculates the distance between two points
    public static double GetDistance(double a, double b, double x, double y)
    {
        return Math.Sqrt(Math.Pow(x - a, 2) + Math.Pow(y - b, 2));
    }
    
    //Calculates the nth row of pascal's triangle
    //The first row is n=0
    //Credit from http://stackoverflow.com/questions/15580291/how-to-efficiently-calculate-a-row-in-pascals-triangle
    public static int[] GetPascalRow(int n)
    {
        List<int> row = new List<int>();
        row.Add(1);
        for(int i = 0; i < n; i++)
        {
            row.Add((int)(row[i] * (n-i) / (double)(i+1)));
        }
        return row.ToArray();
    }
    
    //Sum a list of numbers with a given weight
    //The list is first sorted greatest to least, then each item is added after being
    //multiplied by weight^i
    public static double SumScaledList(double[] items, double weight)
    {   
        if(weight < 0 || weight > 1)
            throw new ArgumentOutOfRangeException("Error, weight is out of bounds\n" +
                                                  "weight=" + weight);
        Array.Sort(items);
        //to make the list greatest to least
        Array.Reverse(items);
        
        double sum = 0;
        for(int i = 0; i < items.Length; i++)
            sum += items[i] * Math.Pow(weight, i);
        
        return sum;
    }
}
