using System;

namespace Db
{
    public record Location
    (
        int LocationId,
        string City,
        string Zip,
        Decimal TowingCost,
        int CompanySiteId,
        string Display
    )
    {
        public override string ToString()
        {
            return $"[{LocationId}] {Display} | {City}";
        }
    };

    public record UserStatus
    (
        int UserStatusId,
        string Display,
        string Description
    )
    {
        public override string ToString()
        {
            return $"[{UserStatusId}] {Display} | {Description}";
        }
    };
}