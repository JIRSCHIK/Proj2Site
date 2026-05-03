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
    <title>Meu Site — Projeto 2</title>
    <link rel='preconnect' href='https://fonts.googleapis.com'>
    <link href='https://fonts.googleapis.com/css2?family=Share+Tech+Mono&family=Bebas+Neue&family=Inter:wght@300;400&display=swap' rel='stylesheet'>
    <style>
        :root {
            --bg:       #080c10;
            --surface:  #0d1117;
            --border:   #1c2840;
            --accent:   #00e5ff;
            --accent2:  #0066ff;
            --dim:      #3a5070;
            --text:     #cdd9e5;
            --muted:    #607080;
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

        /* grid */
        body::before {
            content: '';
            position: fixed; inset: 0;
            background-image:
                linear-gradient(var(--border) 1px, transparent 1px),
                linear-gradient(90deg, var(--border) 1px, transparent 1px);
            background-size: 48px 48px;
            opacity: .35;
            pointer-events: none;
        }

        /* glow */
        body::after {
            content: '';
            position: fixed; inset: 0;
            background: radial-gradient(ellipse 60% 55% at 50% 50%,
                rgba(0,102,255,.12) 0%, transparent 70%);
            pointer-events: none;
        }

        /* card */
        .card {
            position: relative;
            z-index: 1;
            background: var(--surface);
            border: 1px solid var(--border);
            border-radius: 4px;
            padding: 3rem 4rem;
            text-align: center;
            max-width: 580px;
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

        /* label */
        .label {
            font-family: 'Share Tech Mono', monospace;
            font-size: .7rem;
            letter-spacing: .25em;
            color: var(--dim);
            text-transform: uppercase;
            margin-bottom: 2.2rem;
            display: flex;
            align-items: center;
            justify-content: center;
            gap: .75rem;
        }
        .label::before, .label::after {
            content: ''; flex: 1; height: 1px; background: var(--border);
        }

        /* ── ANALOG CLOCK ── */
        .clock-wrap {
            display: flex;
            flex-direction: column;
            align-items: center;
            margin-bottom: 2.2rem;
        }

        .clock-ring {
            position: relative;
            width: 180px;
            height: 180px;
        }

        canvas#clock {
            position: absolute;
            top: 0; left: 0;
            border-radius: 50%;
        }

        .date-line {
            font-family: 'Share Tech Mono', monospace;
            font-size: .75rem;
            letter-spacing: .18em;
            color: var(--muted);
            margin-top: 1rem;
            text-transform: uppercase;
        }

        /* divider */
        .divider {
            width: 100%; height: 1px;
            background: linear-gradient(90deg, transparent, var(--border), transparent);
            margin: 1.8rem 0;
        }

        h1 {
            font-family: 'Bebas Neue', sans-serif;
            font-size: 2.6rem;
            letter-spacing: .12em;
            line-height: 1.1;
            color: #fff;
            text-transform: uppercase;
            margin-bottom: .75rem;
        }
        h1 span { color: var(--accent); }

        p {
            font-size: .88rem;
            color: var(--muted);
            letter-spacing: .04em;
            line-height: 1.7;
        }

        /* status */
        .status {
            display: inline-flex;
            align-items: center;
            gap: .5rem;
            margin-top: 2rem;
            padding: .4rem 1.1rem;
            border: 1px solid rgba(0,229,255,.2);
            border-radius: 2px;
            font-family: 'Share Tech Mono', monospace;
            font-size: .7rem;
            letter-spacing: .15em;
            color: var(--accent);
            text-transform: uppercase;
        }
        .dot {
            width: 7px; height: 7px;
            border-radius: 50%;
            background: var(--accent);
            box-shadow: 0 0 8px var(--accent);
            animation: pulse 2s ease-in-out infinite;
        }
        @keyframes pulse {
            0%,100% { opacity: 1; transform: scale(1); }
            50%      { opacity: .4; transform: scale(.7); }
        }

        /* corners */
        .corner {
            position: absolute;
            width: 14px; height: 14px;
            border-color: var(--dim); border-style: solid;
        }
        .corner.tl { top: -1px;    left: -1px;   border-width: 2px 0 0 2px; }
        .corner.tr { top: -1px;    right: -1px;  border-width: 2px 2px 0 0; }
        .corner.bl { bottom: -1px; left: -1px;   border-width: 0 0 2px 2px; }
        .corner.br { bottom: -1px; right: -1px;  border-width: 0 2px 2px 0; }
    </style>
</head>
<body>

<div class='card'>
    <span class='corner tl'></span>
    <span class='corner tr'></span>
    <span class='corner bl'></span>
    <span class='corner br'></span>

    <div class='label'>Sistema Online</div>

    <div class='clock-wrap'>
        <div class='clock-ring'>
            <canvas id='clock' width='180' height='180'></canvas>
        </div>
        <div class='date-line' id='dateline'>—</div>
    </div>

    <div class='divider'></div>

    <h1>Bem-vindo ao<br><span>Projeto 2</span></h1>
    <p>Novo deploy realizado com sucesso.<br>Ambiente em execução e pronto para uso.</p>

    <div class='status'>
        <span class='dot'></span>
        Deploy concluído
    </div>
</div>

<script>
    const DAYS   = ['Domingo','Segunda','Terça','Quarta','Quinta','Sexta','Sábado'];
    const MONTHS = ['Jan','Fev','Mar','Abr','Mai','Jun','Jul','Ago','Set','Out','Nov','Dez'];
    function pad(n){ return String(n).padStart(2,'0'); }

    const canvas = document.getElementById('clock');
    const ctx    = canvas.getContext('2d');
    const CX = 90, CY = 90, R = 84;

    function drawClock() {
        const now = new Date();
        const sec = now.getSeconds();
        const min = now.getMinutes();
        const hr  = now.getHours() % 12;

        ctx.clearRect(0, 0, 180, 180);

        /* ── outer ring ── */
        ctx.beginPath();
        ctx.arc(CX, CY, R, 0, Math.PI * 2);
        ctx.strokeStyle = '#1c2840';
        ctx.lineWidth   = 1.5;
        ctx.stroke();

        /* ── subtle glow ring ── */
        ctx.beginPath();
        ctx.arc(CX, CY, R - 1, 0, Math.PI * 2);
        ctx.strokeStyle = 'rgba(0,229,255,.07)';
        ctx.lineWidth   = 6;
        ctx.stroke();

        /* ── tick marks ── */
        for (let i = 0; i < 60; i++) {
            const angle  = (i / 60) * Math.PI * 2 - Math.PI / 2;
            const isMaj  = i % 5 === 0;
            const outer  = R - 2;
            const inner  = isMaj ? R - 14 : R - 8;
            ctx.beginPath();
            ctx.moveTo(CX + Math.cos(angle) * inner, CY + Math.sin(angle) * inner);
            ctx.lineTo(CX + Math.cos(angle) * outer, CY + Math.sin(angle) * outer);
            ctx.strokeStyle = isMaj ? '#3a5070' : '#1c2840';
            ctx.lineWidth   = isMaj ? 1.5 : .8;
            ctx.stroke();
        }

        /* ── hour numbers ── */
        ctx.font         = '500 9px "Share Tech Mono", monospace';
        ctx.textAlign    = 'center';
        ctx.textBaseline = 'middle';
        ctx.fillStyle    = '#3a5070';
        for (let i = 1; i <= 12; i++) {
            const angle = (i / 12) * Math.PI * 2 - Math.PI / 2;
            const nr    = R - 22;
            ctx.fillText(i, CX + Math.cos(angle) * nr, CY + Math.sin(angle) * nr);
        }

        /* ── progress arc (seconds) ── */
        const secAngle = (sec / 60) * Math.PI * 2 - Math.PI / 2;
        ctx.beginPath();
        ctx.arc(CX, CY, R - 4, -Math.PI / 2, secAngle);
        ctx.strokeStyle = 'rgba(0,102,255,.35)';
        ctx.lineWidth   = 3;
        ctx.lineCap     = 'round';
        ctx.stroke();

        /* helper: draw hand */
        function hand(angle, length, width, color, glow) {
            const ex = CX + Math.cos(angle) * length;
            const ey = CY + Math.sin(angle) * length;
            const tx = CX + Math.cos(angle + Math.PI) * 12;
            const ty = CY + Math.sin(angle + Math.PI) * 12;
            if (glow) {
                ctx.shadowColor = color;
                ctx.shadowBlur  = 10;
            }
            ctx.beginPath();
            ctx.moveTo(tx, ty);
            ctx.lineTo(ex, ey);
            ctx.strokeStyle = color;
            ctx.lineWidth   = width;
            ctx.lineCap     = 'round';
            ctx.stroke();
            ctx.shadowBlur  = 0;
        }

        /* hour hand */
        const hrAngle  = ((hr + min / 60) / 12) * Math.PI * 2 - Math.PI / 2;
        hand(hrAngle,  46, 3.5, '#cdd9e5', false);

        /* minute hand */
        const minAngle = ((min + sec / 60) / 60) * Math.PI * 2 - Math.PI / 2;
        hand(minAngle, 64, 2,   '#cdd9e5', false);

        /* second hand */
        const secAngle2 = (sec / 60) * Math.PI * 2 - Math.PI / 2;
        hand(secAngle2, 72, 1,  '#00e5ff', true);

        /* tail dot of second hand */
        ctx.beginPath();
        ctx.arc(CX + Math.cos(secAngle2 + Math.PI) * 12,
                CY + Math.sin(secAngle2 + Math.PI) * 12, 2, 0, Math.PI * 2);
        ctx.fillStyle   = '#00e5ff';
        ctx.shadowColor = '#00e5ff';
        ctx.shadowBlur  = 8;
        ctx.fill();
        ctx.shadowBlur  = 0;

        /* center pip */
        ctx.beginPath();
        ctx.arc(CX, CY, 4, 0, Math.PI * 2);
        ctx.fillStyle   = '#00e5ff';
        ctx.shadowColor = '#00e5ff';
        ctx.shadowBlur  = 12;
        ctx.fill();
        ctx.shadowBlur  = 0;

        /* date */
        document.getElementById('dateline').textContent =
            DAYS[now.getDay()] + ',  ' +
            pad(now.getDate()) + ' ' + MONTHS[now.getMonth()] + ' ' + now.getFullYear();
    }

    drawClock();
    setInterval(drawClock, 1000);
</script>
</body>
</html>
                ");
            });
        }
    }
}
