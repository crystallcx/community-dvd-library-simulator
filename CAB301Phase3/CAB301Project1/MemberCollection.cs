using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301Project
{
    class MemberCollection : IMemberCollection
    {
        // Fields
        private int capacity;
        private int count;
        private Member[] members; //make sure members are sorted in dictionary order

        // Properties

        // get the capacity of this member colllection 
        // pre-condition: nil
        // post-condition: return the capacity of this member collection and this member collection remains unchanged
        public int Capacity { get { return capacity; } }

        // get the number of members in this member colllection 
        // pre-condition: nil
        // post-condition: return the number of members in this member collection and this member collection remains unchanged
        public int Number { get { return count; } }




        // Constructor - to create an object of member collection 
        // Pre-condition: capacity > 0
        // Post-condition: an object of this member collection class is created

        public MemberCollection(int capacity)
        {
            if (capacity > 0)
            {
                this.capacity = capacity;
                members = new Member[capacity];
                count = 0;
            }
        }

        // check if this member collection is full
        // Pre-condition: nil
        // Post-condition: return ture if this member collection is full; otherwise return false.
        public bool IsFull()
        {
            return count == capacity;
        }

        // check if this member collection is empty
        // Pre-condition: nil
        // Post-condition: return ture if this member collection is empty; otherwise return false.
        public bool IsEmpty()
        {
            return count == 0;
        }

        // Add a new member to this member collection
        // Pre-condition: this member collection is not full
        // Post-condition: a new member is added to the member collection and the members are sorted in ascending order by their full names;
        // No duplicate will be added into this the member collection
        public void Add(IMember member)
        {
            if (count < Capacity)
            {
                int i = 0;
                int v = 0; //count of duplicates
                int j = count - 1; //index to add 
                Member temp = (Member)member;
                while ((i < count) && (members[i].CompareTo(temp) != 0))
                {
                    i++;
                }
                if (i != count)
                {
                    v++;
                }
                if (v == 0)
                {
                    while ((j >= 0) && (members[j].CompareTo(temp)) == 1)
                    {
                        members[j + 1] = members[j];
                        j = j - 1;
                    }
                    members[j + 1] = temp;
                    count++;
                    Console.WriteLine($"Adding New member: {member.FirstName} {member.LastName} ");
                    return;
                }
                else
                {
                    Console.WriteLine($"{member.FirstName} {member.LastName} Member Already Existis - ADD ERROR MESSAGE");
                    return;
                }
            }
            else
            {
                Console.WriteLine("The member array is full... - ADD ERROR MESSAGE");
                return;
            }
        }


        // Remove a given member out of this member collection
        // Pre-condition: nil
        // Post-condition: the given member has been removed from this member collection, if the given meber was in the member collection
        public void Delete(IMember aMember)
        {
            int i = 0;//index to remove
            Member temp = (Member)aMember;
            while ((i < count) && (members[i].CompareTo(temp) != 0))
            {
                i++;
                if (i == count)
                {
                    break;
                }
            }
            if (i == count || IsEmpty())
            {
                Console.WriteLine($"{aMember.FirstName} {aMember.LastName} That member does not exist! - DELETE ERROR MESSAGE");
                return;
            }
            else if (i != count)
            {
                Console.WriteLine($"\nDELETING MEMBER: {members[i].FirstName} {members[i].LastName}\n");
                for (int j = i + 1; j < count; j++)
                {
                    members[j - 1] = members[j];
                }
                count--;
            }
            return;
        }

        // Search a given member in this member collection 
        // Pre-condition: nil
        // Post-condition: return true if this memeber is in the member collection; return false otherwise; member collection remains unchanged
        public bool Search(IMember member)
        {
            int i = 0; //min num
            int j = count - 1; //max num
            Member temp = new Member(member.FirstName, member.LastName);
            if (!IsEmpty())
            {
                while (i <= j)
                {
                    int mid = (i + j) / 2;
                    if (temp.CompareTo(members[mid]) == 0)
                    {
                        Console.WriteLine($"Member Exists: {members[mid].FirstName} {members[mid].LastName} --- Search = True");
                        return true;
                    }
                    else if (temp.CompareTo(members[mid]) == -1)
                    {
                        j = mid - 1;
                    }
                    else
                    {
                        i = mid + 1;
                    }
                }
            }
            Console.WriteLine($"Member {member.FirstName} {member.LastName} does not exists -- Search = False ");
            return false;
        }

        // Remove all the members in this member collection
        // Pre-condition: nil
        // Post-condition: no member in this member collection 
        public void Clear()
        {
            for (int i = 0; i < count; i++)
            {
                this.members[i] = null;
            }
            count = 0;
        }

        // Return a string containing the information about all the members in this member collection.
        // The information includes last name, first name and contact number in this order
        // Pre-condition: nil
        // Post-condition: a string containing the information about all the members in this member collection is returned
        public string ToString()
        {
            string s = "";
            for (int i = 0; i < count; i++)
                s = s + members[i].ToString() + "\n";
            return s;
        }

        public void printMemColl()
        {
            for (int i = 0; i < count; i++)
                Console.Write($"{members[i].ToString()} \n");
        }
    }
}


