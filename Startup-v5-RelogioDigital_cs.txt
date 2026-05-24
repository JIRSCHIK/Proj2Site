// Arquivo original: Startup-v5-RelogioDigital_cs //
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
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Engedomus — Projeto 2</title>
    <link rel='preconnect' href='https://fonts.googleapis.com'>
    <link href='https://fonts.googleapis.com/css2?family=Share+Tech+Mono&family=Bebas+Neue&family=Inter:wght@300;400&display=swap' rel='stylesheet'>
    <link rel='preconnect' href='https://fonts.gstatic.com' crossorigin>
    <link href='https://fonts.googleapis.com/css2?family=Saira+Stencil+One&display=swap' rel='stylesheet'>
    <style>
        :root {
            --bg:        #080c10;
            --surface:   #0d1117;
            --border:    #1c2840;
            --accent:    #00e5ff;
            --accent2:   #0066ff;
            --orgclock:  #FF8904;
            --dim:       #3a5070;
            --text:      #cdd9e5;
            --text-muted:#607080;
        }

        *, *::before, *::after { box-sizing: border-box; margin: 0; padding: 0; }

        body {
            background: var(--bg);
            color: var(--text);
            font-family: 'Inter', sans-serif;
            font-weight: 300;
            min-height: 100vh;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            overflow: hidden;
            position: relative;
        }

        /* ── grid background ── */
        body::before {
            content: '';
            position: fixed;
            inset: 0;
            background-image:
                linear-gradient(var(--border) 1px, transparent 1px),
                linear-gradient(90deg, var(--border) 1px, transparent 1px);
            background-size: 48px 48px;
            opacity: .35;
            pointer-events: none;
        }

        /* ── radial glow ── */
        body::after {
            content: '';
            position: fixed;
            inset: 0;
            background: radial-gradient(ellipse 60% 55% at 50% 50%,
                rgba(0,102,255,.12) 0%,
                transparent 70%);
            pointer-events: none;
        }

        /* ── card ── */
        .card {
            position: relative;
            z-index: 1;
            background: var(--surface);
            border: 1px solid var(--border);
            border-radius: 4px;
            padding: 3rem 4rem;
            text-align: center;
            max-width: 600px;
            width: 90vw;
            box-shadow:
                0 0 0 1px rgba(0,229,255,.04),
                0 24px 80px rgba(0,0,0,.6),
                inset 0 1px 0 rgba(255,255,255,.04);
            animation: fadeUp .8s cubic-bezier(.22,1,.36,1) both;
        }

        @keyframes fadeUp {
            from { opacity: 0; transform: translateY(28px); }
            to   { opacity: 1; transform: translateY(0); }
        }

        /* ── top label ── */
        .label {
            font-family: 'Share Tech Mono', monospace;
            font-size: .7rem;
            letter-spacing: .25em;
            color: var(--dim);
            text-transform: uppercase;
            margin-bottom: 2.5rem;
            display: flex;
            align-items: center;
            justify-content: center;
            gap: .75rem;
        }
        .label::before, .label::after {
            content: '';
            flex: 1;
            height: 1px;
            background: var(--border);
        }

        /* ── CLOCK ── */
        .clock-wrap {
            margin-bottom: 2.5rem;
        }

        .clock {
            font-family: 'Share Tech Mono', monospace;
            /* font-family: 'Saira Stencil One', sans-serif; */
            font-size: 5.5rem;
            line-height: 1;
            letter-spacing: .06em;
            /* color: var(--accent); */
            color: var(--orgclock);
            text-shadow:
                0 0 20px rgba(0,229,255,.55),
                0 0 60px rgba(0,229,255,.2);
            animation: flicker 8s infinite;
        }

        @keyframes flicker {
            0%,95%,97%,100% { opacity: 1; }
            96%              { opacity: .85; }
        }

        .colon {
            display: inline-block;
            animation: blink 1s step-start infinite;
            color: var(--accent2);
        }
        @keyframes blink { 0%,49% { opacity: 1; } 50%,100% { opacity: .15; } }

        .date-line {
            font-family: 'Share Tech Mono', monospace;
            font-size: .8rem;
            letter-spacing: .18em;
            color: var(--text-muted);
            margin-top: .75rem;
            text-transform: uppercase;
        }

        /* ── divider ── */
        .divider {
            width: 100%;
            height: 1px;
            background: linear-gradient(90deg, transparent, var(--border), transparent);
            margin: 2rem 0;
        }

        /* ── heading ── */
        h1 {
            font-family: 'Bebas Neue', sans-serif;
            font-size: 2.6rem;
            letter-spacing: .12em;
            line-height: 1.1;
            color: #fff;
            text-transform: uppercase;
            margin-bottom: .75rem;
        }

        h1 span {
            color: var(--accent);
        }

        p {
            font-size: .88rem;
            color: var(--text-muted);
            letter-spacing: .04em;
            line-height: 1.7;
        }

        /* ── status badge ── */
        .status {
            display: inline-flex;
            align-items: center;
            gap: .5rem;
            margin-top: 2rem;
            padding: .4rem 1.1rem;
            border: 2px solid rgba(0,229,255,.2);
            border-radius: 2px;
            font-family: 'Share Tech Mono', monospace;
            font-size: .9rem;
            /* font-size: 1.5rem; */
            letter-spacing: .15em;
            color: var(--accent);
            text-transform: uppercase;
        }

        .dot {
            width: 7px;
            height: 7px;
            border-radius: 50%;
            background: var(--accent);
            box-shadow: 0 0 8px var(--accent);
            animation: pulse 2s ease-in-out infinite;
        }

        @keyframes pulse {
            0%,100% { opacity: 1; transform: scale(1); }
            50%      { opacity: .4; transform: scale(.7); }
        }

        /* ── corner decorations ── */
        .corner {
            position: absolute;
            width: 14px;
            height: 14px;
            border-color: var(--dim);
            border-style: solid;
        }
        .corner.tl { top: -1px;  left: -1px;  border-width: 2px 0 0 2px; }
        .corner.tr { top: -1px;  right: -1px; border-width: 2px 2px 0 0; }
        .corner.bl { bottom: -1px; left: -1px;  border-width: 0 0 2px 2px; }
        .corner.br { bottom: -1px; right: -1px; border-width: 0 2px 2px 0; }
    </style>
</head>
<body>

<div class='card'>
    <!-- corner brackets -->
    <span class='corner tl'></span>
    <span class='corner tr'></span>
    <span class='corner bl'></span>
    <span class='corner br'></span>

    <div class='label'>Sistema Online</div>

    <!-- CLOCK -->
    <div class='clock-wrap'>
        <div class='clock' id='clk'>
            <span id='h'>00</span><span class='colon'>:</span><span id='m'>00</span><span class='colon'>:</span><span id='s'>00</span>
        </div>
        <div class='date-line' id='date-line'>—</div>
    </div>

    <div class='divider'></div>

    <h1>Bem-vindo ao<br><span>Projeto 2</span></h1>
    <p>Novo deploy realizado com sucesso.<br>Ambiente em execução e pronto para uso.</p>

    <div class='status'>
        <span class='dot'></span>
        Deployed by JIRSCHIK
    </div>
</div>

<script>
    const DAYS = ['Domingo','Segunda','Terça','Quarta','Quinta','Sexta','Sábado'];
    const MONTHS = ['Jan','Fev','Mar','Abr','Mai','Jun','Jul','Ago','Set','Out','Nov','Dez'];

    function pad(n) { return String(n).padStart(2, '0'); }

    function tick() {
        const now = new Date();
        document.getElementById('h').textContent = pad(now.getHours());
        document.getElementById('m').textContent = pad(now.getMinutes());
        document.getElementById('s').textContent = pad(now.getSeconds());
        document.getElementById('date-line').textContent =
            DAYS[now.getDay()] + ',  ' +
            pad(now.getDate()) + ' ' +
            MONTHS[now.getMonth()] + ' ' +
            now.getFullYear();
    }

    tick();
    setInterval(tick, 1000);
</script>
</body>
</html>
                ");
            });
        }
    }
}
