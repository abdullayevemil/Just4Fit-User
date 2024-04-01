namespace FitnessApp.Infrastructure.Exercises.Handlers;

using FitnessApp.Core.Exercises.Models;
using FitnessApp.Core.Exercises.Repositories;
using FitnessApp.Infrastructure.Exercises.Queries;
using MediatR;

public class GetByIdHandler : IRequestHandler<GetByIdQuery, Exercise?>
{
    private readonly IExerciseRepository exerciseRepository;

    public GetByIdHandler(IExerciseRepository exerciseRepository) => this.exerciseRepository = exerciseRepository;

    public async Task<Exercise?> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request.Id);

        var exercise = await this.exerciseRepository.GetById(request.Id)!;

        if (exercise is null)
        {
            return new Exercise();
        }

        return exercise;
    }
}