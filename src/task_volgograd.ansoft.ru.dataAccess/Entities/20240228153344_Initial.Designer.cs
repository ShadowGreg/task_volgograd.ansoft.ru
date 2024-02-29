﻿// <auto-generated />
using FirebirdSql.EntityFrameworkCore.Firebird.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using task_volgograd.ansoft.ru.dataAccess;

#nullable disable

namespace task_volgograd.ansoft.ru.dataAccess.Entities
{
    [DbContext(typeof(DataContext))]
    [Migration("20240228153344_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Fb:ValueGenerationStrategy", FbValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 31);

            modelBuilder.Entity("task_volgograd.ansoft.ru.domain.Domain.Message.Attachment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(256)");

                    b.Property<byte[]>("AttachmentFile")
                        .HasColumnType("BLOB SUB_TYPE BINARY");

                    b.HasKey("Id");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("task_volgograd.ansoft.ru.domain.Domain.Message.Message", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(256)");

                    b.Property<string>("Email")
                        .HasColumnType("BLOB SUB_TYPE TEXT");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
