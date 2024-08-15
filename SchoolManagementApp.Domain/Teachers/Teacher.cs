using SchoolManagementApp.Domain.Contracts;
using SchoolManagementApp.Shared.Abstractions;
using SchoolManagementApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Domain.Teachers;

public class Teacher: IEntity<short>
{
    public short Id { get; set; }
    public Guid Oid { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string FirstSurname { get; set; }
    public string LastSurname { get; set; }
    public Gender Gender { get; set; }
    public DateTime BirthDate { get; set; }
}
