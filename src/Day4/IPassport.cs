namespace Day4
{
    public interface IPassport
    {
        bool CheckPassportThatFieldsExist { get; }
        bool IsValid { get; }
    }
}