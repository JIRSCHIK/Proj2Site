using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Threading.Tasks;

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

            // Endpoint para servir a imagem
            app.Map("/image2.png", imageApp =>
            {
                imageApp.Run(async context =>
                {
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "image2.png");

                    if (!File.Exists(imagePath))
                    {
                        context.Response.StatusCode = 404;
                        await context.Response.WriteAsync("Imagem não encontrada");
                        return;
                    }

                    context.Response.ContentType = "image/png";
                    await context.Response.SendFileAsync(imagePath);
                });
            });

            // Página principal (HTML)

            app.Run(async context =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";

                await context.Response.WriteAsync(@"
                    <!DOCTYPE html>
                    <html lang='pt-BR'>
                    <head>
                    <meta charset='UTF-8'>
                    <title>Projeto 2 - Meu Site</title>
                    <style>
                        body {
                        background-color:rgb(215,224,229);
                        font-family:verdana;
                        align-items: center;
                        }
                        .relogio {
                        font-size: 2em;
                        background: #777;
                        padding: 20px 40px;
                        border-radius: 10px;
                        box-shadow: 0 0 20px rgba(255, 255, 255, 0.1);
                        }
                        .resized-image {
                        width: 350px;
                        height: auto;
                        }
                    </style>
                    </head>
                    <body>
                        <br>
                        <p>
                            <h1><center>Projeto 2 - Meu Site</center></h1>
                            <h2><center>Cloud Treinamentos</center></h2>
                            <center><img src='/images/poweredbyaws.png' alt='Powered by AWS' class='resized-image'></center>
                        <br>
                    <div class='relogio' id='relogio'>00:00:00</div>
                    <script>
                        function atualizarRelogio() {
                        const agora = new Date();
                        const horas = String(agora.getHours()).padStart(2, '0');
                        const minutos = String(agora.getMinutes()).padStart(2, '0');
                        const segundos = String(agora.getSeconds()).padStart(2, '0');
                        const relogio = document.getElementById('relogio');
                        relogio.textContent = `${horas}:${minutos}:${segundos}`;
                        }
                        setInterval(atualizarRelogio, 1000);
                        atualizarRelogio(); // para mostrar o horário imediatamente
                    </script>
                        <br>
                            <h5><center>Hosted by AWS Fargate Service</center></h5>
                            <h5><a href='https://comunidadecloud.com/' target='_blank'>Visit: Cloud Treinamentos</a></h5>
                        </p>
                    </body>
                    </html>
                ");
            });
        }
    }
}
