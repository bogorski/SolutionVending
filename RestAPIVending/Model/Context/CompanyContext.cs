using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RestAPIVending.Model;

namespace RestAPIVending.Model.Context;

public partial class CompanyContext : DbContext
{
    public CompanyContext()
    {
    }

    public CompanyContext(DbContextOptions<CompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DostawaTowary> DostawaTowaries { get; set; }

    public virtual DbSet<Dostawcy> Dostawcies { get; set; }

    public virtual DbSet<Faktury> Fakturies { get; set; }

    public virtual DbSet<LokalizacjaMaszyny> LokalizacjaMaszynies { get; set; }

    public virtual DbSet<Lokalizacje> Lokalizacjes { get; set; }

    public virtual DbSet<MagazynTowary> MagazynTowaries { get; set; }

    public virtual DbSet<Magazyny> Magazynies { get; set; }

    public virtual DbSet<MaszynaTowary> MaszynaTowaries { get; set; }

    public virtual DbSet<MaszynaTrasa> MaszynaTrasas { get; set; }

    public virtual DbSet<Maszyny> Maszynies { get; set; }

    public virtual DbSet<Pojazdy> Pojazdies { get; set; }

    public virtual DbSet<Pracownicy> Pracownicies { get; set; }

    public virtual DbSet<PracownikTowary> PracownikTowaries { get; set; }

    public virtual DbSet<StanowiskaPracy> StanowiskaPracies { get; set; }

    public virtual DbSet<Towary> Towaries { get; set; }

    public virtual DbSet<Transakcje> Transakcjes { get; set; }

    public virtual DbSet<Trasy> Trasies { get; set; }

    public virtual DbSet<TypyMaszyn> TypyMaszyns { get; set; }

    public virtual DbSet<Warsztaty> Warsztaties { get; set; }

    public virtual DbSet<Wizyty> Wizyties { get; set; }

    public virtual DbSet<ZamowieniaZewnetrzne> ZamowieniaZewnetrznes { get; set; }

    public virtual DbSet<ZamowienieTowary> ZamowienieTowaries { get; set; }

    public virtual DbSet<Zamowienium> Zamowienia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-SD6PEG2;Initial Catalog=VendingMobile;Integrated Security=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DostawaTowary>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.IdtowaruNavigation).WithMany(p => p.DostawaTowaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DostawaTowary_Towary");

            entity.HasOne(d => d.IdzamowienieZewnetrzneNavigation).WithMany(p => p.DostawaTowaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DostawaTowary_ZamowieniaZewnetrzne");
        });

        modelBuilder.Entity<Dostawcy>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.KodPocztowy).IsFixedLength();
        });

        modelBuilder.Entity<Faktury>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.KodPocztowy).IsFixedLength();
            entity.Property(e => e.Nip).IsFixedLength();
        });

        modelBuilder.Entity<LokalizacjaMaszyny>(entity =>
        {
            entity.HasKey(e => new { e.IdLokalizacji, e.MaszynaId }).HasName("PK__Lokaliza__1BD89944B8F83B92");

            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.IdLokalizacjiNavigation).WithMany(p => p.LokalizacjaMaszynies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lokalizac__IdLok__278EDA44");

            entity.HasOne(d => d.Maszyna).WithMany(p => p.LokalizacjaMaszynies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LokalizacjaMaszyny_Maszyny_NEW");
        });

        modelBuilder.Entity<Lokalizacje>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.KodPocztowy).IsFixedLength();
        });

        modelBuilder.Entity<MagazynTowary>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.IdmagazynuNavigation).WithMany(p => p.MagazynTowaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MagazynTowary_Magazyny");

            entity.HasOne(d => d.IdtowaruNavigation).WithMany(p => p.MagazynTowaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MagazynTowary_Towary");
        });

        modelBuilder.Entity<Magazyny>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.KodPocztowy).IsFixedLength();
        });

        modelBuilder.Entity<MaszynaTowary>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.IdtowaruNavigation).WithMany(p => p.MaszynaTowaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaszynaTowary_Towary");

            entity.HasOne(d => d.Maszyna).WithMany(p => p.MaszynaTowaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaszynaTowary_Maszyny_NEW");
        });

        modelBuilder.Entity<MaszynaTrasa>(entity =>
        {
            entity.HasKey(e => new { e.Idtrasy, e.MaszynaId }).HasName("PK__MaszynaT__3643C2A764850984");

            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.IdtrasyNavigation).WithMany(p => p.MaszynaTrasas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MaszynaTr__IDTra__324172E1");

            entity.HasOne(d => d.Maszyna).WithMany(p => p.MaszynaTrasas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaszynaTrasa_Maszyny_NEW");
        });

        modelBuilder.Entity<Maszyny>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NumerMaszyny).IsFixedLength();

            entity.HasOne(d => d.IdtypMaszynyNavigation).WithMany(p => p.Maszynies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Maszyny_TypyMaszyn");
        });

        modelBuilder.Entity<Pojazdy>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NumerRejestracyjny).IsFixedLength();

            entity.HasOne(d => d.IdwarsztatuNavigation).WithMany(p => p.Pojazdies).HasConstraintName("FK_Pojazdy_Warsztaty");
        });

        modelBuilder.Entity<Pracownicy>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.IdpojazduNavigation).WithMany(p => p.Pracownicies).HasConstraintName("FK_Pracownicy_Pojazdy");

            entity.HasOne(d => d.IdstanowiskaPracyNavigation).WithMany(p => p.Pracownicies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pracownicy_StanowiskaPracy");

            entity.HasOne(d => d.IdtrasyNavigation).WithMany(p => p.Pracownicies).HasConstraintName("FK_Pracownicy_Trasy");
        });

        modelBuilder.Entity<PracownikTowary>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.IdpracownikaNavigation).WithMany(p => p.PracownikTowaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PracownikTowary_Pracownicy");

            entity.HasOne(d => d.IdtowaruNavigation).WithMany(p => p.PracownikTowaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PracownikTowary_Towary");
        });

        modelBuilder.Entity<StanowiskaPracy>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Towary>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Transakcje>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.TypPlatnosci).IsFixedLength();

            entity.HasOne(d => d.IdtowaruNavigation).WithMany(p => p.Transakcjes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transakcje_Towary");

            entity.HasOne(d => d.Maszyna).WithMany(p => p.Transakcjes).HasConstraintName("FK_Transakcje_Maszyny_NEW");
        });

        modelBuilder.Entity<Trasy>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<TypyMaszyn>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Warsztaty>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.KodPocztowy).IsFixedLength();
        });

        modelBuilder.Entity<Wizyty>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.IdpracownikaNavigation).WithMany(p => p.Wizyties)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Wizyty_Pracownicy");

            entity.HasOne(d => d.Maszyna).WithMany(p => p.Wizyties).HasConstraintName("FK_Wizyty_Maszyny_NEW");
        });

        modelBuilder.Entity<ZamowieniaZewnetrzne>(entity =>
        {
            entity.HasKey(e => e.IdzamowienieZewnetrzne).HasName("PK_ZamowieniaZewnetrzne_1");

            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.IddostawcyNavigation).WithMany(p => p.ZamowieniaZewnetrznes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZamowieniaZewnetrzne_Dostawcy");

            entity.HasOne(d => d.IdfakturyNavigation).WithOne(p => p.ZamowieniaZewnetrzne)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZamowieniaZewnetrzne_Faktury");

            entity.HasOne(d => d.IdmagazynuNavigation).WithMany(p => p.ZamowieniaZewnetrznes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZamowieniaZewnetrzne_Magazyny");
        });

        modelBuilder.Entity<ZamowienieTowary>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.IdtowaruNavigation).WithMany(p => p.ZamowienieTowaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZamowienieTowary_Towary");

            entity.HasOne(d => d.IdzamowieniaNavigation).WithMany(p => p.ZamowienieTowaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZamowienieTowary_Zamowienia");
        });

        modelBuilder.Entity<Zamowienium>(entity =>
        {
            entity.HasKey(e => e.Idzamowienia).HasName("PK_Zamowienia_1");

            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.IdmagazynuNavigation).WithMany(p => p.Zamowienia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zamowienia_Magazyny");

            entity.HasOne(d => d.IdpracownikaNavigation).WithMany(p => p.Zamowienia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zamowienia_Pracownicy");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
