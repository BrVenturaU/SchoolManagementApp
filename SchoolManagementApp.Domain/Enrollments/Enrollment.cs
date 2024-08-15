using SchoolManagementApp.Domain.Contracts;
using SchoolManagementApp.Domain.Grades;
using SchoolManagementApp.Domain.Students;
using SchoolManagementApp.Domain.Teachers;
using SchoolManagementApp.Shared.Abstractions;
using SchoolManagementApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Domain.Enrollments;

public class Enrollment: IEntity<long>
{
    public long Id { get; set; }
    public Guid Oid { get; set; }
    public GradeGroup Group { get; set; }
    public short Year { get; set; } // Should Grade have the Year and have a Grade by Year?
    public long StudentId { get; set; }
    public short TeacherId { get; set; } // Should Grade have the Teacher and have a Grade by Teacher?
    public byte GradeId { get; set; }
    public Student Student { get; set; }
    public Teacher Teacher { get; set; }
    public Grade Grade { get; set; }
}
