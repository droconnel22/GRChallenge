using GuaranteedRate.Domain.Models.Persons;

namespace GuaranteedRate.Domain.Builders.Interfaces
{
    public interface IParseFromPostBodyHolder
    {
        IPersons SetRecordFromPostBody(string model);
    }
}