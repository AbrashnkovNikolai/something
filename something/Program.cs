using Microsoft.EntityFrameworkCore;
using something.Models;

var builder = WebApplication.CreateBuilder(args);

// Добавляем контекст базы данных
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Database=dz2;Username=postgres;Password=123;"));

builder.Services.AddAuthorization();
builder.Services.AddControllersWithViews(); // Убедитесь, что это не закомментировано

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// Используйте Dependency Injection для доступа к ApplicationContext
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

    // Получаем объекты из БД и выводим на консоль
    var users = db.gifted_grants.ToList();
    Console.WriteLine("Users list:");
    foreach (Gifted_grant g in users)
    {
        Console.WriteLine($"{g.id}.{g.grant_name} - {g.student_id},{g.grant_value}");
    }
}

// Определение ApplicationContext
public class ApplicationContext : DbContext
{
    public DbSet<Gifted_grant> gifted_grants { get; set; } = null!;
    public DbSet<Faculty> facultys { get; set; } = null!;
    public DbSet<Grade> grades { get; set; } = null!;
    public DbSet<Grant_info> grants_info { get; set; } = null!;
    public DbSet<Lecturer> lecturers { get; set; } = null!;
    public DbSet<Student> students { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
}
