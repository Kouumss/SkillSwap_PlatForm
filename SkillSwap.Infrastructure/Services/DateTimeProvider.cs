using SkillSwap.Application.Common.Interfaces.Services;

namespace SkillSwap.Infrastructure.Services;

public class DateTimeProvider : IDateTimeprovider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
