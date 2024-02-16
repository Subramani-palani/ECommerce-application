using Assignment.Contracts.Data.Entities.Identity;
using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using Assignment.Core.Features.User.Requests;
using AutoMapper;
using MediatR;

namespace Assignment.Core.Features.User.Handlers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<ApplicationUser>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(IUserRepository userRepository,IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ApplicationUser>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        //Fetch the users from userRepository
        IEnumerable<ApplicationUser> applicationUsers = await _userRepository.GetAllUsersAsync();
        // List<UserResponseDTO> users = new ();

        // //Mapping the objects from ApplicationUser to UserResponseDTO
        // foreach(var applicationUser in applicationUsers){
        //     users.Add(_mapper.Map<UserResponseDTO>(applicationUser));
        // }

        return applicationUsers;
        
    }
}