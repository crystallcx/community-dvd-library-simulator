//CAB301 assessment 1 - 2022
//The implementation of MemberCollection ADT

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
        //if member collection full, terminate
        if (IsFull())
        {
            Console.WriteLine("Member collection full.");
            return;
        }

        //quickly check (using binary search) if member already exists, if so, terminate
        if (Search(member) == true)
        {
            Console.WriteLine("Member cannot be added, already exists in collection.");
            return;
        }

        //add non-duplicate member into array
        int i;
        for (i = count - 1; (i >= 0 && member.CompareTo(members[i]) < 1); i--)
        {
            members[i + 1] = members[i];
        }

        members[i + 1] = (Member)member; 
        count++; //increase member count
    }

    // Remove a given member out of this member collection
    // Pre-condition: nil
    // Post-condition: the given member has been removed from this member collection, if the given meber was in the member collection
    public void Delete(IMember aMember)
    {
        //if colleciton is empty, terminate 
        if (IsEmpty())
        {
            Console.WriteLine("Collection empty. No members to delete.");
            return;
        }

        //initialise variables
        int lower = 0;
        int upper = count - 1;
        int mid;
        bool found = false;

        //find index of member to be deleted from array
        while (lower <= upper)
        {
            mid = (lower + upper) / 2;
            if (aMember.CompareTo(members[mid]) == 0)
            {
                lower = mid;
                found = true;
                break;
            }
            else if (aMember.CompareTo(members[mid]) == -1)
                upper = mid - 1;

            else
                lower = mid + 1;
        }

        //if member does not exist in array, terminate
        if (found == false)
        {
            Console.WriteLine($"Member does not exist in collection.");
            return;
        }

        //delete element from array
        for (int i = lower; i < count - 1; i++)
            members[i] = members[i + 1];

        count--; //decrease member count
        members[count] = null; 
        Console.WriteLine($"Member successfully deleted.");
    }

    // Search a given member in this member collection 
    // Pre-condition: nil
    // Post-condition: return true if this memeber is in the member collection; return false otherwise; member collection remains unchanged
    public bool Search(IMember member)
    {
        if (IsEmpty())
            return false;

        //initialise variables
        int lower = 0;
        int upper = count - 1;
        int mid;

        while (lower <= upper)
        {
            mid = (lower + upper) / 2;
            if (member.CompareTo(members[mid]) == 0)
            {
               // Console.WriteLine("Member exists in collection.");
                return true;
            }
            else if (member.CompareTo(members[mid]) == -1)
                upper = mid - 1;
            else
                lower = mid + 1;
        }
        //Console.WriteLine($"Member {member.FirstName}, {member.FirstName} does not exist in collection.");
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
}

