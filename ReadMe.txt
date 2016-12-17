The pipe-delimited file lists each record as follows: 

LastName | FirstName | Gender | FavoriteColor | DateOfBirth

 The comma-delimited file looks like this: 

LastName, FirstName, Gender, FavoriteColor, DateOfBirth

 The space-delimited file looks like this: 

LastName FirstName Gender FavoriteColor DateOfBirth




    /*
        Builder is flexible! we can parse from file 

       or start from string

        Check what delimator you are using
        Deliminate file


        Validate models based on specification
        Add if more persons?
        Build Persons         
        
        A. Console
        
        1.  WithDeliminator (pass char)
        2.ParseFromFile (or) ParseFromString, -----> ParseFromFile Will return ValidateRecords plural only.
        3. ValidateRecords(multiple) -> difference from from file or string (returns built person, null person, or invalid person)
        4. WithStrategy(new Default Strategy)
        5. AddToCurrentRecords(persons)
        6. Build() => returns persons       

        B. WebAPI Controller

        1.WithDeliminator(pass char)
        2.ParseFromString ----> returns ValidateRecord singular
        3.ValidateRecord(only 1)
        4.With Strategy
        5.Build(); => builds person


		I now see the REST and Presenter as two differet APIS, which implement shared components.


		Note the documents have say sort by NAME for the REST Service API so the strategy has been renamed to just 'NAME' from 'LastName'


		
    //I should return a new persons

    /*
        Builder is flexible! we can parse from file 

       or start from string

        Check what delimator you are using
        Deliminate file


        Validate models based on specification
        Add if more persons?
        Build Persons         
        
       
        A. Console
        
        1.  WithDeliminator (pass char)
        2.ParseFromFile (or) ParseFromString, -----> ParseFromFile Will return ValidateRecords plural only.
        3. ValidateRecords(multiple) -> difference from from file or string (returns built person, null person, or invalid person)
        4. WithStrategy(new Default Strategy)
        5. AddToCurrentRecords(persons)
        6. Build() => returns persons       

        B. WebAPI Controller

        1.WithDeliminator(pass char)
        2.ParseFromString ----> returns ValidateRecord singular
        3.ValidateRecord(only 1)
        4.With Strategy
        5.Build(); => builds person

*/