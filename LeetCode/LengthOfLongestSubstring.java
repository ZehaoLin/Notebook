/**
 * 最大滑动窗口
 */

public class Solution {
    public int lengthOfLongestSubstring(String s) {
        int n = s.length();
        if (s == null || n == 0)  return 0;//字符串检查
        int max = 0, i = 0, j = 0;
        Set<Character> set = new HashSet<>();

        while (i < n && j < n) {
            if (set.contains(s.charAt(j)) == false) {//set中没有c字符
                set.add(s.charAt(j++));
                max = Math.max(max, j - i);
            }
            else {
                set.remove(s.charAt(i++));
            }
        }

        return max;
    }
}