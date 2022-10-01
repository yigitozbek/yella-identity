using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Yella.Identity.Service.Contract.Dtos;
using Yella.Identity.Service.Entities;

namespace Yella.Identity.Service;

public class YellaIdentityAutoMapper<TUser,TRole> : Profile
    where TUser : IdentityUser<TUser, TRole>
    where TRole : IdentityRole<TUser, TRole>
{
    public YellaIdentityAutoMapper()
    {

        #region Identities

        CreateMap<IdentityPermission<TUser,TRole>, ResponsePermissionGetList>();


        #region Roles

        CreateMap<IdentityRole, ResponseRoleGetList>();
        CreateMap<IdentityRole, RequestRoleAdd>();
        CreateMap<IdentityRole, RequestRoleUpdate>();

        CreateMap<IdentityPermissionRole<TUser, TRole>, RequestAddRolePermission>()
            .ForMember(i => i.RoleId, o => o.MapFrom(x => x.IdentityRoleId))
            .ForMember(i => i.PermissionId, o => o.MapFrom(x => x.IdentityPermissionId));

        CreateMap<IdentityPermissionRole<TUser, TRole>, RequestAddRolePermission>()
            .ForMember(i => i.RoleId, o => o.MapFrom(x => x.IdentityRoleId))
            .ForMember(i => i.PermissionId, o => o.MapFrom(x => x.IdentityPermissionId)).ReverseMap();

        CreateMap<IdentityUserRole<TUser, TRole>, RequestRoleAddUserRole>()
            .ForMember(i => i.UserId, o => o.MapFrom(x => x.IdentityUserId))
            .ForMember(i => i.RoleId, o => o.MapFrom(x => x.IdentityRoleId));

        CreateMap<IdentityUserRole<TUser, TRole>, RequestRoleAddUserRole>()
            .ForMember(i => i.UserId, o => o.MapFrom(x => x.IdentityUserId))
            .ForMember(i => i.RoleId, o => o.MapFrom(x => x.IdentityRoleId)).ReverseMap();

        #endregion


        #endregion

    }

}