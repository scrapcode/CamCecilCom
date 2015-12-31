using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using CamCecilCom.Data;

namespace CamCecilCom.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20151231022358_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CamCecilCom.Models.BlogPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AuthorId");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("MyProperty");

                    b.Property<string>("Title");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("CamCecilCom.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Username");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("CamCecilCom.Models.BlogPost", b =>
                {
                    b.HasOne("CamCecilCom.Models.User")
                        .WithMany()
                        .HasForeignKey("AuthorId");
                });
        }
    }
}
