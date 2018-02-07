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
