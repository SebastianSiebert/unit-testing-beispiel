namespace Beispiel.Anwendung.Interfaces;

public interface ITranslation
{
    string EntityNotFoundMessage { get; }
    string ValidationFailedMessage { get; }
    string NotEmptyMessage { get; }
    string MaxLengthMessage(int i);
}