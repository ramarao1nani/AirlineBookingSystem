using AirlineBookingSystem.Payments.Core.Entities;
using AirlineBookingSystem.Payments.Core.Repositories;
using AirlineBookingSystem.Payments.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Payments.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDbContext _paymentDbContext;
        public PaymentRepository(PaymentDbContext paymentDbContext)
        {
            _paymentDbContext = paymentDbContext;
        }
        public async Task ProcessPaymentAsync(Payment payment)
        {
            await _paymentDbContext.Payments.AddAsync(payment);
            await _paymentDbContext.SaveChangesAsync();
        }

        public async Task RefundPaymentAsync(Guid id)
        {
            var payment = await _paymentDbContext.Payments.FirstOrDefaultAsync(x => x.Id == id);
            if (payment != null)
            {
                _paymentDbContext.Payments.Remove(payment);
                await _paymentDbContext.SaveChangesAsync();
            }
        }
    }
}
