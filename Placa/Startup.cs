using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Placas.Contexto;
using Placas.Servicos;

namespace Placas
{
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
            //Implementação da injeção de dependência do EF
            services.AddDbContext<ContextoGeral>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ConexaoDBPlaca")));
            
            //Implementação da injeção de dependência
            services.AddScoped<PlacaServico>();
            services.AddScoped<AtendimentoEspecificacoesServico>();
            services.AddScoped<LocalizacaoServico>();
            services.AddScoped<PosicaoServico>();
            services.AddScoped<TipoRegionalServico>();
            services.AddScoped<TipoPistaServico>();
            services.AddScoped<SinalizacaoServico>();
            services.AddScoped<EstadoConservacaoServico>();
            services.AddScoped<SentidoServico>();
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Placa", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Placa v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
