using SchoolManagementApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Shared.Dtos.Students;
public record StudentDto(Guid Oid, string FirstName, string FirstSurname, Gender Gender) : BaseStudentDto(Oid, FirstName, FirstSurname);