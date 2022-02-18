using CP.BLL.Services;
using CP.DAL.Models;

namespace CP.BLL.Profiles
{
    /// <summary>
    /// Configures mapping classes.
    /// </summary>
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            base.CreateMap<Team, TeamDTO>().ReverseMap();
        }
    }
}
