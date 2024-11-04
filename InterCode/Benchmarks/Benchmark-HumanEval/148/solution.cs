using System;
using System.Linq;

public class ReferenceCode
{
    public static string[] Puzzle(string planet1, string planet2)
    {
        string[] planetNames = { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune" };
        if (!planetNames.Contains(planet1) || !planetNames.Contains(planet2) || planet1 == planet2)
        {
            return new string[0];
        }
        int planet1Index = Array.IndexOf(planetNames, planet1);
        int planet2Index = Array.IndexOf(planetNames, planet2);
        if (planet1Index < planet2Index)
        {
            return planetNames.Skip(planet1Index + 1).Take(planet2Index - planet1Index - 1).ToArray();
        }
        else
        {
            return planetNames.Skip(planet2Index + 1).Take(planet1Index - planet2Index - 1).ToArray();
        }
    }
}