using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Chat_Online.Models;

public partial class DbChatOnlineContext : DbContext
{
    public DbChatOnlineContext()
    {
    }

    public DbChatOnlineContext(DbContextOptions<DbChatOnlineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Utente> Utentes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-22\\SQLEXPRESS;Database=db_chat_online;User Id=academy;Password=academy?;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Utente>(entity =>
        {
            entity.HasKey(e => e.UtenteId).HasName("PK__Utente__CA5C22530FFB2BD9");

            entity.ToTable("Utente");

            entity.Property(e => e.UtenteId).HasColumnName("utenteID");
            entity.Property(e => e.Codice)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("codice");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.PasswordU)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("passwordU");
            entity.Property(e => e.Username)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
