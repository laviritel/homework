### What is done in the current refactoring

I extracted ContactPerson class to a separated file, and move into it the definition of ContactPerson class, also I moved method which populates ContactPersonList into this file. Also I define this method like `static` so there is no needed to create instance of ContactPerson class.

Something similar is done with Email handling methods. I create a separate file for email and move into it methods related to email handling. All methods are `static` no instances of Email class are needed.

In the attched code no LINQ was used. LINQ can simplify and minimize the code.
For example in the file *ApplicationForm.aspx.cs* on line number 186 following code:
        
        string[] addresses = toAddresses.Split(';');
                foreach (string s in addresses)
                {
                    if (!s.StartsWith(";"))
                    {
                        receipents.Add(s);
                    }
                }
can be replaced with following:

        toAddresses.Split(';').ToList().ForEach(f=>receipent.Add(f));
        
Maybe using of ASYNC methods and linq can speed up the code execution. 
