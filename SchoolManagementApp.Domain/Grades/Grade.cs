using SchoolManagementApp.Domain.Contracts;
using SchoolManagementApp.Domain.Enrollments;
using SchoolManagementApp.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Domain.Grades;

public class Grade : IEntity<byte>
{
    public byte Id { get; set; }
    public Guid Oid { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public IEnumerable<Enrollment> Enrollments { get; set; }
}
