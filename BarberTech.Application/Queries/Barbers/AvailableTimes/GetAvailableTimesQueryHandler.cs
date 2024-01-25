﻿using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Barbers.AvailableTimes
{
    public class GetAvailableTimesQueryHandler : IRequestHandler<GetAvailableTimesQuery, IEnumerable<string>>
    {
        private readonly IBarberRepository _barberRepository;
        private readonly INotificationContext _notification;

        public GetAvailableTimesQueryHandler(IBarberRepository barberRepository, INotificationContext notification)
        {
            _barberRepository = barberRepository;
            _notification = notification;
        }

        public async Task<IEnumerable<string>> Handle(GetAvailableTimesQuery request, CancellationToken cancellationToken)
        {
            var barber = await _barberRepository.GetBarberByIdWithEventSchedulesAsync(request.Id);

            if (barber == null)
            {
                _notification.AddNotFound("Barber does not exists");
                return default;
            }

            var requestDate = DateTime.Parse(request.Date);
            var availableTimes = barber.GetAvailableTimesByDateTime(requestDate);

            return availableTimes.Select(time => time.ToString());
        }
    }
}
