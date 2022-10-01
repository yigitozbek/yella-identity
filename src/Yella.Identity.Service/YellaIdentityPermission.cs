using Microsoft.AspNetCore.Identity;
using Yella.Identity.Service.Entities;

namespace Yella.Identity.Service;

public class YellaIdentityPermission
{

    public class Permissions
    {
        public const string GetList = $"Service.{nameof(Permissions)}.{nameof(GetList)}";
        public const string Add = $"Service.{nameof(Permissions)}.{nameof(Add)}";
        public const string Delete = $"Service.{nameof(Permissions)}.{nameof(Delete)}";

    }

    public class Roles
    {
        public const string Get = $"Service.{nameof(Roles)}.{nameof(Get)}";
        public const string Add = $"Service.{nameof(Roles)}.{nameof(Add)}";
        public const string Update = $"Service.{nameof(Roles)}.{nameof(Update)}";
        public const string Delete = $"Service.{nameof(Roles)}.{nameof(Delete)}";
    }
}