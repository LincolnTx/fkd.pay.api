using fkd.pay.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fkd.pay.api.Data.Mapping
{
    public class PaymentCardMap : IEntityTypeConfiguration<PaymentCard>
    {
        public void Configure(EntityTypeBuilder<PaymentCard> builder)
        {
            builder.ToTable("payment_card");

            builder.HasKey(payment => payment.Id);

            builder.Property(payment => payment.CardNumber)
                .HasField("_cardNumber")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("card_number")
                .IsRequired();
            
            builder.Property(payment => payment.ExpMonth)
                .HasField("_expMonth")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("exp_month")
                .IsRequired();
            
            builder.Property(payment => payment.ExpYear)
                .HasField("_expYear")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("exp_year")
                .IsRequired();
            
            builder.Property<string>("_cvv")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("cvv")
                .IsRequired();
            
            builder.Property(payment => payment.CardHolderName)
                .HasField("_cardHolderName")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("card_holder_name")
                .IsRequired();
            
            builder.Property(payment => payment.AvailableBalance)
                .HasField("_availableBalance")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("available_balance")
                .IsRequired();
        }
    }
}