//找出最大的水容器 两条长度不一的竖线，取最小的
//思路1: Brute Force, 类似选择排序，穷举，然后选取最大的 时间复杂度O(n²) Time Limit Exceeded
//思路2: 
public class Solution {
    public int MaxArea(int[] height) {
        if (height.Length < 2) return 0;

        int maxArea = 0;
        int left = 0, right = height.Length -1;
        while (left < right)
        {
            int t = (right - left) * (height[left] < height[right] ? height[left] : height[right]);
            maxArea = (maxArea < t) ? t : maxArea;

            if (height[left] < height[right])
                left++;
            else 
                right--;
        }

        return maxArea;
    }
}