
using Framwork.Utilities;

namespace Framework.Domain.BaseEntities;

public class BaseEntity<T>
{
    public T Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }

    public BaseEntity()
    {
        CreatedDate = DateUtility.DateTimeNow();
    }
}