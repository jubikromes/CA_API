using OpenIddictSetUp.Helpers;
using System.ComponentModel;

namespace OpenIddictSetUp.Enums
{
    public enum Permission
    {
        [Category(RoleHelpers.SYS_ADMIN), Description(@"Access All Modules")]
        FULL_CONTROL = 1001,
        [Category(RoleHelpers.CUST), Description(@"Create Event")]
        CREATE_EVENT = 1002,
        [Category(RoleHelpers.CUST), Description(@"Access All Modules")]
        CREATE_PASS = 1003,
        [Category(RoleHelpers.CUST), Description(@"Access All Modules")]
        CREATE_RESERVATION = 1004,
    }
}   