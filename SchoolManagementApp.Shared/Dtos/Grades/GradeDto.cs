using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Shared.Dtos.Grades;
public record GradeDto(Guid Oid, string Name, string Description, bool IsActive) : BaseGradeDto(Oid, Name, Description);
