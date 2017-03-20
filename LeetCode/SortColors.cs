//数组排序变种， 
//颜色对应值
//0:red
//1:white
//2:blue
public class Solution {
    public void SortColors(int[] nums) {
        if (nums == null || nums.Length <= 1) return;
        //小型三分区Quick Sort
        //left 指向0最后一个元素
        //mid 指向1的元素
        //right 指向2的元素尾部
        int left = 0, mid = 0, right = nums.Length - 1;
        while (mid <= right) 
        {
            if (nums[mid] == 0) Swap(nums, mid++, left++);//mid前的mid已排序，所以mid++
            else if (nums[mid] == 1) mid++;
            else Swap(nums, mid, right--);//nums[mid] == 2 交换后的nums[mid]大小未知
        }
    }

    public void Swap(int[] nums, int i, int j)
    {
        int t = nums[i];
        nums[i] = nums[j];
        nums[j] = t;
    }
}