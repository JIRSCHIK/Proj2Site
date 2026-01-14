using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MEUSITE
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Nenhum serviço necessário para app mínima
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async context =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";

                await context.Response.WriteAsync(@"
                    <!DOCTYPE html>
                    <html lang='pt-BR'>
                    <head>
                        <meta charset='utf-8'>
                        <title>Meu Site</title>
                    </head>
                    <body style='background-color: #2c3e50; color: white; font-family: Arial, Helvetica, sans-serif;'>
                        <h1>Bem-vindo ao Site Projeto 2!</h1>
                        <p>Novo deploy realizado com sucesso.</p>
                    </body>
                    </html>
                ");
            });
        }
    }
}
