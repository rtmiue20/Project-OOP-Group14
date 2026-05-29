namespace QLDH.Entities.Interface;

public interface ISearchable
{
    bool Matches(string keyword);
}