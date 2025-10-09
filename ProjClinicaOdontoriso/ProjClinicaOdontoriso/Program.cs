using ProjClinicaOdontoriso.Components;
using ProjClinicaOdontoriso.Configs;
using ProjClinicaOdontoriso.Models;
using ProjClinicaOdontoriso.Models.Funcionario;
using ProjClinicaOdontoriso.Models.Dentista;
using ProjClinicaOdontoriso.Models.Paciente;
{
    
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddScoped<Conexao>();
builder.Services.AddScoped<ConsultaDAO>();
builder.Services.AddScoped<PacienteDAO>();
builder.Services.AddScoped<ProcedimentoDAO>();
builder.Services.AddScoped<FuncionarioDAO>();
builder.Services.AddScoped<DentistaDAO>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
