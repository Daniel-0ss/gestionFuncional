using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class DeleteRecetaHandler : IRequestHandler<DeleteRecetaCommand, bool>
{
    private readonly IRecetaRepository _repo;

    public DeleteRecetaHandler(IRecetaRepository repo)
    {
        _repo = repo;
    }

    public Task<bool> Handle(DeleteRecetaCommand request, CancellationToken cancellationToken)
    {
        var receta = _repo.GetById(request.Id);
        if (receta == null) return Task.FromResult(false);

        _repo.Delete(request.Id);
        return Task.FromResult(true);
    }
}
