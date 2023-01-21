using System.Threading.Tasks;
using Module5_HW1.Services.Interfaces;

namespace Module5_HW1;

public class Starter
{
    private readonly IUserService _userService;
    private readonly IResourceService _resourceService;
    private readonly IAuthService _authService;

    public Starter(
        IUserService userService,
        IResourceService resourceService,
        IAuthService authService)
    {
        _userService = userService;
        _resourceService = resourceService;
        _authService = authService;
    }

    public async Task Start()
    {
        var getUsersByPage = Task.Run(
            async () => await _userService.GetUsersByPage(2));
        var getUserById = Task.Run(
            async () => await _userService.GetUserById(2));
        var getUser404 = Task.Run(
            async () => await _userService.GetUserById(23));
        var getAllResources = Task.Run(
            async () => await _resourceService.GetAllResources());
        var getResourceById = Task.Run(
            async () => await _resourceService.GetResourceById(2));
        var getRescource404 = Task.Run(
            async () => await _resourceService.GetResourceById(23));
        var createUser = Task.Run(
            async () => await _userService.CreateUserEmployee(
                "Clint",
                "Cowboy"));
        var updateUserPut = Task.Run(
            async () => await _userService.UpdateUserEmployeeById(
                2,
                "Bill",
                "Layer"));
        var updateUserPatch = Task.Run(
            async () => await _userService.ModifyUserEmployeeById(
                2,
                "Bill",
                "Policeman"));
        var deleteUser = Task.Run(
            async () => await _userService.RemoveUserEmployeeById(2));
        var registerUserOK = Task.Run(
            async () => await _authService.Register(
                "hard",
                "too"));
        var registerUserFail = Task.Run(
            async () => await _authService.Register(
                "meow",
                null!));
        var loginUserOK = Task.Run(
            async () => await _authService.Login(
                "eve.holt@reqres.in",
                "cityslicka"));
        var loginUserFail = Task.Run(
            async () => await _authService.Login(
                "eve",
                null!));
        var getUsersByDelay = Task.Run(
            async () => await _userService.GetUsersByDelay(3));

        await Task.WhenAll(
            getUsersByPage,
            getUserById,
            getUser404,
            getAllResources,
            createUser,
            updateUserPut,
            registerUserOK,
            registerUserFail,
            loginUserOK,
            loginUserFail,
            getUsersByDelay);

        var getUsersByPageResult = await getUsersByPage;
        var getUserByIdResult = await getUserById;
        var getUser404Result = await getUser404;
        var getAllResourcesResult = await getAllResources;
        var createUserResult = await createUser;
        var updateUserPutResult = await updateUserPut;
        var registerUserResult = await registerUserOK;
        var registerUserFailResult = await registerUserFail;
        var loginUserOKResult = await loginUserOK;
        var loginUserFailResult = await loginUserFail;
        var getUsersByDelayResult = await getUsersByDelay;
    }
}