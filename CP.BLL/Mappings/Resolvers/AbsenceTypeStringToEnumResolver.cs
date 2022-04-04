using AutoMapper;
using CP.BLL.DTOs;
using CP.DAL.Models;

namespace CP.BLL.Mappings.Resolvers
{
    public class AbsenceTypeStringToEnumResolver : IValueResolver<AbsenceDTO, Absence, AbsenceType>
    {
        public AbsenceType Resolve(
            AbsenceDTO source, Absence destination, AbsenceType destMember, ResolutionContext context)
        {
            return (AbsenceType)Enum.Parse(typeof(AbsenceType), source.Type);
        }
    }
}
