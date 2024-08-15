using SchoolManagementApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Shared.Dtos.Teachers;
public record TeacherDto(Guid Oid, string FirstName, string FirstSurname, Gender Gender) : BaseTeacherDto(Oid, FirstName, FirstSurname);
