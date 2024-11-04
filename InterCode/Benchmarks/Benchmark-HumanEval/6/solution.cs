using System;  
using System.Collections.Generic;  
using System.Linq;  
  
public class ReferenceCode  
{    
    public static int[] Puzzle(string input)  
    {  
        // 分割输入字符串以获取各个括号组  
        string[] groups = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);  
  
        List<int> maxLevels = new List<int>();  
  
        foreach (string group in groups)  
        {  
            int maxLevel = 0;  
            int currentLevel = 0;  
  
            // 遍历每个字符来计算最深层嵌套级别  
            foreach (char c in group)  
            {  
                if (c == '(')  
                {  
                    currentLevel++;  
                    if (currentLevel > maxLevel)  
                    {  
                        maxLevel = currentLevel;  
                    }  
                }  
                else if (c == ')')  
                {  
                    currentLevel--;  
                }  
            }  
  
            // 将每个组的最深层嵌套级别添加到列表中  
            maxLevels.Add(maxLevel);  
        }  
  
        // 返回结果数组  
        return maxLevels.ToArray();  
    }  
}