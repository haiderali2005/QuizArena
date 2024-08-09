using Microsoft.EntityFrameworkCore;

namespace QuizArena.Models
{
    public class QuizAppDbContext : DbContext
    {
        public QuizAppDbContext(DbContextOptions option):base(option)
        {
            
        }
        public DbSet<User> table_Users { get; set; }
        public DbSet<Quiz> table_Quizzes { get; set; }
        public DbSet<Question> table_Questions { get; set; }
        public DbSet<Option> table_Options { get; set; }
        public DbSet<UserProgress> table_UserProgresses { get; set; }
        public DbSet<QuizResults> table_quizresults {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Quiz>()
                .HasKey(q => q.QuizId);

            modelBuilder.Entity<Question>()
                .HasKey(q => q.QuestionId);
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Quiz)
                .WithMany(qz => qz.Questions)
                .HasForeignKey(q => q.QuizId);

            modelBuilder.Entity<Option>()
                .HasKey(o => o.Id);
            modelBuilder.Entity<Option>()
                .HasOne(o => o.Question)
                .WithMany(q => q.Options)
                .HasForeignKey(o => o.QuestionId);

            modelBuilder.Entity<UserProgress>()
               .HasKey(o => o.Id);
            modelBuilder.Entity<UserProgress>()
                .HasOne(up => up.Quiz)
                .WithMany()
                .HasForeignKey(up => up.QuizId)
                      .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<UserProgress>()
       .HasOne(up => up.Question)
       .WithMany()
       .HasForeignKey(up => up.QuestionId)
             .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<UserProgress>()
                .HasOne(up => up.SelectOption)
                .WithMany()
                .HasForeignKey(up => up.SelectedOptionId)
                 .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
