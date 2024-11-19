using Microsoft.EntityFrameworkCore;
using TasksManagerAPI.Models;

namespace TasksManagerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectParticipant> Participants { get; set; }
        public DbSet<TaskAssignee> Assignees { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Уникальные индексы для предотвращения дублирования
            modelBuilder.Entity<ProjectParticipant>()
                .HasIndex(pp => new { pp.ProjectId, pp.UserId })
                .IsUnique();

            modelBuilder.Entity<TaskAssignee>()
                .HasIndex(ta => new { ta.TaskId, ta.UserId })
                .IsUnique();

            // Настройка поведения для ProjectParticipant
            modelBuilder.Entity<ProjectParticipant>()
                .HasOne(pp => pp.Project)
                .WithMany(p => p.ProjectParticipants)
                .HasForeignKey(pp => pp.ProjectId)
                .OnDelete(DeleteBehavior.Cascade); // При удалении проекта удаляем участников

            modelBuilder.Entity<ProjectParticipant>()
                .HasOne(pp => pp.User)
                .WithMany()
                .HasForeignKey(pp => pp.UserId)
                .OnDelete(DeleteBehavior.NoAction); // Запрещаем каскадное удаление пользователя

            // Настройка поведения для TaskAssignee
            modelBuilder.Entity<TaskAssignee>()
                .HasOne(ta => ta.Task)
                .WithMany()
                .HasForeignKey(ta => ta.TaskId)
                .OnDelete(DeleteBehavior.Cascade); // При удалении задачи удаляем назначенных пользователей

            modelBuilder.Entity<TaskAssignee>()
                .HasOne(ta => ta.User)
                .WithMany()
                .HasForeignKey(ta => ta.UserId)
                .OnDelete(DeleteBehavior.NoAction); // Запрещаем каскадное удаление пользователя

            modelBuilder.Entity<ProjectTask>()
                .HasOne(pt => pt.Project)
                .WithMany()  // У проекта нет коллекции задач
                .HasForeignKey(pt => pt.ProjectId)
                .OnDelete(DeleteBehavior.NoAction); // Каскадное удаление задач при удалении проекта

            modelBuilder.Entity<ProjectTask>()
                .HasOne(pt => pt.CreatedByUser)  // Связь с пользователем
                .WithMany()  // У пользователя нет коллекции задач
                .HasForeignKey(pt => pt.CreatedById)  // Внешний ключ CreatedBy
                .OnDelete(DeleteBehavior.NoAction); // Устанавливаем null, если пользователь удален

            modelBuilder.Entity<Project>()
                .HasOne(p => p.CreatedByUser)  // Связь с пользователем
                .WithMany()  // У пользователя нет коллекции проектов
                .HasForeignKey(p => p.CreatedById)  // Указываем внешний ключ для связи
                .OnDelete(DeleteBehavior.NoAction); // Устанавливаем поведение удаления (по вашему выбору)

        }


    }
}
