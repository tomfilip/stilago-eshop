using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.Interface
{
    /// <summary>
    /// Use this interface if you want to have your objects audited
    /// </summary>
    /// <typeparam name="TKey">The user entity primary key type</typeparam>
    /// <typeparam name="TEntity">The user entity type for the navigation properties</typeparam>
    public interface IAudit<TKey> 
    {
        DateTimeOffset CreationTime { get; set; }
        DateTimeOffset LastModificationTime { get; set; }
        TKey CreatedById { get; set; }
        TKey ModifiedById { get; set; }
    }
}
