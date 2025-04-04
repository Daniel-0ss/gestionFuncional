using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PersonasService.Domain.Entities;

namespace PersonasService.Application.Commands
{
    public class DeletePersonaHandler : IRequestHandler<DeletePersonaCommand, bool>
    {
        private readonly IPersonaRepository _repo;

        public DeletePersonaHandler(IPersonaRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> Handle(DeletePersonaCommand request, CancellationToken cancellationToken)
        {
            var persona = _repo.GetById(request.Id);
            if (persona == null)
                throw new KeyNotFoundException($"No se encontró ninguna persona con ID {request.Id}.");

            _repo.Delete(request.Id);

            return Task.FromResult(true);
        }
    }
}
