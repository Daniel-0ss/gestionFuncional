using MediatR;



public class DeleteRecetaCommand : IRequest<bool>
{
    public int Id { get; set; }
}

