using GuaranteedRate.Domain.Models.Persons;

namespace GuaranteedRate.Domain.Builders.Interfaces
{

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

    public interface IPersonsBuilder
    {
        IPersons Build();
    }
}
