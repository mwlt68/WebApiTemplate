using DataAccess.Consts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Configurations
{
    internal class UserEntityConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure((EntityTypeBuilder<User>)builder);

            builder.ToTable("User");

            builder.HasIndex((System.Linq.Expressions.Expression<Func<User, object?>>)(e => e.Username), "User_name_Unique")
                .IsUnique();


            builder.Property<string>((User e) => e.Password)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("password");


            builder.Property<string>((User e) => e.Username)
                .IsRequired()
                .HasMaxLength(UserConsts.UserNameMaxLength)
                .HasColumnName("username");

            builder.HasData(
                new User
                {
                    Id = 1,
                    Username = "mevlut",
                    Password = "C4CA4238A0B923820DCC509A6F75849B", // 1
                }
            );
        }
    }
}
