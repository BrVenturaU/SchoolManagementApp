using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Shared.Abstractions;

public interface IEntity<TId>
{
    public TId Id { get; set; }
    public Guid Oid { get; set; }
}
