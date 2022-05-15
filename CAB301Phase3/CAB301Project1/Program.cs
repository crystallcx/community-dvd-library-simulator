using System;

namespace CAB301Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //TEST for IsVlaidContactNumber ==============================================TEST CONTACT NUMBER =============================
            Console.WriteLine("Testing for isValidContactNumber...");
            testIsValidPhoneNumber();
            Console.WriteLine();
            */
            
            //TEST for isValidPin=====================================================TEST PIN =====================================
            Console.WriteLine("Testing for isValidPin...");
            testIsValidPin();
            Console.WriteLine();
            


            string firstName = "John";
            string lastName = "Kelly";
            string contactNumber = "04229abcdefgsdsf";
            string pin = "1abc34";
            Member NewMember = new Member(firstName, lastName, contactNumber, pin);

            string firstName1 = "Larry";
            string lastName1 = "Kelly";
            string contactNumber1 = "04229abcdefgsdsf";
            string pin1 = "1abc34";
            Member NewMember1 = new Member(firstName1, lastName1, contactNumber1, pin1);

            string firstName2 = "John";
            string lastName2 = "Smith";
            string contactNumber2 = "04229abcdefgsdsf";
            string pin2 = "1abc34";
            Member NewMember2 = new Member(firstName2, lastName2, contactNumber2, pin2);

            string firstName3 = "Sam";
            string lastName3 = "Kelly";
            string contactNumber3 = "04229abcdefgsdsf";
            string pin3 = "1abc34";
            Member NewMember3 = new Member(firstName3, lastName3, contactNumber3, pin3);

            string firstName4 = "Harry";
            string lastName4 = "Kelly";
            string contactNumber4 = "04229abcdefgsdsf";
            string pin4 = "1abc34";
            Member NewMember4 = new Member(firstName4, lastName4, contactNumber4, pin4);

            string firstName5 = "Peter";
            string lastName5 = "Alpha";
            string contactNumber5 = "04229abcdefgsdsf";
            string pin5 = "1abc34";
            Member NewMember5 = new Member(firstName5, lastName5, contactNumber5, pin5);

            string firstName6 = "John";
            string lastName6 = "Smith";
            string contactNumber6 = "04229abcdefgsdsf";
            string pin6 = "1abc34";
            Member NewMember6 = new Member(firstName6, lastName6, contactNumber6, pin6);

            string firstName7 = "Jimmy";
            string lastName7 = "Watson";
            string contactNumber7 = "04229abcdefgsdsf";
            string pin7 = "1abc34";
            Member NewMember7 = new Member(firstName7, lastName7, contactNumber7, pin7);


            
            //creating differnt size members array(s)
            MemberCollection NewMemberCollection = new MemberCollection(20);
            MemberCollection NewMemberCollection1 = new MemberCollection(10);
            MemberCollection NewMemberCollection2 = new MemberCollection(5);
            MemberCollection NewMemberCollection3 = new MemberCollection(1);
            MemberCollection NewMemberCollection4 = new MemberCollection(3);

            /*
            //TEST 1 for ADD/DELETE - ===========================================================ADD/DELETE TEST 1==================================
            //Add 7 members and delete 4 of the members, delete member never added, add to many members, add duplicate, sucessful search and unsucessful search
            Console.WriteLine("~~TEST 1 for Add/Delete...");

            NewMemberCollection.Add(NewMember3); //Sam Kelly
            NewMemberCollection.Add(NewMember2); //John Smith
            NewMemberCollection.Add(NewMember1); //Larry Kelly
            NewMemberCollection.Add(NewMember5); //Peter Alpha  
            NewMemberCollection.Add(NewMember6); //John Smith (dupe)
            NewMemberCollection.Add(NewMember); //John Kelly 
            NewMemberCollection.Add(NewMember); //John Kelly 
            NewMemberCollection.Delete(NewMember5); //Peter Alpha
            
            NewMemberCollection.Add(NewMember4); //Harry Kelly
            NewMemberCollection.Add(NewMember6); //John Smith (dupe)
            
            NewMemberCollection.Delete(NewMember); //John Kelly
            NewMemberCollection.Delete(NewMember1); //Larry Kelly
            NewMemberCollection.Delete(NewMember2); //John Smith
            NewMemberCollection.Delete(NewMember7); //Jimmy Watson (never added)
            NewMemberCollection.Add(NewMember5); //Peter Alpha (again)
            NewMemberCollection.Add(NewMember5); //Peter Alpha (dupe)
            NewMemberCollection.Add(NewMember5); //Peter Alpha (dupe)
            NewMemberCollection.Add(NewMember5); //Peter Alpha (dupe)
            NewMemberCollection.Add(NewMember5); //Peter Alpha (dupe)
            NewMemberCollection.Add(NewMember6); //John Smith (dupe)
            NewMemberCollection.Add(NewMember6); //John Smith (dupe)
            NewMemberCollection.Add(NewMember6); //John Smith (dupe)
            NewMemberCollection.Add(NewMember6); //John Smith (dupe)


            Console.WriteLine();
            Console.WriteLine("Result:");
            //EXPECTED RESULTS IN SORTED ORDER======================================EXPECTED RESULTS ADD/DELETE TEST 1 ===============================================
            //Alpha, Peter
            //Kelly, Harry
            //Kelly, Sam
            //John, Smith
            //true
            //false
            NewMemberCollection.printMemColl();
            Console.WriteLine();
            Console.WriteLine($"{NewMemberCollection.Search(NewMember3)}"); //Sam Kelly 
            Console.WriteLine($"{NewMemberCollection.Search(NewMember1)}"); //Larry Kelly 
            

            
            //TEST 2 for ADD/DELETE  -==========================================================ADD/DELETE TEST 2 =======================================================
            //ADD 7 Members in random order, 1 Duplicate member - Sorting first and last names and detecting dupe members
            Console.WriteLine("~~TEST 2 for Add/Delete...");
            NewMemberCollection1.Add(NewMember2); //John Smith
            NewMemberCollection1.Add(NewMember6); //John Smith (dupe)
            NewMemberCollection1.Add(NewMember3); //Sam Kelly
            NewMemberCollection1.Add(NewMember1); //Larry Kelly
            NewMemberCollection1.Add(NewMember5); //Peter Alpha  
            NewMemberCollection1.Add(NewMember); //John Kelly 
            NewMemberCollection1.Add(NewMember4); //Harry Kelly
            NewMemberCollection1.Delete(NewMember); //John Kelly
            NewMemberCollection1.Delete(NewMember1); //Larry Kelly
            NewMemberCollection1.Delete(NewMember6); //John Smith (dupe)
            NewMemberCollection1.printMemColl();
            NewMemberCollection1.Delete(NewMember1); //Larry Kelly
            NewMemberCollection1.Delete(NewMember6); //John Smith (dupe)
            NewMemberCollection1.Add(NewMember1); //Larry Kelly
            NewMemberCollection1.Add(NewMember5); //Peter Alpha (dupe)
            NewMemberCollection1.Delete(NewMember5); //Peter Alpha 
            NewMemberCollection1.Add(NewMember5); //Peter Alpha 
            NewMemberCollection1.Delete(NewMember7); //Jimmy Watson (never added)
            Console.WriteLine();
            Console.WriteLine("Result:");
            //EXPECTED RESULTS IN SORTED ORDER======================================EXPECTED RESULTS ADD/DELETE TEST 2 ===============================================
            //Alpha, Peter
            //Kelly, Harry 
            //Kelly, Larry
            //Kelly, Sam
            NewMemberCollection1.printMemColl();
            Console.WriteLine();
            */
            /*
            //TEST 3 for ADD/DELETE ===============================================================ADD/DELETE TEST 3 =======================================================
            //Add and Delete in random order 
            Console.WriteLine("~~Test 3 for Add/Delete...");
            NewMemberCollection2.Add(NewMember1); // Larry Kelly
            NewMemberCollection2.Delete(NewMember1); //Larry Kelly
            NewMemberCollection2.Add(NewMember); //John Kelly
            NewMemberCollection2.Add(NewMember2); // John Smith
            NewMemberCollection2.Delete(NewMember2); //John Smith
            NewMemberCollection2.Add(NewMember7); //Jimmy Watson
            NewMemberCollection2.Add(NewMember4); //Harry Kelly
            NewMemberCollection2.Delete(NewMember); //John Kelly
            Console.WriteLine();
            Console.WriteLine("Result:");
            //EXPECTED RESULTS IN SORTED ORDER======================================EXPECTED RESULTS ADD/DELETE TEST 3 ===============================================
            //Kelly, Harry
            //Watson, Jimmy
            NewMemberCollection2.printMemColl();
            Console.WriteLine();
            */
            /*
            //TEST 4 for ADD/DELETE ===============================================================ADD/DELETE TEST 4 =======================================================
            //Delete member in empty array
            Console.WriteLine("~~Test 4 for Add/Delete...");
            NewMemberCollection3.Delete(NewMember1); //Larry Kelly

            Console.WriteLine();
            Console.WriteLine("Result:");
            //EXPECTED RESULTS IN SORTED ORDER======================================EXPECTED RESULTS ADD/DELETE TEST 4 ===============================================
            // print nothing.
            NewMemberCollection3.printMemColl();
            Console.WriteLine();


            //TEST 5 for ADD/DELETE ===============================================================ADD/DELETE TEST 5 =======================================================
            //Try add member to a full array
            Console.WriteLine("~~Test 5 for Add/Delete...");
            NewMemberCollection4.Add(NewMember2); //John Smith
            NewMemberCollection4.Add(NewMember3); //Sam Kelly
            NewMemberCollection4.Add(NewMember1); //Larry Kelly
            NewMemberCollection4.Add(NewMember5); //Peter Alpha  

            Console.WriteLine();
            Console.WriteLine("Result:");
            //EXPECTED RESULTS IN SORTED ORDER======================================EXPECTED RESULTS TEST ADD/DELETE 5 ===============================================
            // Kelly, Larry
            // Kelly, Sam
            // Smith, John
            NewMemberCollection4.printMemColl();
            Console.WriteLine();
            */





            
            /*
            //TEST 1 for SEARCHING - ===========================================================SEARCH TEST 1 ==================================
            //
            Console.WriteLine("~~TEST 1 for Searching...");

            NewMemberCollection.Add(NewMember3); //Sam Kelly
            NewMemberCollection.Add(NewMember1); //Larry Kelly
            NewMemberCollection.Add(NewMember5); //Peter Alpha  
            NewMemberCollection.Add(NewMember2); //John Smith
            NewMemberCollection.Add(NewMember); //John Kelly 
            NewMemberCollection.Add(NewMember4); //Harry Kelly
            NewMemberCollection.Add(new Member("Mark", "Smith")); //John Kelly 
            NewMemberCollection.Add(new Member("Andrew", "Smith")); //John Kelly 
            NewMemberCollection.Add(new Member("Zebra", "Smith")); //John Kelly 
            NewMemberCollection.Add(new Member("Delta", "Smith")); //John Kelly 
            NewMemberCollection.Add(new Member("Charlie", "Smith")); //John Kelly 
            NewMemberCollection.Add(new Member("Bravo", "Smith")); //John Kelly 
            NewMemberCollection.Add(new Member("Coffee", "Smith")); //John Kelly 
            NewMemberCollection.Search(NewMember4); //Jimmy Watson
            Console.WriteLine();
            Console.WriteLine("Result:");
            //EXPECTED RESULTS IN SORTED ORDER======================================EXPECTED RESULTS SEARCH TEST 1 ===============================================
            //
            // TRUE
            //
            NewMemberCollection.printMemColl();
            Console.WriteLine();

            


            //TEST 2 for SEARCHING - ===========================================================SEARCH TEST 2 ==================================
            //Searching for a member that does not exists.
            Console.WriteLine("~~TEST 2 for Searching...");

            NewMemberCollection1.Add(NewMember3); //Sam Kelly
            NewMemberCollection1.Add(NewMember1); //Larry Kelly
            NewMemberCollection1.Add(NewMember5); //Peter Alpha  
            NewMemberCollection1.Add(NewMember2); //John Smith
            NewMemberCollection1.Add(NewMember); //John Kelly 
            NewMemberCollection1.Add(NewMember4); //Harry Kelly
            NewMemberCollection1.Search(NewMember7); //Jimmy Watson
            Console.WriteLine();
            Console.WriteLine("Result:");
            //EXPECTED RESULTS IN SORTED ORDER======================================EXPECTED RESULTS SEARCH TEST 2 ===============================================
            //
            // FALSE
            //
            NewMemberCollection1.printMemColl();
            Console.WriteLine();
            */
        }

        //test method for isValidPin
        public static void testIsValidPin()
        {
            //outcome should be TRUE
            string pin1 = "123456"; // TRUE
            string pin2 = "000000"; // TRUE
            string pin3 = "11adf11111"; // FALSE
            string pin4 = "1234"; // TRUE
            string pin5 = "678910"; //TRUE

            //outcome should be FALSE
            string pin6 = "123abc"; //FALSE
            string pin7 = "abcdef"; //FALSE
            string pin8 = "00000"; //TRUE
            string pin9 = ""; //FALSE
            string pin10 = "123"; // FALSE
            string pin11 = "1234567"; // FALSE
            string pin12 = "[]"; //FALSE

            Console.WriteLine($"Should be True: {IMember.IsValidPin(pin1)}");
            Console.WriteLine($"Should be True: {IMember.IsValidPin(pin2)}");
            Console.WriteLine($"Should be False: {IMember.IsValidPin(pin3)}");
            Console.WriteLine($"Should be True: {IMember.IsValidPin(pin4)}");
            Console.WriteLine($"Should be True: {IMember.IsValidPin(pin5)}");

            Console.WriteLine($"Should be False: {IMember.IsValidPin(pin6)}");
            Console.WriteLine($"Should be False: {IMember.IsValidPin(pin7)}");
            Console.WriteLine($"Should be True: {IMember.IsValidPin(pin8)}");
            Console.WriteLine($"Should be False: {IMember.IsValidPin(pin9)}");
            Console.WriteLine($"Should be False: {IMember.IsValidPin(pin10)}");
            Console.WriteLine($"Should be False: {IMember.IsValidPin(pin11)}");
            Console.WriteLine($"Should be False: {IMember.IsValidPin(pin12)}");
        }

        //test method for IsValidPhoneNumber
        public static void testIsValidPhoneNumber()
        {
            //outcome should be TRUE
            string contactNumber1 = "0422977644"; //TRUE
            string contactNumber2 = "0000000000";//TRUE
            string contactNumber3 = "0123456789"; //TRUE
            string contactNumber4 = "0999999999"; //TRUE
            string contactNumber5 = "0123456789"; //TRUE

            //outcome should be FALSE
            string contactNumber6 = "1234567890"; //FALSE
            string contactNumber7 = "01245";        //FALSE
            string contactNumber8 = "01234567899"; //FALSE
            string contactNumber9 = "0422abc674"; //FALSE
            string contactNumber10 = "";            //FALSE

            //mixed outcome
            string contactNumber11 = "0422937674"; //TRUE
            string contactNumber12 = "a123456789"; //FALSE
            string contactNumber13 = "3123456789"; //FALSE
            string contactNumber14 = "012345679"; //FALSE
            string contactNumber15 = "0433233569"; //TRUE

            Console.WriteLine($"Should be True: {IMember.IsValidContactNumber(contactNumber1)}");
            Console.WriteLine($"Should be True: {IMember.IsValidContactNumber(contactNumber2)}");
            Console.WriteLine($"Should be True: {IMember.IsValidContactNumber(contactNumber3)}");
            Console.WriteLine($"Should be True: {IMember.IsValidContactNumber(contactNumber4)}");
            Console.WriteLine($"Should be True: {IMember.IsValidContactNumber(contactNumber5)}");

            Console.WriteLine($"Should be False: {IMember.IsValidContactNumber(contactNumber6)}");
            Console.WriteLine($"Should be False: {IMember.IsValidContactNumber(contactNumber7)}");
            Console.WriteLine($"Should be False: {IMember.IsValidContactNumber(contactNumber8)}");
            Console.WriteLine($"Should be False: {IMember.IsValidContactNumber(contactNumber9)}");
            Console.WriteLine($"Should be False: {IMember.IsValidContactNumber(contactNumber10)}");

            Console.WriteLine($"Should be Ture: {IMember.IsValidContactNumber(contactNumber11)}");
            Console.WriteLine($"Should be False: {IMember.IsValidContactNumber(contactNumber12)}");
            Console.WriteLine($"Should be False: {IMember.IsValidContactNumber(contactNumber13)}");
            Console.WriteLine($"Should be False: {IMember.IsValidContactNumber(contactNumber14)}");
            Console.WriteLine($"Should be True: {IMember.IsValidContactNumber(contactNumber15)}");
        }

        

    }
}
