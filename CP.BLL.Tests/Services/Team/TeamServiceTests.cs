//using AutoMapper;
//using CP.BLL.DTOs;
//using CP.BLL.Mappings;
//using CP.DAL.Models;
//using CP.DAL.UnitOfWork;
//using Moq;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Xunit;

//namespace CP.BLL.Services.Tests
//{
//    public class TeamServiceTests
//    {
//        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
//        private readonly IMapper _mapper;
//        private readonly TeamService _systemUnderTest;

//        public TeamServiceTests()
//        {
//            _unitOfWorkMock = new Mock<IUnitOfWork>();

//            if (_mapper is null)
//            {
//                var mappingConfig = new MapperConfiguration(mc =>
//                {
//                    mc.AddProfile<MapProfile>();
//                });
//                _mapper = mappingConfig.CreateMapper();
//            }

//            _systemUnderTest = new TeamService(_unitOfWorkMock.Object, _mapper);
//        }

//        [Fact()]
//        public async Task GetAllAsync_WithData_ReturnsListAsync()
//        {
//            // ARRANGE
//            var teams = new List<Team>
//            {
//                new Team() { Id = 1, Name = "TeamA" },
//                new Team() { Id = 2, Name = "TeamB" },
//                new Team() { Id = 3, Name = "TeamC" }
//            };

//            _unitOfWorkMock
//                .Setup(x => x.Teams.FindAllAsync())
//                .ReturnsAsync(teams);

//            // ACT
//            var teamDTOs = await _systemUnderTest.GetAllAsync();

//            // ASSERT
//            Assert.True(teamDTOs.Count.Equals(3));
//        }

//        [Fact()]
//        public async Task GetAllAsync_WithoutData_ReturnsEmptyListAsync()
//        {
//            // ARRANGE
//            List<Team> emptyList = new List<Team>();
//            this._unitOfWorkMock.Setup(x => x.Teams.FindAllAsync()).ReturnsAsync(emptyList);

//            // ACT
//            IList<TeamDTO> teamDTOs = await this._systemUnderTest.GetAllAsync();

//            // ASSERT
//            Assert.NotNull(teamDTOs);
//            Assert.True(teamDTOs.Count.Equals(0));
//        }

//        [Fact()]
//        public async Task GetAsync_WhenFound_ReturnsAsync()
//        {
//            // ARRANGE
//            int teamWithIdToFind = 1;
//            var teamsFound = new List<Team>() { new Team() { Id = 1, Name = "TeamA" } };

//            this._unitOfWorkMock
//                .Setup(x => x.Teams.FindByAsync(x => x.Id.Equals(teamWithIdToFind)))
//                .ReturnsAsync(teamsFound);

//            // ACT
//            var actTeamFound = await this._systemUnderTest.GetAsync(teamWithIdToFind);
//            var expTeamFound = new TeamDTO() { Id = 1, Name = "TeamA" };

//            // ASSERT
//            Assert.NotNull(actTeamFound);
//            Assert.Equal(expTeamFound.Id, actTeamFound.Id);
//            Assert.Equal(expTeamFound.Name, actTeamFound.Name);
//        }

//        [Fact()]
//        public void GetAsync_WhenNotFound_Throws()
//        {
//            // ARRANGE
//            int teamWithIdToFind = 1;
//            var teamsFound = new List<Team>();

//            this._unitOfWorkMock
//                .Setup(x => x.Teams.FindByAsync(x => x.Id.Equals(teamWithIdToFind)))
//                .ReturnsAsync(teamsFound);

//            // ACT & ASSERT
//            Assert.ThrowsAsync<TeamNotFoundException>(
//                () => this._systemUnderTest.GetAsync(teamWithIdToFind));
//        }

//        //[Fact()]
//        //public async Task CreateAsync_VerifyAddAndSaveAsync()
//        //{
//        //    // ARRANGE
//        //    TeamDTO teamToAdd = new() { Id = 0, Name = "TeamA" };

//        //    // ACT
//        //    await _systemUnderTest.CreateAsync(teamToAdd);

//        //    // ASSERT
//        //    _unitOfWorkMock.Verify(x => x.Teams.AddAsync(It.IsAny<Team>()));
//        //    _unitOfWorkMock.Verify(x => x.SaveAsync());
//        //}
//    }
//}
