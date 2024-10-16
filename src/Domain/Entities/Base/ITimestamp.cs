namespace Domain.Entities.Base;

public interface ITimestamp
{
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}