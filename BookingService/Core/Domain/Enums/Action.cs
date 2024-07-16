namespace Domain.Enums
{
    public enum Action
    {
        Pay = 0, // Need be created
        Finish = 1, // Need be paid
        Cancel = 2, // Cannot be paid or finished
        Refound = 3, // Need be paid
        Reopen = 4 // Need be canceled
    }
}
