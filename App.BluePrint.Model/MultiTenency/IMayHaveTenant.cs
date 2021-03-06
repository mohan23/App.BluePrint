﻿using Abp.Domain.Entities;
using App.BluePrint.UserFramework.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.UserFramework.MultiTenency
{
    /// <summary>
    /// Implement this interface for an entity which may have Tenant.
    /// </summary>
    public interface IMayHaveTenant<TTenant, TUser> : IMayHaveTenant
        where TTenant : TenentDefinition<TTenant, TUser>
        where TUser : UserDefinition<TTenant, TUser>
    {
        /// <summary>
        /// Tenant.
        /// </summary>
        TTenant Tenant { get; set; }
    }

}
