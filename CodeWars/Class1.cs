namespace CodeWars
{
    // PROBLEM: https://leetcode.com/problems/add-two-numbers
    // (this part was included in the problem so doesn't have pseudo code)
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Class1
    {
        // The algorithm adds two numbers, each stored as a linked list of nodes storing one digit each. It returns the output in a similar node.
        // To accomplish this, it recursively loops through both lists at the same time, adding the digits (plus one if it's carrying from the
        // previous digit), storing the output as a new digit for the result, and passing the next digit in each input and the output list to be
        // operated on in the next iteration. It handles cases where the inputs are different lenghts by passing a placeholder null node to the
        // next iteration, in which case it'll just ignore that node in the next calculation.

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            // create new list node
            ListNode returnList = null;
            // create null node placeholder
            ListNode nullNode = null;
            // run PerformAddition using the list nodes with carry set to false
            PerformAddition(ref l1, ref l2, ref returnList, ref nullNode, false);
            // return return list
            return returnList;
        }

        private void PerformAddition(ref ListNode? l1, ref ListNode? l2, ref ListNode returnList, ref ListNode? nullNode, bool carry = false)
        {
            // if list 1 and list 2 are null
            if (l1 == null && l2 == null)
            {
                // if carry is true
                if (carry)
                {
                    // add a new digit 1 to return list and return
                    returnList.next = new ListNode(1);
                }
                // else return
                return;
            }

            // create bool for carrying one to the next digit, default false
            bool shouldCarryNext = false;
            // next digit = l1 value + l2 value + ternary for carry (ternary to add 0 if l1 or l2 are null)
            int nextDigit = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + (carry ? 1 : 0);
            // if next digit is greater than or equal to 10
            if (nextDigit >= 10)
            {
                // next digit = next digit mod 10
                nextDigit %= 10;
                // set cary to true
                shouldCarryNext = true;
            }
            // new digit = null
            ListNode newDigit = null;
            // if the return list is null
            if (returnList == null)
            {
                // return list = new node with value next digit
                returnList = new ListNode(nextDigit);
            }
            // else
            else
            {
                // new digit = new node with value nextdigit
                newDigit = new ListNode(nextDigit);
                // set new digit to the next digit of returnlist
                returnList.next = newDigit;
            }

            // run again with l1 next, l2 next, new digit, and carry to next digit bool (ternary for null if l1 or l2 are null, use original listitem if newDigit it null)
            PerformAddition(ref (l1 == null ? ref nullNode : ref l1.next),
                ref (l2 == null ? ref nullNode : ref l2.next), 
                ref (newDigit == null ? ref returnList : ref newDigit), 
                ref nullNode, 
                shouldCarryNext);
        }
    }
}
