using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
namespace CitasService.Application.Commands
{
    public class DeleteCitaHandler : IRequestHandler<DeleteCitaCommand, bool>
    {
        private readonly ICitaRepository _repo;

        public DeleteCitaHandler(ICitaRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> Handle(DeleteCitaCommand request, CancellationToken cancellationToken)
        {
            var cita = _repo.GetById(request.Id);
            if (cita == null)
                throw new KeyNotFoundException($"No se encontró ninguna cita con ID {request.Id}.");

            _repo.Delete(request.Id);

            return Task.FromResult(true);
        }
    }
}
