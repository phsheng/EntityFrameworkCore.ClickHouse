using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

namespace ClickHouse.EntityFrameworkCore.Storage.ValueConversation
{
    public class ClickHouseInstantValueConverter : ValueConverter<Instant, DateTime>
    {
        public ClickHouseInstantValueConverter()
            : base(i => i.ToDateTimeUtc(), d => Instant.FromDateTimeUtc(DateTime.SpecifyKind(d, DateTimeKind.Utc)))
        {
        }
    }

    public class ClickHouseLocalDateValueConverter : ValueConverter<LocalDate, DateTime>
    {
        public ClickHouseLocalDateValueConverter()
            : base(i => i.ToDateTimeUnspecified(), d => LocalDate.FromDateTime(d))
        {
        }
    }
}
