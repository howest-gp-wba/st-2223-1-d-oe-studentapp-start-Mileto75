var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//custom routes come first
app.MapControllerRoute(
    name: "ShowStudentCourses",
    pattern: "/Students/{id:int}/Courses",
    defaults: new { Controller = "Students", Action = "ShowStudentCourses" }
    );
app.MapControllerRoute(
    name: "TeacherDetail",
    pattern: "/Teachers/{id:int}",
    defaults: new { Controller = "Teachers", Action = "Details" }
    );
app.MapControllerRoute(
    name: "AllTeachers",
    pattern: "/Teachers",
    defaults: new { Controller = "Teachers", Action = "ShowAll" }
    );
app.MapControllerRoute(
    name: "AllStudents",
    pattern: "/Students",
    defaults: new { Controller = "Students", Action = "ShowAll" }
    );
// /courses => CoursesController => Courses method
app.MapControllerRoute(
    name: "AllCourses",
    pattern: "/Courses",
    defaults: new {Controller = "Courses", Action = "Courses" }
    );
//default route comes last
// Courses/1/Students => Course:CourseStudents
app.MapControllerRoute(
    name: "StudentsInCourse",
    pattern: "Courses/{courseId:int}/Students",
    defaults: new { Controller = "Courses", Action = "CourseStudents" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
