namespace GuaranteedRate.Domain.Builders.Interfaces
{
    public interface ISetDeliminatorHolder
    {
        IParseFromFileHolder WithDeliminatorForFile(char deliminator);
    }


}