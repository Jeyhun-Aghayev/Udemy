using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using Udemy.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*
builder.Services.AddTransient<IValidator<CategoryCreateDto>, CategoryCreateDtoValidator>();
builder.Services.AddTransient<IValidator<UpdateCategoryDto>, CategoryUpdateDtoValidator>();
builder.Services.AddTransient<IValidator<CreateStudentDto>, StudentCreateDtoValidator>();
builder.Services.AddTransient<IValidator<UpdateStudentDto>, StudentUpdateDtoValidator>();
builder.Services.AddTransient<IValidator<CreateTeacherDto>, TeacherCreateDtoValidator>();
builder.Services.AddTransient<IValidator<UpdateTeacherDto>, TeacherUpdateDtoValidator>();
builder.Services.AddTransient<IValidator<CreateCourseDto>, CourseCreateDtoValidator>();
builder.Services.AddTransient<IValidator<UpdateCourseDto>, CourseUpdateDtoValidator>();*/
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
