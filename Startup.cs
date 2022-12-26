using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PSP.Data;
using PSP.Interfaces;
using PSP.Services;

namespace PSP;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        services.AddControllersWithViews();
        services.AddScoped<IBookingsService, BookingService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IEmployeeCardService, EmployeeCardService>();
        services.AddScoped<IEmployeeShiftService, EmployeeShiftService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<ILocationService, LocationService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IShiftService, ShiftService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IPermissionTypeService, PermissionTypeService>();
        services.AddScoped<ICatalogueItemService, CatalogueItemsService>();
        services.AddScoped<IInventoryService, InventoryService>();
        services.AddScoped<IInventoryUsageService, InventoryUsageService>();
        services.AddScoped<IModifierService, ModifierService>();


        services.AddSwaggerGen(c =>
        {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "MiddlewareExamples", Version = "v2" });
        });


    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "MiddlewareExamples v2"));

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}