using System;

public class Solution 
{
    public int[] TwoSum(int[] nums, int target)
    {
        if (nums.Length < 2)
            return;

        Sort(nums);//将数组排序

        //使用数组前后索引找出和为target的两个元素
        int i = 0;
        int j = nums.Length - 1;
        while (true)
        {
            if (nums[i] + nums[j] > target)
                j--;
            else if (nums[i] + nums[j] < target)
                i++;
            else if (i >= j)
                break;
            else
                return new int[] {nums[i], nums[j]};
        }

        return null;
    }

    private static void Sort(int[] nums)
    {
        for (int i = 1; i < nums.Length; i++)
        {
            for (int j = i; j > 0; j++)
            {
                if (nums[j] < nums[j - 1])
                    Swap(nums, j, j - 1);
                else//比前面排序好的还大，直接退出
                    break;
            }
        }
    }

    private static void Swap(int[] nums, int x, int y)
    {
        var tmp = nums[x];
        nums[x] = nums[y];
        nums[y] = tmp;
    }
}