using System;
using System.Data.Common;
using ClickHouse.EntityFrameworkCore.Storage.ValueConversation;
using Microsoft.EntityFrameworkCore.Storage;
using NodaTime;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping
{
    public class ClickHouseInstantTypeMapping : RelationalTypeMapping
    {
        public ClickHouseInstantTypeMapping() :
            base(new RelationalTypeMappingParameters(
                    new CoreTypeMappingParameters(typeof(LocalDate), new ClickHouseInstantValueConverter()),
                    "DateTime",
                    StoreTypePostfix.None,
                    System.Data.DbType.DateTime,
                    false))
        {
        }
        protected ClickHouseInstantTypeMapping(RelationalTypeMappingParameters parameters)
          : base(parameters)
        {
        }
        protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
        {
            return new ClickHouseInstantTypeMapping(parameters);
        }
        protected override string SqlLiteralFormatString => "'{0:yyyy-MM-dd hh:mm:ss}'";
        protected override void ConfigureParameter(DbParameter parameter)
        {
            var clickHouseParameter = (Client.ADO.Parameters.ClickHouseDbParameter)parameter;

            if (clickHouseParameter.Value is DBNull)
            {
                clickHouseParameter.ClickHouseType = $"Nullable({StoreType})";
            }
            else
            {
                clickHouseParameter.ClickHouseType = StoreType;
            }
        }
    }

    public class ClickHouseLocalDateTypeMapping : RelationalTypeMapping
    {
        public ClickHouseLocalDateTypeMapping() :
            base(new RelationalTypeMappingParameters(
                    new CoreTypeMappingParameters(typeof(LocalDate), new ClickHouseLocalDateValueConverter()),
                    "Date",
                    StoreTypePostfix.None,
                    System.Data.DbType.Date,
                    false))
        {
        }
        protected ClickHouseLocalDateTypeMapping(RelationalTypeMappingParameters parameters)
          : base(parameters)
        {
        }
        protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
        {
            return new ClickHouseLocalDateTypeMapping(parameters);
        }
        protected override string SqlLiteralFormatString => "'{0:yyyy-MM-dd}'";
        protected override void ConfigureParameter(DbParameter parameter)
        {
            var clickHouseParameter = (Client.ADO.Parameters.ClickHouseDbParameter)parameter;

            if (clickHouseParameter.Value is DBNull)
            {
                clickHouseParameter.ClickHouseType = $"Nullable({StoreType})";
            }
            else
            {
                clickHouseParameter.ClickHouseType = StoreType;
            }
        }
    }
}
